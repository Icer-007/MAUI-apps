using MauiCommons;
using MauiCommons.Attributes;
using MauiCommons.Extensions;
using SandwichQuizz.Enums;
using SandwichQuizz.Interfaces.Factories;
using SandwichQuizz.Interfaces.Services;
using SandwichQuizz.Interfaces.ViewModels;
using SandwichQuizz.ViewModels.Rounds;
using System.Windows.Input;

namespace SandwichQuizz.ViewModels;

public partial class SetViewModel : ViewModelBase
{
    private const string ROUND2_IDENTIFIER = "sel";

    private const string ROUND3_THEME_FORMAT__THEME = "Menu  -  {0}";

    private readonly IViewModelFactory viewModelFactory;

    public SetViewModel(ILoggerService logger, IViewModelFactory viewModelFactory, ISoundViewModel soundViewModel) : base(logger)
    {
        this.viewModelFactory = viewModelFactory;
        this.Sound = soundViewModel;

        this.CommandLoadSet = new RelayCommand(async p => await this.LoadSet(p));

        this.CurrentRound = this.viewModelFactory.GetRoundEmptyViewModel();
    }

    public ICommand CommandLoadSet { get; }

    public RoundViewModelBase? CurrentRound
    {
        get => this.GetValue<RoundViewModelBase>();
        private set
        {
            this.SetValue(value);
            this.CurrentRound?.Timer?.Stop();
        }
    }

    public ISoundViewModel Sound { get; }

    private QuestionViewModel[] BuildQuestionsFromFileContent(string[] fileLines)
    {
        var reading = new List<Tuple<string, List<string>>>();

        Tuple<string, List<string>>? currentQuestion = null;
        foreach (string line in fileLines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                if (currentQuestion is not null)
                {
                    currentQuestion.Item2.Add(line);
                }
                else
                {
                    currentQuestion = Tuple.Create(line, new List<string>());
                    reading.Add(currentQuestion);
                }
            }
            else
            {
                currentQuestion = null;
            }
        }

        if (reading.Count > 0)
        {
            QuestionViewModel[] res;
            if (reading.All(v => v.Item2.Count == 0))
            {
                // Set of questions without answers, it's a round name + a set of themes (only the
                // first one will be used). It's round 2 if first question contains
                // ROUND2_IDENTIFIER or 4 otherwise.
                var actualRound = reading.First().Item1?.Contains(ROUND2_IDENTIFIER, StringComparison.OrdinalIgnoreCase) is true
                                  ? Round.Round2
                                  : Round.Round4;
                res = [this.viewModelFactory.GetQuestionViewModel(reading.First().Item1, [reading.ElementAtOrDefault(1)?.Item1 ?? string.Empty], actualRound)];
            }
            else if (reading.Count == 1)
            {
                // One question with its answers, it's a round name + a set of themes. That means
                // round 3 without displaying questions
                res = [.. reading.Single()
                                 .Item2
                                 .Select(a => this.viewModelFactory.GetQuestionViewModel(string.Format(ROUND3_THEME_FORMAT__THEME, a),
                                                                                         [],
                                                                                         Round.Round3))
                                 .Prepend(this.viewModelFactory.GetQuestionViewModel(reading.Single().Item1,
                                                                                     reading.Single().Item2.Select(a => string.Format(ROUND3_THEME_FORMAT__THEME, a)),
                                                                                     Round.Round3))];
            }
            else if (reading.First().Item2.Count == 0)
            {
                // One title plus questions with theirs answers, it's a round name + a set of themes
                // with theirs quesstions. That means round 3 with displaying questions
                res = [.. reading.Skip(1)
                                 .SelectMany(q => q.Item2.Select(r => this.viewModelFactory.GetQuestionViewModel(string.Format(ROUND3_THEME_FORMAT__THEME, q.Item1),
                                                                                                                 [r],
                                                                                                                 Round.Round3)))
                                 .Prepend(this.viewModelFactory.GetQuestionViewModel(reading.First().Item1,
                                                                                     reading.Skip(1).Select(q => string.Format(ROUND3_THEME_FORMAT__THEME, q.Item1)),
                                                                                     Round.Round3))];
            }
            else
            {
                // Set of questions with their answers. That means round 1
                res = [.. reading.Select(q => this.viewModelFactory.GetQuestionViewModel(q.Item1, q.Item2, Round.Round1))];
            }

            return res;
        }
        else
        {
            return [];
        }
    }

    private async Task<QuestionViewModel[]?> LoadRound(Round round)
    {
        try
        {
            if (round == Round.Round5)
            {
                return [this.viewModelFactory.GetQuestionViewModel(round.GetField().GetAttributeStringValue<DescriptionAttribute>() ?? string.Empty,
                                                                   [],
                                                                   round)];
            }
            else
            {
                var result = await FilePicker.Default.PickAsync();
                if (result?.FileName.EndsWith("txt", StringComparison.OrdinalIgnoreCase) ?? false)
                {
                    var res = await File.ReadAllLinesAsync(result.FullPath);
                    return this.BuildQuestionsFromFileContent(res);
                }
            }
        }
        catch { } // The user canceled or something went wrong

        return null;
    }

    private async Task LoadSet(object param)
    {
        // To reset current playing
        this.Sound.StopPlaying();

        if (param is Round round)
        {
            this.Sound.PlayRound(round);

            if (await this.LoadRound(round) is QuestionViewModel[] newSet)
            {
                this.CurrentRound = this.viewModelFactory.GetRoundViewModel(newSet);
                if (this.CurrentRound.Round != round)
                {
                    this.Sound.PlayRound(this.CurrentRound.Round);
                }
            }
        }
        else if (param is string filePath && File.Exists(filePath))
        {
            var src = await File.ReadAllLinesAsync(filePath);
            if (this.BuildQuestionsFromFileContent(src) is QuestionViewModel[] newSet)
            {
                this.CurrentRound = this.viewModelFactory.GetRoundViewModel(newSet);
                this.Sound.PlayRound(this.CurrentRound.Round);
            }
        }
    }
}
