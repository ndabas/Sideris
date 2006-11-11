#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

#endregion

namespace Sideris
{
    public partial class SharesView : UserControl
    {
        private FilesDataSet.SharesDataTable shares;

        public SharesView(FilesDataSet files)
        {
            InitializeComponent();

            this.shares = files.Shares;
        }

        public void UpdateView()
        {
            if(listView.InvokeRequired)
            {
                listView.Invoke(new MethodInvoker(this.UpdateView));
                return;
            }

            listView.Items.Clear();
            foreach(FilesDataSet.SharesRow row in shares.Rows)
            {
                listView.Items.Add(row.FullName);
            }
        }

    }
}
