namespace BillysToolbox.Editors
{
    partial class KCLEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KCLEditorForm));
            dataGridView = new DataGridView();
            flagComboBox = new ComboBox();
            variantComboBox = new ComboBox();
            flagGroupBox = new GroupBox();
            blightGroupBox = new GroupBox();
            blightComboBox = new ComboBox();
            depthGroupBox = new GroupBox();
            depthComboBox = new ComboBox();
            effectGroupBox = new GroupBox();
            softWallCheckBox = new CheckBox();
            rejectCheckBox = new CheckBox();
            trickCheckBox = new CheckBox();
            menuStrip1 = new MenuStrip();
            kCLEditorToolStripMenuItem = new ToolStripMenuItem();
            importOBJToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            lowerWallsToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            flagGroupBox.SuspendLayout();
            blightGroupBox.SuspendLayout();
            depthGroupBox.SuspendLayout();
            effectGroupBox.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(12, 12);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.ScrollBars = ScrollBars.Vertical;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(450, 283);
            dataGridView.TabIndex = 0;
            dataGridView.SelectionChanged += dataGridView_SelectionChanged;
            // 
            // flagComboBox
            // 
            flagComboBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flagComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            flagComboBox.FormattingEnabled = true;
            flagComboBox.Location = new Point(6, 22);
            flagComboBox.Name = "flagComboBox";
            flagComboBox.Size = new Size(154, 23);
            flagComboBox.TabIndex = 1;
            flagComboBox.SelectedIndexChanged += flagComboBox_SelectedIndexChanged;
            // 
            // variantComboBox
            // 
            variantComboBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            variantComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            variantComboBox.FormattingEnabled = true;
            variantComboBox.Location = new Point(166, 22);
            variantComboBox.Name = "variantComboBox";
            variantComboBox.Size = new Size(148, 23);
            variantComboBox.TabIndex = 2;
            variantComboBox.SelectedIndexChanged += variantComboBox_SelectedIndexChanged;
            // 
            // flagGroupBox
            // 
            flagGroupBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flagGroupBox.Controls.Add(flagComboBox);
            flagGroupBox.Controls.Add(variantComboBox);
            flagGroupBox.Location = new Point(12, 301);
            flagGroupBox.Name = "flagGroupBox";
            flagGroupBox.Size = new Size(320, 53);
            flagGroupBox.TabIndex = 3;
            flagGroupBox.TabStop = false;
            flagGroupBox.Text = "Flag";
            // 
            // blightGroupBox
            // 
            blightGroupBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            blightGroupBox.Controls.Add(blightComboBox);
            blightGroupBox.Location = new Point(12, 360);
            blightGroupBox.Name = "blightGroupBox";
            blightGroupBox.Size = new Size(154, 52);
            blightGroupBox.TabIndex = 4;
            blightGroupBox.TabStop = false;
            blightGroupBox.Text = "BLIGHT Index";
            // 
            // blightComboBox
            // 
            blightComboBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            blightComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            blightComboBox.FormattingEnabled = true;
            blightComboBox.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7" });
            blightComboBox.Location = new Point(6, 22);
            blightComboBox.Name = "blightComboBox";
            blightComboBox.Size = new Size(142, 23);
            blightComboBox.TabIndex = 0;
            blightComboBox.SelectedIndexChanged += blightComboBox_SelectedIndexChanged;
            // 
            // depthGroupBox
            // 
            depthGroupBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            depthGroupBox.Controls.Add(depthComboBox);
            depthGroupBox.Location = new Point(172, 360);
            depthGroupBox.Name = "depthGroupBox";
            depthGroupBox.Size = new Size(160, 52);
            depthGroupBox.TabIndex = 5;
            depthGroupBox.TabStop = false;
            depthGroupBox.Text = "Wheel Depth";
            // 
            // depthComboBox
            // 
            depthComboBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            depthComboBox.DisplayMember = "0";
            depthComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            depthComboBox.FormattingEnabled = true;
            depthComboBox.Items.AddRange(new object[] { "0", "1", "2", "3" });
            depthComboBox.Location = new Point(6, 22);
            depthComboBox.Name = "depthComboBox";
            depthComboBox.Size = new Size(148, 23);
            depthComboBox.TabIndex = 0;
            depthComboBox.SelectedIndexChanged += depthComboBox_SelectedIndexChanged;
            // 
            // effectGroupBox
            // 
            effectGroupBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            effectGroupBox.Controls.Add(softWallCheckBox);
            effectGroupBox.Controls.Add(rejectCheckBox);
            effectGroupBox.Controls.Add(trickCheckBox);
            effectGroupBox.Location = new Point(338, 301);
            effectGroupBox.Name = "effectGroupBox";
            effectGroupBox.Size = new Size(124, 111);
            effectGroupBox.TabIndex = 6;
            effectGroupBox.TabStop = false;
            effectGroupBox.Text = "Effect";
            // 
            // softWallCheckBox
            // 
            softWallCheckBox.AutoSize = true;
            softWallCheckBox.Location = new Point(6, 86);
            softWallCheckBox.Name = "softWallCheckBox";
            softWallCheckBox.Size = new Size(73, 19);
            softWallCheckBox.TabIndex = 2;
            softWallCheckBox.Text = "Soft Wall";
            softWallCheckBox.UseVisualStyleBackColor = true;
            softWallCheckBox.CheckedChanged += softWallCheckBox_CheckedChanged;
            // 
            // rejectCheckBox
            // 
            rejectCheckBox.AutoSize = true;
            rejectCheckBox.Location = new Point(6, 54);
            rejectCheckBox.Name = "rejectCheckBox";
            rejectCheckBox.Size = new Size(105, 19);
            rejectCheckBox.TabIndex = 1;
            rejectCheckBox.Text = "Rejection Road";
            rejectCheckBox.UseVisualStyleBackColor = true;
            rejectCheckBox.CheckedChanged += rejectCheckBox_CheckedChanged;
            // 
            // trickCheckBox
            // 
            trickCheckBox.AutoSize = true;
            trickCheckBox.Location = new Point(6, 22);
            trickCheckBox.Name = "trickCheckBox";
            trickCheckBox.Size = new Size(72, 19);
            trickCheckBox.TabIndex = 0;
            trickCheckBox.Text = "Trickable";
            trickCheckBox.UseVisualStyleBackColor = true;
            trickCheckBox.CheckedChanged += trickCheckBox_CheckedChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { kCLEditorToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(475, 24);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // kCLEditorToolStripMenuItem
            // 
            kCLEditorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importOBJToolStripMenuItem, toolStripSeparator1, lowerWallsToolStripMenuItem });
            kCLEditorToolStripMenuItem.MergeAction = MergeAction.Insert;
            kCLEditorToolStripMenuItem.MergeIndex = 1;
            kCLEditorToolStripMenuItem.Name = "kCLEditorToolStripMenuItem";
            kCLEditorToolStripMenuItem.Size = new Size(39, 20);
            kCLEditorToolStripMenuItem.Text = "Edit";
            // 
            // importOBJToolStripMenuItem
            // 
            importOBJToolStripMenuItem.Image = Properties.Resources.document_import;
            importOBJToolStripMenuItem.Name = "importOBJToolStripMenuItem";
            importOBJToolStripMenuItem.Size = new Size(189, 22);
            importOBJToolStripMenuItem.Text = "Import OBJ";
            importOBJToolStripMenuItem.Click += importOBJToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(186, 6);
            // 
            // lowerWallsToolStripMenuItem
            // 
            lowerWallsToolStripMenuItem.CheckOnClick = true;
            lowerWallsToolStripMenuItem.Image = Properties.Resources.ModuleScript;
            lowerWallsToolStripMenuItem.Name = "lowerWallsToolStripMenuItem";
            lowerWallsToolStripMenuItem.Size = new Size(189, 22);
            lowerWallsToolStripMenuItem.Text = "Lower walls on export";
            // 
            // KCLEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 422);
            Controls.Add(effectGroupBox);
            Controls.Add(depthGroupBox);
            Controls.Add(blightGroupBox);
            Controls.Add(flagGroupBox);
            Controls.Add(dataGridView);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(491, 461);
            Name = "KCLEditorForm";
            Text = "KCL Editor";
            Activated += KCLEditor_Activated;
            Deactivate += KCLEditor_Deactivate;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            flagGroupBox.ResumeLayout(false);
            blightGroupBox.ResumeLayout(false);
            depthGroupBox.ResumeLayout(false);
            effectGroupBox.ResumeLayout(false);
            effectGroupBox.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private ComboBox flagComboBox;
        private ComboBox variantComboBox;
        private GroupBox flagGroupBox;
        private GroupBox blightGroupBox;
        private ComboBox blightComboBox;
        private GroupBox depthGroupBox;
        private ComboBox depthComboBox;
        private GroupBox effectGroupBox;
        private CheckBox softWallCheckBox;
        private CheckBox rejectCheckBox;
        private CheckBox trickCheckBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem kCLEditorToolStripMenuItem;
        private ToolStripMenuItem importOBJToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem lowerWallsToolStripMenuItem;
    }
}