#region Using directives

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#endregion

namespace Sideris
{
    partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Sideris.Properties.Settings.Value.Save();
        }

        private void sharedFolderTextBox_Validating(object sender, CancelEventArgs e)
        {
            if(!Directory.Exists(sharedFolderTextBox.Text))
            {
                MessageBox.Show(
                    "The specified share directory does not exist.",
                    Application.ProductName, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void browseButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                sharedFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void browseButton2_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                downloadFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}