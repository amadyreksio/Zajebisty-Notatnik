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
    public partial class Find : Form
    {
        //TextBox TextField;
        private Utils.FindMode _mode;
        public Utils.FindMode MODE { get { return _mode; } }
        public Find()
        {
            InitializeComponent();
        }


        public void RefreshTheme()
        {

            switch (Utils.AppTheme)
            {
                case Utils.Theme.Light:
                    this.BackColor = SystemColors.Control;
                    panel1.BackColor = SystemColors.Control;
                    

                    break;
                case Utils.Theme.Dark:
                    this.BackColor = Color.FromArgb(32, 32, 32);
                    panel1.BackColor = Color.FromArgb(32, 32, 32);
                    tabPage1.BackColor = Color.FromArgb(40, 40, 40);
                    tabPage2.BackColor = Color.FromArgb(40, 40, 40);




                    break;

                default: break;
            }
        }
        private void Find_Load(object sender, EventArgs e)
        {
            
            //RefreshTheme();
            phrasetb.Focus();
            this.FormClosing+= (s, ee) => {
                ee.Cancel = true;
                this.Hide();
            };
            this.Shown += (s, ee) => { 
                lastfindpos = 0;
            };
        }
        public void init(TextBox textbox, Utils.FindMode Mode)
        {
            //TextField = textbox;
            _mode=Mode;
            tabControl1.SelectTab((Mode == Utils.FindMode.Find ? 0 : 1));
            if (Mode == Utils.FindMode.Find)
            {
                phrasetb.Focus();
            }
            else
            {
                replacetb1.Focus();
            }
        }
        int lastfindpos = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(phrasetb.Text)) return;
            find(phrasetb.Text);
        }
        void find(string phrase)
        {
            Utils.MainForm.TextField.Select(0, 0);
            int matchedlength = 0;
            if (lastfindpos >= Utils.MainForm.TextField.Text.Length) lastfindpos = 0;
            for (int i = lastfindpos; i < Utils.MainForm.TextField.Text.Length; i++)
            {
                if (i == Utils.MainForm.TextField.Text.Length&&phrase.Length == 1 && ((!casesenscb.Checked&& Utils.MainForm.TextField.Text[i].ToString().ToLower() == phrase[0].ToString().ToLower()) ||(casesenscb.Checked&&Utils.MainForm.TextField.Text[i] == phrase[0]))){
                    Utils.MainForm.TextField.Select(i, 1);
                    return;
                }
                if ((casesenscb.Checked&&Utils.MainForm.TextField.Text[i] == phrase[matchedlength])||(!casesenscb.Checked&& Utils.MainForm.TextField.Text[i].ToString().ToLower() == phrase[matchedlength].ToString().ToLower()))
                {
                    matchedlength++;
                    if (matchedlength == phrase.Length)
                    {
                        //znalezono
                        Utils.MainForm.TextField.Select(i - matchedlength+1, matchedlength);
                        Utils.MainForm.TextField.ScrollToCaret();
                        lastfindpos = i+1;
                        return;
                    }
                }
                else
                {
                    matchedlength = 0;
                }
               
                
            }
            lastfindpos = 0;
        }

        private void phrasetb_TextChanged(object sender, EventArgs e)
        {
            lastfindpos=0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(replacetb1.Text)) return;

            if (casesenscb.Checked) { 
                Utils.MainForm.TextField.Text = Utils.MainForm.TextField.Text.Replace(replacetb1.Text, replacetb2.Text);
            }
            else
            {
                string source = Utils.MainForm.TextField.Text;
                string find = replacetb1.Text;
                string replace = replacetb2.Text;

                StringComparison cmp = casesenscb.Checked
                    ? StringComparison.CurrentCulture
                    : StringComparison.CurrentCultureIgnoreCase;

                int index = 0;

                while ((index = source.IndexOf(find, index, cmp)) != -1)
                {
                    source = source.Remove(index, find.Length)
                                   .Insert(index, replace);

                    index += replace.Length;
                }

                Utils.MainForm.TextField.Text = source;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            find(replacetb1.Text);
            Utils.MainForm.TextField.SelectedText = replacetb2.Text;
        }

        private void phrasetb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                findbtn.PerformClick();
            }
        }

        private void replacetb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { 
                replacenextbtn.PerformClick();
            }
        }
    }
}
