namespace EliteExpeditionLog {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Expeditions = new System.Windows.Forms.ComboBox();
            this.ExpeditionLabel = new System.Windows.Forms.Label();
            this.VisitedSystemsLabel = new System.Windows.Forms.Label();
            this.VisitedSystemsGrid = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LogText = new System.Windows.Forms.RichTextBox();
            this.SystemLabel = new System.Windows.Forms.Label();
            this.XLabel = new System.Windows.Forms.Label();
            this.XText = new System.Windows.Forms.TextBox();
            this.YText = new System.Windows.Forms.TextBox();
            this.YLabel = new System.Windows.Forms.Label();
            this.ZText = new System.Windows.Forms.TextBox();
            this.ZLabel = new System.Windows.Forms.Label();
            this.Refuel = new System.Windows.Forms.CheckBox();
            this.Bookmark = new System.Windows.Forms.CheckBox();
            this.ObjectTypesList = new System.Windows.Forms.ListBox();
            this.ScannedObjectsList = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ObjectTypesLabel = new System.Windows.Forms.Label();
            this.ScannedObjectsLabel = new System.Windows.Forms.Label();
            this.analysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisitedSystemsGrid)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.analysisToolStripMenuItem,
            this.mapsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(396, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // Expeditions
            // 
            this.Expeditions.FormattingEnabled = true;
            this.Expeditions.Location = new System.Drawing.Point(9, 44);
            this.Expeditions.Name = "Expeditions";
            this.Expeditions.Size = new System.Drawing.Size(347, 21);
            this.Expeditions.TabIndex = 1;
            // 
            // ExpeditionLabel
            // 
            this.ExpeditionLabel.AutoSize = true;
            this.ExpeditionLabel.Location = new System.Drawing.Point(9, 28);
            this.ExpeditionLabel.Name = "ExpeditionLabel";
            this.ExpeditionLabel.Size = new System.Drawing.Size(61, 13);
            this.ExpeditionLabel.TabIndex = 2;
            this.ExpeditionLabel.Text = "Expeditions";
            // 
            // VisitedSystemsLabel
            // 
            this.VisitedSystemsLabel.AutoSize = true;
            this.VisitedSystemsLabel.Location = new System.Drawing.Point(9, 72);
            this.VisitedSystemsLabel.Name = "VisitedSystemsLabel";
            this.VisitedSystemsLabel.Size = new System.Drawing.Size(80, 13);
            this.VisitedSystemsLabel.TabIndex = 3;
            this.VisitedSystemsLabel.Text = "Visited Systems";
            // 
            // VisitedSystemsGrid
            // 
            this.VisitedSystemsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VisitedSystemsGrid.Location = new System.Drawing.Point(9, 89);
            this.VisitedSystemsGrid.Name = "VisitedSystemsGrid";
            this.VisitedSystemsGrid.Size = new System.Drawing.Size(378, 145);
            this.VisitedSystemsGrid.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(9, 240);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(3, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(382, 227);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ScannedObjectsLabel);
            this.tabPage1.Controls.Add(this.ObjectTypesLabel);
            this.tabPage1.Controls.Add(this.ScannedObjectsList);
            this.tabPage1.Controls.Add(this.ObjectTypesList);
            this.tabPage1.Controls.Add(this.Bookmark);
            this.tabPage1.Controls.Add(this.Refuel);
            this.tabPage1.Controls.Add(this.ZText);
            this.tabPage1.Controls.Add(this.ZLabel);
            this.tabPage1.Controls.Add(this.YText);
            this.tabPage1.Controls.Add(this.YLabel);
            this.tabPage1.Controls.Add(this.XText);
            this.tabPage1.Controls.Add(this.XLabel);
            this.tabPage1.Controls.Add(this.SystemLabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(374, 201);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "System Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(374, 201);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Trilateration";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // LogText
            // 
            this.LogText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogText.Location = new System.Drawing.Point(9, 473);
            this.LogText.Name = "LogText";
            this.LogText.Size = new System.Drawing.Size(378, 66);
            this.LogText.TabIndex = 6;
            this.LogText.Text = "";
            // 
            // SystemLabel
            // 
            this.SystemLabel.AutoSize = true;
            this.SystemLabel.Location = new System.Drawing.Point(7, 3);
            this.SystemLabel.Name = "SystemLabel";
            this.SystemLabel.Size = new System.Drawing.Size(41, 13);
            this.SystemLabel.TabIndex = 0;
            this.SystemLabel.Text = "System";
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.Location = new System.Drawing.Point(7, 27);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(14, 13);
            this.XLabel.TabIndex = 1;
            this.XLabel.Text = "X";
            // 
            // XText
            // 
            this.XText.Location = new System.Drawing.Point(21, 24);
            this.XText.Name = "XText";
            this.XText.Size = new System.Drawing.Size(45, 20);
            this.XText.TabIndex = 2;
            // 
            // YText
            // 
            this.YText.Location = new System.Drawing.Point(83, 24);
            this.YText.Name = "YText";
            this.YText.Size = new System.Drawing.Size(45, 20);
            this.YText.TabIndex = 4;
            // 
            // YLabel
            // 
            this.YLabel.AutoSize = true;
            this.YLabel.Location = new System.Drawing.Point(69, 27);
            this.YLabel.Name = "YLabel";
            this.YLabel.Size = new System.Drawing.Size(14, 13);
            this.YLabel.TabIndex = 3;
            this.YLabel.Text = "Y";
            // 
            // ZText
            // 
            this.ZText.Location = new System.Drawing.Point(147, 24);
            this.ZText.Name = "ZText";
            this.ZText.Size = new System.Drawing.Size(45, 20);
            this.ZText.TabIndex = 6;
            // 
            // ZLabel
            // 
            this.ZLabel.AutoSize = true;
            this.ZLabel.Location = new System.Drawing.Point(133, 27);
            this.ZLabel.Name = "ZLabel";
            this.ZLabel.Size = new System.Drawing.Size(14, 13);
            this.ZLabel.TabIndex = 5;
            this.ZLabel.Text = "Z";
            // 
            // Refuel
            // 
            this.Refuel.AutoSize = true;
            this.Refuel.Location = new System.Drawing.Point(210, 26);
            this.Refuel.Name = "Refuel";
            this.Refuel.Size = new System.Drawing.Size(57, 17);
            this.Refuel.TabIndex = 7;
            this.Refuel.Text = "Refuel";
            this.Refuel.UseVisualStyleBackColor = true;
            // 
            // Bookmark
            // 
            this.Bookmark.AutoSize = true;
            this.Bookmark.Location = new System.Drawing.Point(274, 26);
            this.Bookmark.Name = "Bookmark";
            this.Bookmark.Size = new System.Drawing.Size(74, 17);
            this.Bookmark.TabIndex = 8;
            this.Bookmark.Text = "Bookmark";
            this.Bookmark.UseVisualStyleBackColor = true;
            // 
            // ObjectTypesList
            // 
            this.ObjectTypesList.FormattingEnabled = true;
            this.ObjectTypesList.Location = new System.Drawing.Point(10, 69);
            this.ObjectTypesList.Name = "ObjectTypesList";
            this.ObjectTypesList.Size = new System.Drawing.Size(163, 121);
            this.ObjectTypesList.TabIndex = 9;
            // 
            // ScannedObjectsList
            // 
            this.ScannedObjectsList.FormattingEnabled = true;
            this.ScannedObjectsList.Location = new System.Drawing.Point(199, 69);
            this.ScannedObjectsList.Name = "ScannedObjectsList";
            this.ScannedObjectsList.Size = new System.Drawing.Size(169, 121);
            this.ScannedObjectsList.TabIndex = 10;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(374, 201);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "More";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ObjectTypesLabel
            // 
            this.ObjectTypesLabel.AutoSize = true;
            this.ObjectTypesLabel.Location = new System.Drawing.Point(10, 51);
            this.ObjectTypesLabel.Name = "ObjectTypesLabel";
            this.ObjectTypesLabel.Size = new System.Drawing.Size(70, 13);
            this.ObjectTypesLabel.TabIndex = 11;
            this.ObjectTypesLabel.Text = "Object Types";
            // 
            // ScannedObjectsLabel
            // 
            this.ScannedObjectsLabel.AutoSize = true;
            this.ScannedObjectsLabel.Location = new System.Drawing.Point(196, 51);
            this.ScannedObjectsLabel.Name = "ScannedObjectsLabel";
            this.ScannedObjectsLabel.Size = new System.Drawing.Size(89, 13);
            this.ScannedObjectsLabel.TabIndex = 12;
            this.ScannedObjectsLabel.Text = "Scanned Objects";
            // 
            // analysisToolStripMenuItem
            // 
            this.analysisToolStripMenuItem.Name = "analysisToolStripMenuItem";
            this.analysisToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.analysisToolStripMenuItem.Text = "Analysis";
            // 
            // mapsToolStripMenuItem
            // 
            this.mapsToolStripMenuItem.Name = "mapsToolStripMenuItem";
            this.mapsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.mapsToolStripMenuItem.Text = "Maps";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(362, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 551);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LogText);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.VisitedSystemsGrid);
            this.Controls.Add(this.VisitedSystemsLabel);
            this.Controls.Add(this.ExpeditionLabel);
            this.Controls.Add(this.Expeditions);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Elite Expedition Log";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisitedSystemsGrid)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ComboBox Expeditions;
        private System.Windows.Forms.Label ExpeditionLabel;
        private System.Windows.Forms.Label VisitedSystemsLabel;
        private System.Windows.Forms.DataGridView VisitedSystemsGrid;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox LogText;
        private System.Windows.Forms.TextBox ZText;
        private System.Windows.Forms.Label ZLabel;
        private System.Windows.Forms.TextBox YText;
        private System.Windows.Forms.Label YLabel;
        private System.Windows.Forms.TextBox XText;
        private System.Windows.Forms.Label XLabel;
        private System.Windows.Forms.Label SystemLabel;
        private System.Windows.Forms.Label ScannedObjectsLabel;
        private System.Windows.Forms.Label ObjectTypesLabel;
        private System.Windows.Forms.ListBox ScannedObjectsList;
        private System.Windows.Forms.ListBox ObjectTypesList;
        private System.Windows.Forms.CheckBox Bookmark;
        private System.Windows.Forms.CheckBox Refuel;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStripMenuItem analysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapsToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}

