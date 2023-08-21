using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace melakify.Automation.UI
{
    public static class Automation
    {
        public enum TrimMode
        {
            All,
            End,
            Start
        }

        public static void PlaceHolderAI(TextBox textbox, string placeHolderText)
        {
            if (textbox.Text.Length > 0)
            {
                textbox.Tag = "";
            }
            else
            {
                textbox.Tag = placeHolderText;
            }
        }

        public static void AITrim(TextBox textBox, string trims, TrimMode mode)
        {
            switch (mode)
            {
                case TrimMode.All:
                    textBox.Text = textBox.Text.Trim(trims.ToCharArray());
                    break;
                case TrimMode.End:
                    textBox.Text = textBox.Text.TrimEnd(trims.ToCharArray());
                    break;
                case TrimMode.Start:
                    textBox.Text = textBox.Text.TrimStart(trims.ToCharArray());
                    break;
                default:
                    textBox.Text = textBox.Text.Trim(trims.ToCharArray());
                    break;
            }
        }

        public static void AutoFlowDirection(TextBox textBox)
        {
            if (textBox.Text.StartsWith("ظ") || textBox.Text.StartsWith("ط") || textBox.Text.StartsWith("ز") || textBox.Text.StartsWith("ر") || textBox.Text.StartsWith("ذ") || textBox.Text.StartsWith("د") || textBox.Text.StartsWith("ئ") || textBox.Text.StartsWith("و") || textBox.Text.StartsWith("ش") || textBox.Text.StartsWith("س") || textBox.Text.StartsWith("ی") || textBox.Text.StartsWith("ب") || textBox.Text.StartsWith("ل") || textBox.Text.StartsWith("ا") || textBox.Text.StartsWith("آ") || textBox.Text.StartsWith("ت") || textBox.Text.StartsWith("ن") || textBox.Text.StartsWith("م") || textBox.Text.StartsWith("ک") || textBox.Text.StartsWith("گ") || textBox.Text.StartsWith("پ") || textBox.Text.StartsWith("ژ") || textBox.Text.StartsWith("ض") || textBox.Text.StartsWith("ص") || textBox.Text.StartsWith("ث") || textBox.Text.StartsWith("ق") || textBox.Text.StartsWith("ف") || textBox.Text.StartsWith("غ") || textBox.Text.StartsWith("ع") || textBox.Text.StartsWith("ه") || textBox.Text.StartsWith("خ") || textBox.Text.StartsWith("ح") || textBox.Text.StartsWith("ج") || textBox.Text.StartsWith("چ"))
            {
                textBox.FlowDirection = FlowDirection.RightToLeft;
            }
            else if (textBox.Text == "")
            {
                textBox.FlowDirection = FlowDirection.RightToLeft;
            }
            else
            {
                textBox.FlowDirection = FlowDirection.LeftToRight;
            }
        }

        public static void AutoFlowDirection(RichTextBox richTextBox, string textBox)
        {
            if (textBox.StartsWith("ظ") || textBox.StartsWith("ط") || textBox.StartsWith("ز") || textBox.StartsWith("ر") || textBox.StartsWith("ذ") || textBox.StartsWith("د") || textBox.StartsWith("ئ") || textBox.StartsWith("و") || textBox.StartsWith("ش") || textBox.StartsWith("س") || textBox.StartsWith("ی") || textBox.StartsWith("ب") || textBox.StartsWith("ل") || textBox.StartsWith("ا") || textBox.StartsWith("آ") || textBox.StartsWith("ت") || textBox.StartsWith("ن") || textBox.StartsWith("م") || textBox.StartsWith("ک") || textBox.StartsWith("گ") || textBox.StartsWith("پ") || textBox.StartsWith("ژ") || textBox.StartsWith("ض") || textBox.StartsWith("ص") || textBox.StartsWith("ث") || textBox.StartsWith("ق") || textBox.StartsWith("ف") || textBox.StartsWith("غ") || textBox.StartsWith("ع") || textBox.StartsWith("ه") || textBox.StartsWith("خ") || textBox.StartsWith("ح") || textBox.StartsWith("ج") || textBox.StartsWith("چ"))
            {
                richTextBox.FlowDirection = FlowDirection.RightToLeft;
            }
            else
            {
                richTextBox.FlowDirection = FlowDirection.LeftToRight;
            }
        }
    }
}
