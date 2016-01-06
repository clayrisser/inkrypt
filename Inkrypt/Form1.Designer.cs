namespace Inkrypt {
    partial class Form1 {
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
            this.textInputTextBox = new System.Windows.Forms.TextBox();
            this.textOutputTextBox = new System.Windows.Forms.TextBox();
            this.secretKeyTextBox = new System.Windows.Forms.TextBox();
            this.modeComboBox = new System.Windows.Forms.ComboBox();
            this.secretKeyLabel = new System.Windows.Forms.Label();
            this.textInputLabel = new System.Windows.Forms.Label();
            this.textOutputLabel = new System.Windows.Forms.Label();
            this.modeLabel = new System.Windows.Forms.Label();
            this.methodComboBox = new System.Windows.Forms.ComboBox();
            this.methodLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textInputTextBox
            // 
            this.textInputTextBox.Location = new System.Drawing.Point(12, 104);
            this.textInputTextBox.Multiline = true;
            this.textInputTextBox.Name = "textInputTextBox";
            this.textInputTextBox.Size = new System.Drawing.Size(386, 116);
            this.textInputTextBox.TabIndex = 0;
            this.textInputTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textOutputTextBox
            // 
            this.textOutputTextBox.Location = new System.Drawing.Point(12, 239);
            this.textOutputTextBox.Multiline = true;
            this.textOutputTextBox.Name = "textOutputTextBox";
            this.textOutputTextBox.ReadOnly = true;
            this.textOutputTextBox.Size = new System.Drawing.Size(386, 106);
            this.textOutputTextBox.TabIndex = 1;
            this.textOutputTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // secretKeyTextBox
            // 
            this.secretKeyTextBox.Location = new System.Drawing.Point(12, 64);
            this.secretKeyTextBox.Name = "secretKeyTextBox";
            this.secretKeyTextBox.Size = new System.Drawing.Size(386, 20);
            this.secretKeyTextBox.TabIndex = 4;
            this.secretKeyTextBox.TextChanged += new System.EventHandler(this.secretKeyTextBox_TextChanged);
            // 
            // modeComboBox
            // 
            this.modeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeComboBox.FormattingEnabled = true;
            this.modeComboBox.Items.AddRange(new object[] {
            "Encrypt",
            "Decrypt"});
            this.modeComboBox.Location = new System.Drawing.Point(12, 25);
            this.modeComboBox.Name = "modeComboBox";
            this.modeComboBox.Size = new System.Drawing.Size(121, 21);
            this.modeComboBox.TabIndex = 5;
            this.modeComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // secretKeyLabel
            // 
            this.secretKeyLabel.AutoSize = true;
            this.secretKeyLabel.Location = new System.Drawing.Point(9, 48);
            this.secretKeyLabel.Name = "secretKeyLabel";
            this.secretKeyLabel.Size = new System.Drawing.Size(59, 13);
            this.secretKeyLabel.TabIndex = 6;
            this.secretKeyLabel.Text = "Secret Key";
            // 
            // textInputLabel
            // 
            this.textInputLabel.AutoSize = true;
            this.textInputLabel.Location = new System.Drawing.Point(9, 88);
            this.textInputLabel.Name = "textInputLabel";
            this.textInputLabel.Size = new System.Drawing.Size(55, 13);
            this.textInputLabel.TabIndex = 7;
            this.textInputLabel.Text = "Text Input";
            // 
            // textOutputLabel
            // 
            this.textOutputLabel.AutoSize = true;
            this.textOutputLabel.Location = new System.Drawing.Point(9, 223);
            this.textOutputLabel.Name = "textOutputLabel";
            this.textOutputLabel.Size = new System.Drawing.Size(63, 13);
            this.textOutputLabel.TabIndex = 8;
            this.textOutputLabel.Text = "Text Output";
            // 
            // modeLabel
            // 
            this.modeLabel.AutoSize = true;
            this.modeLabel.Location = new System.Drawing.Point(9, 9);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(34, 13);
            this.modeLabel.TabIndex = 9;
            this.modeLabel.Text = "Mode";
            // 
            // methodComboBox
            // 
            this.methodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.methodComboBox.FormattingEnabled = true;
            this.methodComboBox.Items.AddRange(new object[] {
            "Aes",
            "Triple DES",
            "Rijndael",
            "JamRizzi",
            "Pig Latin"});
            this.methodComboBox.Location = new System.Drawing.Point(139, 25);
            this.methodComboBox.Name = "methodComboBox";
            this.methodComboBox.Size = new System.Drawing.Size(121, 21);
            this.methodComboBox.TabIndex = 10;
            this.methodComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // methodLabel
            // 
            this.methodLabel.AutoSize = true;
            this.methodLabel.Location = new System.Drawing.Point(136, 9);
            this.methodLabel.Name = "methodLabel";
            this.methodLabel.Size = new System.Drawing.Size(43, 13);
            this.methodLabel.TabIndex = 11;
            this.methodLabel.Text = "Method";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 357);
            this.Controls.Add(this.methodLabel);
            this.Controls.Add(this.methodComboBox);
            this.Controls.Add(this.modeLabel);
            this.Controls.Add(this.textOutputLabel);
            this.Controls.Add(this.textInputLabel);
            this.Controls.Add(this.secretKeyLabel);
            this.Controls.Add(this.modeComboBox);
            this.Controls.Add(this.secretKeyTextBox);
            this.Controls.Add(this.textOutputTextBox);
            this.Controls.Add(this.textInputTextBox);
            this.Name = "Form1";
            this.Text = "Inkrypt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textInputTextBox;
        private System.Windows.Forms.TextBox textOutputTextBox;
        private System.Windows.Forms.TextBox secretKeyTextBox;
        private System.Windows.Forms.ComboBox modeComboBox;
        private System.Windows.Forms.Label secretKeyLabel;
        private System.Windows.Forms.Label textInputLabel;
        private System.Windows.Forms.Label textOutputLabel;
        private System.Windows.Forms.Label modeLabel;
        private System.Windows.Forms.ComboBox methodComboBox;
        private System.Windows.Forms.Label methodLabel;
    }
}

