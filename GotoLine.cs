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
    public partial class GotoLine : Form
    {
        public GotoLine()
        {
            InitializeComponent();
        }

        private void GotoLine_Load(object sender, EventArgs e)
        {
            this.Shown += GotoLine_Shown;
            this.FormClosing += GotoLine_FormClosing;
        }

        private void GotoLine_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void GotoLine_Shown(object sender, EventArgs e)
        {
            numericUpDown1.Focus();
            numericUpDown1.Maximum = Utils.MainForm.TextField.Lines.Length;
            numericUpDown1.Select(0, 1);

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int line = (int)numericUpDown1.Value;

            if (line >= 0 && line < Utils.MainForm.TextField.Lines.Length)
            {
                int index = Utils.MainForm.TextField.GetFirstCharIndexFromLine(line-1);
                Utils.MainForm.TextField.Select(index, 0);
                Utils.MainForm.TextField.ScrollToCaret();
            }
        }
    }
}
