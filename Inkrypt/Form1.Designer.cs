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
            this.methodLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.switchButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.modeLabel = new System.Windows.Forms.Label();
            this.methodComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textInputTextBox
            // 
            this.textInputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInputTextBox.Location = new System.Drawing.Point(3, 103);
            this.textInputTextBox.Multiline = true;
            this.textInputTextBox.Name = "textInputTextBox";
            this.textInputTextBox.Size = new System.Drawing.Size(612, 182);
            this.textInputTextBox.TabIndex = 0;
            this.textInputTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textOutputTextBox
            // 
            this.textOutputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textOutputTextBox.Location = new System.Drawing.Point(3, 306);
            this.textOutputTextBox.Multiline = true;
            this.textOutputTextBox.Name = "textOutputTextBox";
            this.textOutputTextBox.ReadOnly = true;
            this.textOutputTextBox.Size = new System.Drawing.Size(612, 182);
            this.textOutputTextBox.TabIndex = 1;
            this.textOutputTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // secretKeyTextBox
            // 
            this.secretKeyTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secretKeyTextBox.Location = new System.Drawing.Point(3, 58);
            this.secretKeyTextBox.Name = "secretKeyTextBox";
            this.secretKeyTextBox.Size = new System.Drawing.Size(612, 20);
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
            this.modeComboBox.Location = new System.Drawing.Point(309, 18);
            this.modeComboBox.Name = "modeComboBox";
            this.modeComboBox.Size = new System.Drawing.Size(121, 21);
            this.modeComboBox.TabIndex = 5;
            this.modeComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // secretKeyLabel
            // 
            this.secretKeyLabel.AutoSize = true;
            this.secretKeyLabel.Location = new System.Drawing.Point(3, 40);
            this.secretKeyLabel.Name = "secretKeyLabel";
            this.secretKeyLabel.Size = new System.Drawing.Size(59, 13);
            this.secretKeyLabel.TabIndex = 6;
            this.secretKeyLabel.Text = "Secret Key";
            // 
            // textInputLabel
            // 
            this.textInputLabel.AutoSize = true;
            this.textInputLabel.Location = new System.Drawing.Point(3, 85);
            this.textInputLabel.Name = "textInputLabel";
            this.textInputLabel.Size = new System.Drawing.Size(55, 13);
            this.textInputLabel.TabIndex = 7;
            this.textInputLabel.Text = "Text Input";
            // 
            // textOutputLabel
            // 
            this.textOutputLabel.AutoSize = true;
            this.textOutputLabel.Location = new System.Drawing.Point(3, 288);
            this.textOutputLabel.Name = "textOutputLabel";
            this.textOutputLabel.Size = new System.Drawing.Size(63, 13);
            this.textOutputLabel.TabIndex = 8;
            this.textOutputLabel.Text = "Text Output";
            // 
            // methodLabel
            // 
            this.methodLabel.AutoSize = true;
            this.methodLabel.Location = new System.Drawing.Point(309, 0);
            this.methodLabel.Name = "methodLabel";
            this.methodLabel.Size = new System.Drawing.Size(43, 13);
            this.methodLabel.TabIndex = 11;
            this.methodLabel.Text = "Method";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.textOutputTextBox, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.switchButton, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.textOutputLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.textInputLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textInputTextBox, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.secretKeyTextBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.secretKeyLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(618, 522);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // switchButton
            // 
            this.switchButton.Location = new System.Drawing.Point(3, 494);
            this.switchButton.Name = "switchButton";
            this.switchButton.Size = new System.Drawing.Size(75, 25);
            this.switchButton.TabIndex = 12;
            this.switchButton.Text = "Switch";
            this.switchButton.UseVisualStyleBackColor = true;
            this.switchButton.Click += new System.EventHandler(this.switchButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.methodLabel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.modeComboBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.modeLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.methodComboBox, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(612, 34);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // modeLabel
            // 
            this.modeLabel.AutoSize = true;
            this.modeLabel.Location = new System.Drawing.Point(3, 0);
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
            this.methodComboBox.Location = new System.Drawing.Point(3, 18);
            this.methodComboBox.Name = "methodComboBox";
            this.methodComboBox.Size = new System.Drawing.Size(121, 21);
            this.methodComboBox.TabIndex = 10;
            this.methodComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 522);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Inkrypt";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textInputTextBox;
        private System.Windows.Forms.TextBox textOutputTextBox;
        private System.Windows.Forms.TextBox secretKeyTextBox;
        private System.Windows.Forms.ComboBox modeComboBox;
        private System.Windows.Forms.Label secretKeyLabel;
        private System.Windows.Forms.Label textInputLabel;
        private System.Windows.Forms.Label textOutputLabel;
        private System.Windows.Forms.Label methodLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button switchButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label modeLabel;
        private System.Windows.Forms.ComboBox methodComboBox;
    }
}

