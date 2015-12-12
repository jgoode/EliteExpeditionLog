namespace EliteExpeditionLog {
    partial class AddExpedition {
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
            this.SaveButton = new System.Windows.Forms.Button();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.EndSystemTextBox = new System.Windows.Forms.TextBox();
            this.EndSystemLabel = new System.Windows.Forms.Label();
            this.StartSystemTextBox = new System.Windows.Forms.TextBox();
            this.StartSystemLabel = new System.Windows.Forms.Label();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveButton.Location = new System.Drawing.Point(195, 254);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 25;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndDatePicker.Location = new System.Drawing.Point(113, 136);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(92, 20);
            this.EndDatePicker.TabIndex = 24;
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Location = new System.Drawing.Point(112, 119);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(52, 13);
            this.EndDateLabel.TabIndex = 23;
            this.EndDateLabel.Text = "End Date";
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDatePicker.Location = new System.Drawing.Point(15, 136);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(92, 20);
            this.StartDatePicker.TabIndex = 22;
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(14, 119);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(55, 13);
            this.StartDateLabel.TabIndex = 21;
            this.StartDateLabel.Text = "Start Date";
            // 
            // EndSystemTextBox
            // 
            this.EndSystemTextBox.Location = new System.Drawing.Point(14, 218);
            this.EndSystemTextBox.Name = "EndSystemTextBox";
            this.EndSystemTextBox.Size = new System.Drawing.Size(256, 20);
            this.EndSystemTextBox.TabIndex = 20;
            // 
            // EndSystemLabel
            // 
            this.EndSystemLabel.AutoSize = true;
            this.EndSystemLabel.Location = new System.Drawing.Point(14, 202);
            this.EndSystemLabel.Name = "EndSystemLabel";
            this.EndSystemLabel.Size = new System.Drawing.Size(63, 13);
            this.EndSystemLabel.TabIndex = 19;
            this.EndSystemLabel.Text = "End System";
            // 
            // StartSystemTextBox
            // 
            this.StartSystemTextBox.Location = new System.Drawing.Point(14, 179);
            this.StartSystemTextBox.Name = "StartSystemTextBox";
            this.StartSystemTextBox.Size = new System.Drawing.Size(256, 20);
            this.StartSystemTextBox.TabIndex = 18;
            // 
            // StartSystemLabel
            // 
            this.StartSystemLabel.AutoSize = true;
            this.StartSystemLabel.Location = new System.Drawing.Point(14, 162);
            this.StartSystemLabel.Name = "StartSystemLabel";
            this.StartSystemLabel.Size = new System.Drawing.Size(66, 13);
            this.StartSystemLabel.TabIndex = 17;
            this.StartSystemLabel.Text = "Start System";
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(14, 75);
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(256, 41);
            this.DescriptionTextBox.TabIndex = 16;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(14, 59);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.DescriptionLabel.TabIndex = 15;
            this.DescriptionLabel.Text = "Description";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(14, 36);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(256, 20);
            this.NameTextBox.TabIndex = 14;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(14, 20);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(87, 13);
            this.NameLabel.TabIndex = 13;
            this.NameLabel.Text = "Expedition Name";
            // 
            // AddExpedition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 289);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.EndDatePicker);
            this.Controls.Add(this.EndDateLabel);
            this.Controls.Add(this.StartDatePicker);
            this.Controls.Add(this.StartDateLabel);
            this.Controls.Add(this.EndSystemTextBox);
            this.Controls.Add(this.EndSystemLabel);
            this.Controls.Add(this.StartSystemTextBox);
            this.Controls.Add(this.StartSystemLabel);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.NameLabel);
            this.Name = "AddExpedition";
            this.Text = "AddExpedition";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.DateTimePicker EndDatePicker;
        private System.Windows.Forms.Label EndDateLabel;
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.TextBox EndSystemTextBox;
        private System.Windows.Forms.Label EndSystemLabel;
        private System.Windows.Forms.TextBox StartSystemTextBox;
        private System.Windows.Forms.Label StartSystemLabel;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label NameLabel;
    }
}