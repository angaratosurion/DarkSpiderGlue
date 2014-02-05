using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DarkSpiderGlueControler
{
    public partial class frmGUI : Form
    {
        public frmGUI()
        {
            InitializeComponent();
        }

        private void frmGUI_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName;
            dataGridView1.Columns.Add("Service Name", "Service Name");
            dataGridView1.Columns.Add("Url", "URl");
            dataGridView1.Columns.Add("State", "State");

        }
    }
}
