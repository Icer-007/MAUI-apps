using MauiCommons.Extensions;
using Microsoft.Maui.Controls.Shapes;

namespace SandwichQuizz.Extensions;

public static class VisualElementExtensions
{
    extension(VisualElement? visualElement)
    {
        /// <summary>
        /// Will clip the provided <see cref="VisualElement"/> in a part of a disk starting from top
        /// and visible at <paramref name="visibilityPercentage"/> percent, turning in <paramref name="sweepDirection"/>
        /// </summary>
        /// <param name="visibilityPercentage">
        /// Percentage, clamped in [0,1], of disk to display, starting from top
        /// </param>
        /// <param name="sweepDirection">Direction of clipping, starting from top</param>
        public void PieClipFromTop(float visibilityPercentage, SweepDirection sweepDirection)
        {
            visualElement?.Clip = visualElement.GetPieClipFromTopPathGeometry(visibilityPercentage, sweepDirection);
        }

        /// <summary>
        /// Will return a <see cref="PathGeometry"/> to clip the provided <see
        /// cref="VisualElement"/> in a part of a disk starting from top and visible at <paramref
        /// name="visibilityPercentage"/> percent, turning in <paramref name="sweepDirection"/>
        /// </summary>
        /// <param name="visibilityPercentage">
        /// Percentage, clamped in [0,1], of disk to display, starting from top
        /// </param>
        /// <param name="sweepDirection">Direction of clipping, starting from top</param>
        /// <returns>
        /// A <see cref="PathGeometry"/> that could be used to clip the provided <see
        /// cref="VisualElement"/> in a part of a disk starting from top and visible at <paramref
        /// name="visibilityPercentage"/> percent, turning in <paramref name="sweepDirection"/>, if
        /// provided <see cref="VisualElement"/> is not null and if <paramref
        /// name="visibilityPercentage"/> is lower than 1.
        ///
        /// Will return null if provided <see cref="VisualElement"/> is null of if <paramref
        /// name="visibilityPercentage"/> is greater than or equal to 1.
        /// </returns>
        public PathGeometry? GetPieClipFromTopPathGeometry(float visibilityPercentage, SweepDirection sweepDirection)
        {
            visibilityPercentage = visibilityPercentage.Between(0, 1);

            if (visualElement is not null && visibilityPercentage < 1)
            {
                // Center the clipping disk on the center of visual element and use its diagonal as radius
                var center = new PointF((float)visualElement.Width / 2f, (float)visualElement.Height / 2f);
                var radius = Math.Sqrt(Math.Pow(center.X, 2) + Math.Pow(center.Y, 2));

                // Compute position of the end of the arc, regarding the visibility percentage
                var angle = visibilityPercentage * 2 * Math.PI
                            * (sweepDirection == SweepDirection.Clockwise ? 1 : -1);
                var arcEnd = new Point(center.X + radius * Math.Sin(angle),
                                       center.Y - radius * Math.Cos(angle));

                // Create a PathFigure that starts from the center, go to the top, go to the end of
                // the arc and finally go back to the center
                var pathFigure = new PathFigure { StartPoint = center, IsClosed = true };
                pathFigure.Segments.Add(new LineSegment(new Point(center.X, center.Y - radius)));
                pathFigure.Segments.Add(new ArcSegment(arcEnd, new Size(radius, radius), 0, sweepDirection, visibilityPercentage > 0.5));

                // Return clipping PathFigure
                return new PathGeometry([pathFigure]);
            }
            else

                // No clipping if the visibility percentage is 100% or if there is no element to
                // evaluate clipping for
                return null;
        }
    }
}
