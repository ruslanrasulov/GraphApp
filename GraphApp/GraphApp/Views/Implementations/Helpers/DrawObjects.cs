using System.Drawing;

namespace GraphApp.Views.Implementations.Helpers
{
    public static class DrawObjects
    {
        public static Pen Pen =>
            new Pen(Brush, Constants.PenSize);

        public static Brush Brush
            => Brushes.Black;
    }
}