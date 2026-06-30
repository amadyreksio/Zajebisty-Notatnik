using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Zajebisty_Notatnik
{
    public partial class Form1 : Form
    {

        bool FileChanged = false;
        string currentFile = null;

        
        const int EM_GETFIRSTVISIBLELINE = 0x00CE;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(
            IntPtr hWnd,
            int msg,
            IntPtr wParam,
            IntPtr lParam);



        const int EM_GETLINECOUNT = 0x00BA;


        private static int GetLineCount(System.Windows.Forms.TextBox tb)
        {
            return SendMessage(tb.Handle, EM_GETLINECOUNT, IntPtr.Zero, IntPtr.Zero).ToInt32();
        }

        private static int GetFirstVisibleLine(System.Windows.Forms.TextBox tb)
        {
            return SendMessage(
                tb.Handle,
                EM_GETFIRSTVISIBLELINE,
                IntPtr.Zero,
                IntPtr.Zero).ToInt32();
        }

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Find find;
        GotoLine gotoline;
        Font UIFont;
        SettingsForm settings;
        public void RefreshTheme()
        {
            
            switch (Utils.AppTheme)
            {
                case Utils.Theme.Light:
                    this.BackColor = SystemColors.Control;
                    TextField.BackColor= SystemColors.Window;
                    linecounter.BackColor = SystemColors.Control;
                    linecounter.Invalidate();
                    TextField.ForeColor= SystemColors.WindowText;
                    menuStrip1.BackColor= SystemColors.Control;
                    foreach (ToolStripItem it in menuStrip1.Items)
                    {
                        it.BackColor = SystemColors.Control;
                        it.ForeColor = SystemColors.ControlText;

                        if (it is ToolStripDropDownItem dropDown)
                        {
                            foreach (ToolStripItem itt in dropDown.DropDownItems)
                            {
                                itt.BackColor = SystemColors.Control;
                                itt.ForeColor = SystemColors.ControlText;
                            }
                        }
                    }

                    break;
                case Utils.Theme.Dark:
                    this.BackColor = Color.FromArgb(32,32,32);
                    TextField.BackColor = Color.FromArgb(40,40,40);
                    linecounter.BackColor = Color.FromArgb(32,32,32);
                    linecounter.Invalidate();
                    TextField.ForeColor = SystemColors.Window;
                    menuStrip1.BackColor= Color.FromArgb(32,32,32);
                    
                    foreach (ToolStripItem it in menuStrip1.Items)
                    {

                        it.BackColor = Color.FromArgb(32,32,32);
                        it.ForeColor = SystemColors.Window;

                        if (it is ToolStripDropDownItem dropDown)
                        {
                            foreach (ToolStripItem itt in dropDown.DropDownItems)
                            {
                                itt.BackColor = Color.FromArgb(32,32,32);
                                itt.ForeColor = SystemColors.Window;
                            }
                        }
                    }

                    break;

                default:break;
            }
        }
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            int useDark = (Utils.AppTheme==Utils.Theme.Dark?1:0);
            DwmSetWindowAttribute(this.Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref useDark, sizeof(int));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] args = System.Environment.GetCommandLineArgs();
            if (args.Length == 2)
            {
                if (System.IO.File.Exists(args[1]))
                {
                    try { 
                        string filePath = args[1];
                        TextField.Text=System.IO.File.ReadAllText(filePath);
                        currentFile = filePath;
                        FileChanged=false;
                        TextField.Select(0, 0);
                    }
                    catch {
                        ThrowError("Tried to read a non-text file");
                        TextField.Text = "";

                    }
                } 
            }
            if (System.IO.File.Exists(Path.Combine(Application.StartupPath, "font.amady")))
            {
                try { 
                string s = System.IO.File.ReadAllText(Path.Combine(Application.StartupPath, "font.amady"));
                if (!string.IsNullOrEmpty(s))
                {
                    var fc = new FontConverter();
                    Font f = fc.ConvertFromString(s) as Font;
                    if (f != null)
                    {
                        TextField.Font = f;
                    }
                }
                }
                catch { }

            }
                about = new AboutForm();
            UIFont= new Font("Segoe UI", 16); 
            Utils.MainForm = this;
            find = new Find();
            gotoline = new GotoLine();
            settings=new SettingsForm();
            TextField.TextChanged += (s, ee) => CheckScroll();
            TextField.KeyUp += (s, ee) => CheckScroll();
            TextField.MouseUp += (s, ee) => CheckScroll();
            this.FormClosing += Form1_FormClosing;
            RefreshTheme();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FileChanged)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to save unsaved changes?", "Zajebisty notatnik", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    var sfd = new SaveFileDialog();
                    sfd.Filter = ".txt files|*.txt|All files|*.*";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            System.IO.File.WriteAllText(sfd.FileName, TextField.Text);
                            currentFile = sfd.FileName;
                            FileChanged = false;
                        }
                        catch
                        {
                            ThrowError("Error while saving a file");
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }else if(dialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        public void updateLineCounter()
        {

            linecounter.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int first = GetFirstVisibleLine(TextField);
            int lineHeight = TextRenderer.MeasureText(
    "A",
    TextField.Font,
    new Size(int.MaxValue, int.MaxValue),
    TextFormatFlags.NoPadding
).Height;

            int visibleCount = TextField.ClientSize.Height / lineHeight + 1;
            Color pencolor = Color.FromArgb(32,32,32);
            if (Utils.AppTheme == Utils.Theme.Dark)
            {
                pencolor = SystemColors.Window;
            }
            using (Pen pen = new Pen(Color.Gray, 2))
            {
                using (Brush brush = new SolidBrush(pencolor))
                {
                    for (int i = 0; i < visibleCount; i++)
                    {
                        int lineNumber = first + i + 1;
                        int y = i * lineHeight;

                        e.Graphics.DrawString(
                            lineNumber.ToString(),
                            TextField.Font,
                            brush,
                            0,
                            y
                        );
                    }
                    linecounter.Width = (int)e.Graphics.MeasureString((visibleCount + first).ToString(), TextField.Font).Width;
                    e.Graphics.DrawLine(pen, linecounter.Width, 0, linecounter.Width, linecounter.Height);
                }
            }

        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            const int WM_VSCROLL = 0x0115;
            const int WM_MOUSEWHEEL = 0x020A;
            const int WM_KEYDOWN = 0x0100;
            const int WM_LBUTTONUP = 0x0202;
            const int WM_SIZE = 0x0005;

            if (m.Msg == WM_VSCROLL ||
                m.Msg == WM_MOUSEWHEEL ||
                m.Msg == WM_KEYDOWN ||
                m.Msg == WM_LBUTTONUP ||
                m.Msg == WM_SIZE)
            {
                CheckScroll();
            }

        }
        private int _lastFirstLine = -1;
        private void CheckScroll()
        {
            int first = GetFirstVisibleLine(TextField);

            if (first != _lastFirstLine)
            {
                _lastFirstLine = first;
                linecounter.Invalidate();
            }
        }
        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateLineCounter();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckScroll();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = ".txt files|*.txt|All files|*.*";
            ofd.Title = "Open a file";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (System.IO.File.Exists(ofd.FileName))
                    {
                        TextField.Clear();
                        TextField.Text = System.IO.File.ReadAllText(ofd.FileName);
                        FileChanged = false;
                        currentFile = ofd.FileName;
                    }
                    else
                    {
                        MessageBox.Show("The file doesnt exist", "Zajebisty Notatnik - file reader", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    ThrowError("Error while reading a file");


                }
            }
        }

        void ThrowError(string ErrorMessage)
        {
            MessageBox.Show("An error has occured.\n======================================\n" + ErrorMessage + "======================================\n", "Zajebisty Notatnik - error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }
        void Save()
        {
            if (!string.IsNullOrEmpty(currentFile))
            {
                try
                {
                    System.IO.File.WriteAllText(currentFile, TextField.Text);
                    FileChanged = false;
                }
                catch
                {
                    ThrowError("Error while saving a file");
                }
            }
            else
            {
                SaveAs();
            }
        }
        void SaveAs()
        {
            var sfd = new SaveFileDialog();
            sfd.Title = "Saving as";
            sfd.Filter = ".txt files|*.txt|All files|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllText(sfd.FileName, TextField.Text);
                    currentFile = sfd.FileName;
                    FileChanged = false;
                }
                catch
                {
                    ThrowError("Error while saving a file");
                }
            }
        }
        private void TextField_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextField.Text))
                FileChanged = true;
            else
                FileChanged = false;
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
        }

       
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!find.Visible) find.Show();               
                find.init(TextField, Utils.FindMode.Find);

                find.Show();
                find.BringToFront();
            
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!find.Visible) find.Show();
            find.init(TextField, Utils.FindMode.Replace);

            find.Show();
            find.BringToFront();
        }

        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!find.Visible) find.Show();
            find.init(TextField, Utils.FindMode.Find);

            find.Show();
            find.BringToFront();
            if (!string.IsNullOrEmpty(find.phrasetb.Text))
            {
                find.findbtn.PerformClick();
            }
        }

        private void goToLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gotoline.Show();
            gotoline.BringToFront();
        }

        private void dateAndTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextField.SelectedText = DateTime.Now.ToString();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fd = new FontDialog();
            fd.Font = TextField.Font;
            if(fd.ShowDialog() == DialogResult.OK)
            {
                TextField.Font=fd.Font;
                linecounter.Invalidate();
            }
            try { 
            var cvt = new FontConverter();
            string s = cvt.ConvertToString(TextField.Font);
            
            System.IO.File.WriteAllText(Path.Combine(Application.StartupPath, "font.amady"), s);
            } catch {
                ThrowError("Font convertion has failed.");
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            linecounter.Invalidate();
        }

        private void TextField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Back)
            {
                DeletePreviousWord();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }else if (e.Control && e.KeyCode == Keys.Delete)
            {
                DeleteNextWord();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
        private void DeletePreviousWord()
        {
            var tb = TextField;

            int pos = tb.SelectionStart;
            if (pos <= 0) return;

            string text = tb.Text;

            int end = pos;

            int start = pos - 1;

            while (start > 0 && char.IsWhiteSpace(text[start]))
                start--;

            while (start > 0 && !char.IsWhiteSpace(text[start - 1]))
                start--;

            tb.Text = text.Remove(start, end - start);
            tb.SelectionStart = start;
        }
        private void DeleteNextWord()
        {
            var tb = TextField;

            int pos = tb.SelectionStart;
            string text = tb.Text;

            if (pos >= text.Length) return;

            int start = pos;

            while (start < text.Length && char.IsWhiteSpace(text[start]))
                start++;

            int end = start;

            while (end < text.Length && !char.IsWhiteSpace(text[end]))
                end++;

            tb.Text = text.Remove(pos, end - pos);
            tb.SelectionStart = pos;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.ShowDialog();
        }
        AboutForm about;
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about.Show();
        }
    }
}
