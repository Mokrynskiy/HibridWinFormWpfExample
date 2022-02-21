using HibridWinFormWpfExample.WpfViews;
using System;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace HibridWinFormWpfExample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {            
            ElementHost host = new ElementHost();
            host.Dock = DockStyle.Fill;
            TasksView taskView = new TasksView();
            host.Child = taskView;           
            Controls.Add(host);
        }
    }
}
