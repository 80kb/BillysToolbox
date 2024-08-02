namespace BillysToolbox.Editors
{
    partial class BLIGHTEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLIGHTEditorForm));
            tabControl = new TabControl();
            lightObjectTab = new TabPage();
            splitContainer = new SplitContainer();
            lightObjectListBox = new ListBox();
            lightObjectPropertyGrid = new PropertyGrid();
            ambientLightTab = new TabPage();
            splitContainer1 = new SplitContainer();
            ambientLightListBox = new ListBox();
            ambientLightPropertyGrid = new PropertyGrid();
            tabControl.SuspendLayout();
            lightObjectTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            ambientLightTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(lightObjectTab);
            tabControl.Controls.Add(ambientLightTab);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(800, 450);
            tabControl.TabIndex = 0;
            // 
            // lightObjectTab
            // 
            lightObjectTab.Controls.Add(splitContainer);
            lightObjectTab.Location = new Point(4, 24);
            lightObjectTab.Name = "lightObjectTab";
            lightObjectTab.Padding = new Padding(3);
            lightObjectTab.Size = new Size(792, 422);
            lightObjectTab.TabIndex = 0;
            lightObjectTab.Text = "Light Objects";
            lightObjectTab.UseVisualStyleBackColor = true;
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(3, 3);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(lightObjectListBox);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(lightObjectPropertyGrid);
            splitContainer.Size = new Size(786, 416);
            splitContainer.SplitterDistance = 262;
            splitContainer.TabIndex = 0;
            // 
            // lightObjectListBox
            // 
            lightObjectListBox.Dock = DockStyle.Fill;
            lightObjectListBox.FormattingEnabled = true;
            lightObjectListBox.ItemHeight = 15;
            lightObjectListBox.Location = new Point(0, 0);
            lightObjectListBox.Name = "lightObjectListBox";
            lightObjectListBox.Size = new Size(262, 416);
            lightObjectListBox.TabIndex = 1;
            lightObjectListBox.SelectedIndexChanged += lightObjectListBox_SelectedIndexChanged;
            // 
            // lightObjectPropertyGrid
            // 
            lightObjectPropertyGrid.Dock = DockStyle.Fill;
            lightObjectPropertyGrid.Location = new Point(0, 0);
            lightObjectPropertyGrid.Name = "lightObjectPropertyGrid";
            lightObjectPropertyGrid.Size = new Size(520, 416);
            lightObjectPropertyGrid.TabIndex = 1;
            // 
            // ambientLightTab
            // 
            ambientLightTab.Controls.Add(splitContainer1);
            ambientLightTab.Location = new Point(4, 24);
            ambientLightTab.Name = "ambientLightTab";
            ambientLightTab.Padding = new Padding(3);
            ambientLightTab.Size = new Size(792, 422);
            ambientLightTab.TabIndex = 1;
            ambientLightTab.Text = "Ambient Lights";
            ambientLightTab.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(ambientLightListBox);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(ambientLightPropertyGrid);
            splitContainer1.Size = new Size(786, 416);
            splitContainer1.SplitterDistance = 262;
            splitContainer1.TabIndex = 0;
            // 
            // ambientLightListBox
            // 
            ambientLightListBox.Dock = DockStyle.Fill;
            ambientLightListBox.FormattingEnabled = true;
            ambientLightListBox.ItemHeight = 15;
            ambientLightListBox.Location = new Point(0, 0);
            ambientLightListBox.Name = "ambientLightListBox";
            ambientLightListBox.Size = new Size(262, 416);
            ambientLightListBox.TabIndex = 0;
            ambientLightListBox.SelectedIndexChanged += ambientLightListBox_SelectedIndexChanged;
            // 
            // ambientLightPropertyGrid
            // 
            ambientLightPropertyGrid.Dock = DockStyle.Fill;
            ambientLightPropertyGrid.Location = new Point(0, 0);
            ambientLightPropertyGrid.Name = "ambientLightPropertyGrid";
            ambientLightPropertyGrid.Size = new Size(520, 416);
            ambientLightPropertyGrid.TabIndex = 0;
            // 
            // BLIGHTEditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "BLIGHTEditorForm";
            Text = "BLIGHT Editor";
            tabControl.ResumeLayout(false);
            lightObjectTab.ResumeLayout(false);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ambientLightTab.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage lightObjectTab;
        private TabPage ambientLightTab;
        private SplitContainer splitContainer;
        private SplitContainer splitContainer1;
        private ListBox ambientLightListBox;
        private PropertyGrid ambientLightPropertyGrid;
        private ListBox lightObjectListBox;
        private PropertyGrid lightObjectPropertyGrid;
    }
}