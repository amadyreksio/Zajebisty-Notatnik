using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zajebisty_Notatnik
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utils.AppTheme=(Utils.Theme)comboBox1.SelectedIndex;
            Utils.MainForm.RefreshTheme();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = (int)Utils.AppTheme;
        }
    }
}
