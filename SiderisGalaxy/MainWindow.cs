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

namespace Sideris.SiderisGalaxy
{
    partial class MainWindow : Form
    {
        Server server;
        string virtualDir = "/SiderisStellar";
        string physicalDir;

        public MainWindow()
        {
            InitializeComponent();
            
            physicalDir = Directory.GetParent(Path.GetDirectoryName(Application.ExecutablePath)).FullName;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if(!File.Exists(Path.Combine(physicalDir, "SiderisService.asmx")))
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
            portNumericUpDown.Enabled = false;
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
            portNumericUpDown.Enabled = true;
            stopButton.Enabled = false;
        }

    }
}