using MauiCommons.Extensions;

namespace SandwichQuizz.Views.Controls;

public class DiskProgressBarDrawable(
    Func<float> getProgress,
    Func<Color> getActiveColor,
    Func<Color> getInactiveColor) : IDrawable
{
    public SweepDirection SweepDirection { get; set; }

    /// <summary>
    /// Draws the progress disk on the provided canvas within the specified rectangle.
    /// </summary>
    /// <param name="canvas"></param>
    /// <param name="rect"></param>
    public void Draw(ICanvas canvas, RectF rect)
    {
        // Determine the radius based on the smaller side of the control
        float radius = Math.Min(rect.Width, rect.Height) / 2f;
        PointF center = rect.Center;

        // Draw the full inactive background disk
        canvas.FillColor = getInactiveColor();
        canvas.FillCircle(center, radius);

        // If there's any progress, draw the active disk over it (ensure progress is always in [0, 1])
        float progress = getProgress().Between(0, 1);
        if (progress > 0)
        {
            float startAngle = 90;
            float endAngle = startAngle + 360 * progress * (this.SweepDirection == SweepDirection.CounterClockwise ? 1 : -1);
            var path = new PathF();
            path.MoveTo(center);
            path.AddArc(
                center.X - radius,
                center.Y - radius,
                radius * 2,
                radius * 2,
                startAngle,
                endAngle,
                this.SweepDirection == SweepDirection.Clockwise);
            path.LineTo(center);
            canvas.FillColor = getActiveColor();
            canvas.FillPath(path);
        }
    }
}
