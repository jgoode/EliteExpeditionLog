namespace EliteExpeditionLog {
    partial class SettingsForm {
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
            this.ExitButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.FilePathLabel = new System.Windows.Forms.Label();
            this.LogFilePathText = new System.Windows.Forms.TextBox();
            this.EdsmKeyText = new System.Windows.Forms.TextBox();
            this.EdsmLabel = new System.Windows.Forms.Label();
            this.FileChooser = new System.Windows.Forms.OpenFileDialog();
            this.CommanderNameText = new System.Windows.Forms.TextBox();
            this.CommanderNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(16, 181);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(266, 181);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // FilePathLabel
            // 
            this.FilePathLabel.AutoSize = true;
            this.FilePathLabel.Location = new System.Drawing.Point(13, 13);
            this.FilePathLabel.Name = "FilePathLabel";
            this.FilePathLabel.Size = new System.Drawing.Size(69, 13);
            this.FilePathLabel.TabIndex = 2;
            this.FilePathLabel.Text = "Log File Path";
            // 
            // LogFilePathText
            // 
            this.LogFilePathText.Location = new System.Drawing.Point(16, 30);
            this.LogFilePathText.Name = "LogFilePathText";
            this.LogFilePathText.Size = new System.Drawing.Size(302, 20);
            this.LogFilePathText.TabIndex = 3;
            // 
            // EdsmKeyText
            // 
            this.EdsmKeyText.Location = new System.Drawing.Point(16, 82);
            this.EdsmKeyText.Name = "EdsmKeyText";
            this.EdsmKeyText.Size = new System.Drawing.Size(325, 20);
            this.EdsmKeyText.TabIndex = 5;
            // 
            // EdsmLabel
            // 
            this.EdsmLabel.AutoSize = true;
            this.EdsmLabel.Location = new System.Drawing.Point(13, 65);
            this.EdsmLabel.Name = "EdsmLabel";
            this.EdsmLabel.Size = new System.Drawing.Size(54, 13);
            this.EdsmLabel.TabIndex = 4;
            this.EdsmLabel.Text = "Edsm Key";
            // 
            // FileChooser
            // 
            this.FileChooser.FileName = "openFileDialog1";
            this.FileChooser.ValidateNames = false;
            // 
            // CommanderNameText
            // 
            this.CommanderNameText.Location = new System.Drawing.Point(16, 133);
            this.CommanderNameText.Name = "CommanderNameText";
            this.CommanderNameText.Size = new System.Drawing.Size(325, 20);
            this.CommanderNameText.TabIndex = 7;
            // 
            // CommanderNameLabel
            // 
            this.CommanderNameLabel.AutoSize = true;
            this.CommanderNameLabel.Location = new System.Drawing.Point(13, 116);
            this.CommanderNameLabel.Name = "CommanderNameLabel";
            this.CommanderNameLabel.Size = new System.Drawing.Size(94, 13);
            this.CommanderNameLabel.TabIndex = 6;
            this.CommanderNameLabel.Text = "Commander Name";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 216);
            this.Controls.Add(this.CommanderNameText);
            this.Controls.Add(this.CommanderNameLabel);
            this.Controls.Add(this.EdsmKeyText);
            this.Controls.Add(this.EdsmLabel);
            this.Controls.Add(this.LogFilePathText);
            this.Controls.Add(this.FilePathLabel);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ExitButton);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label FilePathLabel;
        private System.Windows.Forms.TextBox LogFilePathText;
        private System.Windows.Forms.TextBox EdsmKeyText;
        private System.Windows.Forms.Label EdsmLabel;
        private System.Windows.Forms.OpenFileDialog FileChooser;
        private System.Windows.Forms.TextBox CommanderNameText;
        private System.Windows.Forms.Label CommanderNameLabel;
    }
}