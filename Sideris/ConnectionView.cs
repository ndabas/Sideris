#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

#endregion

namespace Sideris
{
    public partial class ConnectionView : UserControl
    {
        public ConnectionView()
        {
            InitializeComponent();
        }

        private delegate void AppendToLogInvoker(string message,
            Color color);

        public void AppendToLog(string message, Color color)
        {
            if(logRichTextBox.InvokeRequired)
            {
                logRichTextBox.Invoke(
                    new AppendToLogInvoker(this.AppendToLog),
                    message, color);
                return;
            }

            if(color != null)
            {
                logRichTextBox.SelectionColor = color;
            }
            logRichTextBox.AppendText(message + "\r\n");
        }

        public void ClearLog()
        {
            if(logRichTextBox.InvokeRequired)
            {
                logRichTextBox.Invoke(new MethodInvoker(this.ClearLog));
                return;
            }

            logRichTextBox.Text = String.Empty;
        }
    }
}
