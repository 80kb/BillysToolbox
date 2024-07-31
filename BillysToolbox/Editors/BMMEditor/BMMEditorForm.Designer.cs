namespace BillysToolbox.Editors
{
    partial class BMMEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BMMEditorForm));
            miiHeadGroupBox = new GroupBox();
            panel1 = new Panel();
            textureSGroupBox = new GroupBox();
            label1 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            groupBox1 = new GroupBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            colorDialog1 = new ColorDialog();
            miiHeadGroupBox.SuspendLayout();
            textureSGroupBox.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // miiHeadGroupBox
            // 
            miiHeadGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            miiHeadGroupBox.Controls.Add(panel1);
            miiHeadGroupBox.Location = new Point(12, 12);
            miiHeadGroupBox.Name = "miiHeadGroupBox";
            miiHeadGroupBox.Size = new Size(327, 157);
            miiHeadGroupBox.TabIndex = 0;
            miiHeadGroupBox.TabStop = false;
            miiHeadGroupBox.Text = "Mii Head Color";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Location = new Point(6, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(315, 129);
            panel1.TabIndex = 0;
            panel1.Click += panel1_Click;
            // 
            // textureSGroupBox
            // 
            textureSGroupBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textureSGroupBox.Controls.Add(label1);
            textureSGroupBox.Controls.Add(textBox2);
            textureSGroupBox.Controls.Add(label2);
            textureSGroupBox.Controls.Add(textBox1);
            textureSGroupBox.Location = new Point(12, 175);
            textureSGroupBox.Name = "textureSGroupBox";
            textureSGroupBox.Size = new Size(327, 83);
            textureSGroupBox.TabIndex = 1;
            textureSGroupBox.TabStop = false;
            textureSGroupBox.Text = "Texture S Transform";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 54);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 2;
            label1.Text = "Scale";
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Location = new Point(76, 51);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(245, 23);
            textBox2.TabIndex = 1;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 25);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 3;
            label2.Text = "Translation";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(76, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(245, 23);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Location = new Point(12, 264);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(327, 83);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Texture T Transform";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 54);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 2;
            label3.Text = "Scale";
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox3.Location = new Point(76, 51);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(245, 23);
            textBox3.TabIndex = 1;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 25);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 3;
            label4.Text = "Translation";
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox4.Location = new Point(76, 22);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(245, 23);
            textBox4.TabIndex = 0;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // BMMEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 357);
            Controls.Add(groupBox1);
            Controls.Add(textureSGroupBox);
            Controls.Add(miiHeadGroupBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "BMMEditorForm";
            Text = "BMM Editor";
            Load += BMMEditorForm_Load;
            miiHeadGroupBox.ResumeLayout(false);
            textureSGroupBox.ResumeLayout(false);
            textureSGroupBox.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox miiHeadGroupBox;
        private Panel panel1;
        private GroupBox textureSGroupBox;
        private TextBox textBox1;
        private Label label1;
        private TextBox textBox2;
        private Label label2;
        private GroupBox groupBox1;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox4;
        private ColorDialog colorDialog1;
    }
}