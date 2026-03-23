using MauiCommons.Extensions;

namespace SandwichQuizz.Views.Controls;

public class RingProgressBarDrawable(
    Func<float> getProgress,
    Func<Color> getActiveColor,
    Func<Color> getInactiveColor) : IDrawable
{
    public SweepDirection SweepDirection { get; set; }

    /// <summary>
    /// Draws the progress ring on the provided canvas within the specified rectangle.
    /// </summary>
    /// <param name="canvas"></param>
    /// <param name="rect"></param>
    public void Draw(ICanvas canvas, RectF rect)
    {
        // Determine the outer radius based on the smaller side of the control
        float outerRadius = Math.Min(rect.Width, rect.Height) / 2f;

        // Dynamically calculate stroke thickness based on control size. Ensures the arc is always
        // visually proportional, with a minimum thickness of 2 pixels.
        float strokeWidth = (outerRadius * 0.14f).AtLeast(2);

        // Calculate the inner radius to draw the arc centered correctly
        float radius = outerRadius - strokeWidth / 2f;
        PointF center = rect.Center;

        // Set the stroke size for the canvas to match the calculated thickness
        canvas.StrokeSize = strokeWidth;

        // Draw the full inactive background ring
        canvas.StrokeColor = getInactiveColor();
        canvas.DrawCircle(center, radius);

        // If there's any progress, draw the active arc over it (ensure progress is always in [0, 1])
        float progress = getProgress().Between(0, 1);
        if (progress > 0)
        {
            float startAngle = 90;
            float endAngle = startAngle + 360 * progress * (this.SweepDirection == SweepDirection.CounterClockwise ? 1 : -1);

            // Draw the remaining time arc with the active color
            canvas.StrokeColor = getActiveColor();
            canvas.DrawArc(
                center.X - radius,
                center.Y - radius,
                radius * 2,
                radius * 2,
                startAngle,
                endAngle,
                this.SweepDirection == SweepDirection.Clockwise,
                false
            );
        }
    }
}
