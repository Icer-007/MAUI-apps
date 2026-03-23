using MauiCommons.Extensions;

namespace SandwichQuizz.Views.Controls;

public partial class CircularProgressBar : ContentView
{
    public enum ProgressDisplay
    {
        Ring,

        Disk,

        CustomContent,
    }

    public static readonly BindableProperty ActiveColorProperty =
        BindableProperty.Create(
            nameof(ActiveColor),
            typeof(Color),
            typeof(CircularProgressBar),
            Colors.Red);

    public static readonly BindableProperty DisplayTypeProperty =
            BindableProperty.Create(
            nameof(DisplayType),
            typeof(ProgressDisplay),
            typeof(CircularProgressBar),
            ProgressDisplay.Ring);

    public static readonly BindableProperty InactiveColorProperty =
                BindableProperty.Create(
            nameof(InactiveColor),
            typeof(Color),
            typeof(CircularProgressBar),
            Colors.LightGray);

    /// <summary>
    /// Percentage of progression, clamped in [0, 100].
    /// </summary>
    public static readonly BindableProperty PercentageProgressProperty =
        BindableProperty.Create(
            nameof(PercentageProgress),
            typeof(float),
            typeof(CircularProgressBar),
            0f,
            propertyChanged: OnPercentageProgressChanged,
            coerceValue: CoercePercentageProgress);

    /// <summary>
    /// Visual element used to display the animated disk.
    ///
    /// Since <see cref="CircularProgressBar"/> is a templated control, this reference will be
    /// retrieved in <see cref="OnApplyTemplate"/>.
    /// </summary>
    private GraphicsView? progressDisk;

    /// <summary>
    /// Visual element used to display the animated ring.
    ///
    /// Since <see cref="CircularProgressBar"/> is a templated control, this reference will be
    /// retrieved in <see cref="OnApplyTemplate"/>.
    /// </summary>
    private GraphicsView? progressRing;

    public CircularProgressBar()
    {
        this.InitializeComponent();
    }

    public Color ActiveColor
    {
        get => (Color)this.GetValue(ActiveColorProperty);
        set => this.SetValue(ActiveColorProperty, value);
    }

    public ProgressDisplay DisplayType
    {
        get => (ProgressDisplay)this.GetValue(DisplayTypeProperty);
        set => this.SetValue(DisplayTypeProperty, value);
    }

    public Color InactiveColor
    {
        get => (Color)this.GetValue(InactiveColorProperty);
        set => this.SetValue(InactiveColorProperty, value);
    }

    /// <summary>
    /// Percentage of progression, clamped in [0, 100].
    /// </summary>
    public float PercentageProgress
    {
        get => (float)this.GetValue(PercentageProgressProperty);
        set => this.SetValue(PercentageProgressProperty, value);
    }

    protected override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        // Retrieves the GraphicsView instances used to display the animated disk and the animated ring
        this.progressDisk = this.GetTemplateChild("ProgressDisk") as GraphicsView;
        this.progressRing = this.GetTemplateChild("ProgressRing") as GraphicsView;

        // Injects the custom drawable used to render the animated disk
        this.progressDisk?.Drawable =
            new DiskProgressBarDrawable(
                () => 1 - this.PercentageProgress / 100f,
                () => this.ActiveColor,
                () => this.InactiveColor)
            { SweepDirection = SweepDirection.CounterClockwise };

        // Injects the custom drawable used to render the animated ring
        this.progressRing?.Drawable =
            new RingProgressBarDrawable(
                () => 1 - this.PercentageProgress / 100f,
                () => this.ActiveColor,
                () => this.InactiveColor)
            { SweepDirection = SweepDirection.CounterClockwise };
    }

    private static object CoercePercentageProgress(BindableObject bindable, object value)
        => value is float val ? val.Between(0, 100) : value;

    private static void OnPercentageProgressChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is CircularProgressBar control)
        {
            control.progressRing?.Invalidate();
            control.progressDisk?.Invalidate();
        }
    }
}
