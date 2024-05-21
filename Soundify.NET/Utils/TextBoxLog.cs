using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundify.NET.Utils
{
    internal class TextBoxLog(RichTextBox output) : TextWriter
    {
        private readonly RichTextBox RTBOutput = output;
        private readonly StringWriter Stringwriter = new();

        public override void Write(char value)
        {
            base.Write(value);
            Stringwriter.Write(value);
            UpdateTextBox(value.ToString(), RTBOutput.ForeColor);
        }

        public override void Write(string value)
        {
            base.Write(value);
            Stringwriter.Write(value);
            UpdateTextBox(value, RTBOutput.ForeColor);
        }

        public override Encoding Encoding => Encoding.UTF8;

        public void Write(string value, Color color)
        {
            Stringwriter.Write(value);
            UpdateTextBox(value, color);
        }

        private void UpdateTextBox(string text, Color color)
        {
            if (RTBOutput.InvokeRequired)
            {
                RTBOutput.Invoke(new Action<string, Color>(UpdateTextBox), [text, color]);
            }
            else
            {
                int start = RTBOutput.TextLength;
                RTBOutput.AppendText(text);
                int end = RTBOutput.TextLength;

                RTBOutput.Select(start, end - start);
                RTBOutput.SelectionColor = color;
                RTBOutput.SelectionLength = 0;

                RTBOutput.SelectionStart = RTBOutput.Text.Length;
                RTBOutput.ScrollToCaret();
            }
        }
    }
}
