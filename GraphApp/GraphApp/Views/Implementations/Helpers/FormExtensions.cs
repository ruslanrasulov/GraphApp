using System;
using System.Windows.Forms;

namespace GraphApp.Views.Implementations.Helpers
{
    public static class FormExtensions
    {
        public static float? TryGetFloat(this TextBox textBox, Action infoAction, Action warningAction)
        {
            var text = textBox.Text;

            if (string.IsNullOrEmpty(text))
            {
                infoAction();

                return null;
            }

            if (float.TryParse(text, out var number))
            {
                return number;
            }
            
            warningAction();

            return null;
        }

        public static int? TryGetInt32(this TextBox textBox, Action infoAction, Action warningAction)
        {
            var text = textBox.Text;

            if (string.IsNullOrEmpty(text))
            {
                infoAction();

                return null;
            }

            if (int.TryParse(text, out var number))
            {
                return number;
            }
            
            warningAction();

            return null;
        }
    }
}