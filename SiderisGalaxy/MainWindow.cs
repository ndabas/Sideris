#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Sideris.SiderisServer;

#endregion

namespace Sideris.SiderisGalaxy
{
    partial class MainWindow : Form
    {
        Server server;
        string virtualDir = "/SiderisServer";
        string physicalDir;

        public MainWindow()
        {
            InitializeComponent();


            panel1.BackColor = ProfessionalColors.ToolStripGradientEnd;
            panel2.BackColor = ProfessionalColors.ToolStripGradientEnd;

            physicalDir = Application.ExecutablePath;
            physicalDir = physicalDir.Substring(0, physicalDir.LastIndexOf('\\'));
            physicalDir += "\\SiderisServer";
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if(!Directory.Exists(physicalDir))
            {
                MessageBox.Show("The Sideris Server files are missing.",
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(server == null)
            {
                server = new Server((int) portNumericUpDown.Value,
                    virtualDir, physicalDir, null);
            }
            
            server.Start();

            statusLabel.Text = "Started";
            startButton.Enabled = false;
            portNumericUpDown.ReadOnly = true;
            stopButton.Enabled = true;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if(server != null)
            {
                server.Stop();
            }

            statusLabel.Text = "Stopped";
            startButton.Enabled = true;
            portNumericUpDown.ReadOnly = false;
            stopButton.Enabled = false;
        }


        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            Rectangle rect = pevent.ClipRectangle;
            LinearGradientBrush brush = new LinearGradientBrush(rect,
                ProfessionalColors.MenuStripGradientBegin,
                ProfessionalColors.MenuStripGradientEnd,
                0.0f);

            pevent.Graphics.FillRectangle(brush, rect);
        }

    }
}