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
    public partial class SearchView : UserControl
    {
        public SearchView()
        {
            InitializeComponent();
        }

        internal TransfersView transfersView;

        public void Search(string text)
        {
            SearchTab tab = new SearchTab(text);
            TabPage page = new TabPage(text);

            page.Controls.Add(tab);
            tab.Dock = DockStyle.Fill;
            tab.transfersView = transfersView;

            searchesTabControl.TabPages.Add(page);
            searchesTabControl.SelectedTab = page;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if(searchButton.Text.Length > 0)
            {
                Search(searchTextBox.Text);
            }
        }

        private void searchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                searchButton_Click(sender, e);
            }
        }
    }
}
