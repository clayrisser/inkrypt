using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Inkrypt {
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
            this.modeComboBox.SelectedIndex = 0;
            this.methodComboBox.SelectedIndex = 0;
        }


        private void UpdateOutput() {
            this.secretKeyTextBox.ReadOnly = false;
            string input = this.textInputTextBox.Text;
            string key = this.secretKeyTextBox.Text;
            string salt = "saltTheOats";
            if (this.modeComboBox.Text != "Decrypt") {
                Encrypt(input, key, salt);
            } else {
                Decrypt(input, key, salt);
            }
        }


        private void Encrypt(string input, string key, string salt) {
            try {
                switch (this.methodComboBox.Text) {
                    default:
                        this.textOutputTextBox.Text = CipherUtility.Encrypt<AesManaged>(input, key, salt);
                        break;
                    case "Triple DES":
                        this.textOutputTextBox.Text = CipherUtility.Encrypt<TripleDESCryptoServiceProvider>(input, key, salt);
                        break;
                    case "Rijndael":
                        this.textOutputTextBox.Text = CipherUtility.Encrypt<RijndaelManaged>(input, key, salt);
                        break;
                    case "JamRizzi":
                        break;
                    case "Pig Latin":
                        this.secretKeyTextBox.ReadOnly = true;
                        this.textOutputTextBox.Text = PigLatin.PigLatinEncrypt(input);
                        break;
                }
            } catch (CryptographicException) {
                this.textOutputTextBox.Text = "Invalid";
            } catch (FormatException) {
                this.textOutputTextBox.Text = "Invalid";
            }
        }


        private void Decrypt(string input, string key, string salt) {
            try {
                switch(this.methodComboBox.Text) {
                    default:
                        this.textOutputTextBox.Text = CipherUtility.Decrypt<AesManaged>(input, key, salt);
                        break;
                    case "Triple DES":
                        this.textOutputTextBox.Text = CipherUtility.Decrypt<TripleDESCryptoServiceProvider>(input, key, salt);
                        break;
                    case "Rijndael":
                        this.textOutputTextBox.Text = CipherUtility.Decrypt<RijndaelManaged>(input, key, salt);
                        break;
                    case "JamRizzi":
                        break;
                    case "Pig Latin":
                        this.secretKeyTextBox.ReadOnly = true;
                        this.textOutputTextBox.Text = PigLatin.PigLatinDecrypt(input);
                        break;
                }
            } catch (CryptographicException) {
                this.textOutputTextBox.Text = "Invalid";
            } catch (FormatException) {
                this.textOutputTextBox.Text = "Invalid";
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e) {
            UpdateOutput();
        }


        private void secretKeyTextBox_TextChanged(object sender, EventArgs e) {
            UpdateOutput();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateOutput();
        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e) {
            UpdateOutput();
        }


        private void textBox2_TextChanged(object sender, EventArgs e) {

        }


        private void encryptButton_Click(object sender, EventArgs e) {

        }

        private void switchButton_Click(object sender, EventArgs e) {
            string temp = this.textInputTextBox.Text;
            this.textInputTextBox.Text = this.textOutputTextBox.Text;
            this.textOutputTextBox.Text = temp;
        }
    }
}
