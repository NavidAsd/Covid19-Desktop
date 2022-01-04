using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Covid19_data
{
    public partial class Frmcountry : Form
    {

        public Frmcountry()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frmcountry_Load(object sender, EventArgs e)
        {
            bunifuTextbox1.Focus();
            bunifuDataGridView1.DataSource = countryData;
            if (bunifuDataGridView1.DataSource != null)
            {
                bunifuVScrollBar1.Maximum = countryData.Rows.Count;
            }
        }

        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                bunifuDataGridView1.FirstDisplayedScrollingRowIndex = e.Value;
            }
            catch { }
        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(bunifuTextbox1.text) || bunifuTextbox1.text != "Search country")
            {
                try
                {
                   countryData.DefaultView.RowFilter = string.Format("Name LIKE '{0}*'", bunifuTextbox1.text);
                }
                catch { }
            }
            //not working else
            else if (string.IsNullOrWhiteSpace(bunifuTextbox1.text) || bunifuTextbox1.text == "Search country")
            {
                bunifuDataGridView1.DataSource = countryData;
            }
            if (countryData.DefaultView.Count == 0)
            {
                bunifuVScrollBar1.Enabled = false;
            }
            else
            {
                bunifuVScrollBar1.Enabled = true;
                bunifuVScrollBar1.Maximum = countryData.DefaultView.Count;
            }
        }
        public DataTable countryData { set; get; }
        public string country0 { set; get; }
        public DialogResult result { set; get; }
        public void bunifuDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            country0=(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            result = DialogResult.OK;
            this.Close();
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
