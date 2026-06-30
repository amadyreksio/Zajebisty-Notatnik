namespace Zajebisty_Notatnik
{
    partial class Find
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Find));
            this.phrasetb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.casesenscb = new System.Windows.Forms.CheckBox();
            this.wordscb = new System.Windows.Forms.CheckBox();
            this.findbtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.replacetb2 = new System.Windows.Forms.TextBox();
            this.replacetb1 = new System.Windows.Forms.TextBox();
            this.replacenextbtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // phrasetb
            // 
            this.phrasetb.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.phrasetb.Location = new System.Drawing.Point(68, 21);
            this.phrasetb.Name = "phrasetb";
            this.phrasetb.Size = new System.Drawing.Size(341, 31);
            this.phrasetb.TabIndex = 0;
            this.phrasetb.TextChanged += new System.EventHandler(this.phrasetb_TextChanged);
            this.phrasetb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phrasetb_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Text to find:";
            // 
            // casesenscb
            // 
            this.casesenscb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.casesenscb.AutoSize = true;
            this.casesenscb.Location = new System.Drawing.Point(3, 8);
            this.casesenscb.Name = "casesenscb";
            this.casesenscb.Size = new System.Drawing.Size(94, 17);
            this.casesenscb.TabIndex = 2;
            this.casesenscb.Text = "Case-sensitive";
            this.casesenscb.UseVisualStyleBackColor = true;
            // 
            // wordscb
            // 
            this.wordscb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.wordscb.AutoSize = true;
            this.wordscb.Location = new System.Drawing.Point(112, 8);
            this.wordscb.Name = "wordscb";
            this.wordscb.Size = new System.Drawing.Size(105, 17);
            this.wordscb.TabIndex = 3;
            this.wordscb.Text = "Search by words";
            this.wordscb.UseVisualStyleBackColor = true;
            this.wordscb.Visible = false;
            // 
            // findbtn
            // 
            this.findbtn.Location = new System.Drawing.Point(334, 58);
            this.findbtn.Name = "findbtn";
            this.findbtn.Size = new System.Drawing.Size(75, 23);
            this.findbtn.TabIndex = 4;
            this.findbtn.Text = "Find";
            this.findbtn.UseVisualStyleBackColor = true;
            this.findbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(425, 186);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.phrasetb);
            this.tabPage1.Controls.Add(this.findbtn);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(417, 160);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Find";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.replacetb2);
            this.tabPage2.Controls.Add(this.replacetb1);
            this.tabPage2.Controls.Add(this.replacenextbtn);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(417, 160);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Replace";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(234, 102);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Replace All";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Replace with:";
            // 
            // replacetb2
            // 
            this.replacetb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.replacetb2.Location = new System.Drawing.Point(84, 65);
            this.replacetb2.Name = "replacetb2";
            this.replacetb2.Size = new System.Drawing.Size(325, 31);
            this.replacetb2.TabIndex = 8;
            this.replacetb2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.replacetb2_KeyDown);
            // 
            // replacetb1
            // 
            this.replacetb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.replacetb1.Location = new System.Drawing.Point(84, 20);
            this.replacetb1.Name = "replacetb1";
            this.replacetb1.Size = new System.Drawing.Size(325, 31);
            this.replacetb1.TabIndex = 5;
            // 
            // replacenextbtn
            // 
            this.replacenextbtn.Location = new System.Drawing.Point(315, 102);
            this.replacenextbtn.Name = "replacenextbtn";
            this.replacenextbtn.Size = new System.Drawing.Size(94, 23);
            this.replacenextbtn.TabIndex = 7;
            this.replacenextbtn.Text = "Replace Next";
            this.replacenextbtn.UseVisualStyleBackColor = true;
            this.replacenextbtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Text to find:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.wordscb);
            this.panel1.Controls.Add(this.casesenscb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 186);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 37);
            this.panel1.TabIndex = 6;
            // 
            // Find
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 223);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Find";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find and replace";
            this.Load += new System.EventHandler(this.Find_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox casesenscb;
        private System.Windows.Forms.CheckBox wordscb;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox replacetb2;
        private System.Windows.Forms.TextBox replacetb1;
        private System.Windows.Forms.Button replacenextbtn;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox phrasetb;
        public System.Windows.Forms.Button findbtn;
    }
}