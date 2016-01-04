using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;

public class CipherUtility {


    public static string Encrypt<T>(string value, string password, string salt)
         where T : SymmetricAlgorithm, new() {
        DeriveBytes rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));

        SymmetricAlgorithm algorithm = new T();

        byte[] rgbKey = rgb.GetBytes(algorithm.KeySize >> 3);
        byte[] rgbIV = rgb.GetBytes(algorithm.BlockSize >> 3);

        ICryptoTransform transform = algorithm.CreateEncryptor(rgbKey, rgbIV);

        using (MemoryStream buffer = new MemoryStream()) {
            using (CryptoStream stream = new CryptoStream(buffer, transform, CryptoStreamMode.Write)) {
                using (StreamWriter writer = new StreamWriter(stream, Encoding.Unicode)) {
                    writer.Write(value);
                }
            }

            return Convert.ToBase64String(buffer.ToArray());
        }
    }


    public static string Decrypt<T>(string text, string password, string salt)
       where T : SymmetricAlgorithm, new() {
        DeriveBytes rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));

        SymmetricAlgorithm algorithm = new T();

        byte[] rgbKey = rgb.GetBytes(algorithm.KeySize >> 3);
        byte[] rgbIV = rgb.GetBytes(algorithm.BlockSize >> 3);

        ICryptoTransform transform = algorithm.CreateDecryptor(rgbKey, rgbIV);

        using (MemoryStream buffer = new MemoryStream(Convert.FromBase64String(text))) {
            using (CryptoStream stream = new CryptoStream(buffer, transform, CryptoStreamMode.Read)) {
                using (StreamReader reader = new StreamReader(stream, Encoding.Unicode)) {
                    return reader.ReadToEnd();
                }
            }
        }
    }


    public static string PigLatinEncrypt(string normalText) {
        string[] normalArray = normalText.SanatizeWhitespace().Split(' ');
        string[] cipherArray = new string[normalArray.Length];
        string cipherText = "";

        for (int i = 0; i < normalArray.Length && normalArray[i].Length > 0; i++) { // Piglatinify <normalArray> and add them to <cipherArray>
            string cipherWord = normalArray[i];
            string prefix = "";
            string suffix = "";
            if (!Regex.IsMatch(cipherWord[0].ToString(), @"[\w]")) { // Begins with nonword character
                prefix = cipherWord.GetPrefix();
                cipherWord = cipherWord.Substring(prefix.Length);
            }
            if (cipherWord.Length > 1 && !Regex.IsMatch(cipherWord[cipherWord.Length - 1].ToString(), @"[\w]")) { // Ends with nonword character
                suffix = cipherWord.GetSuffix();
                cipherWord = cipherWord.Substring(0, cipherWord.Length - suffix.Length);
            }
            if (cipherWord.Length > 1) { // Prevents error when string only contains symbols
                if (cipherWord[0].IsVowel()) { // Begins with vowel
                    cipherWord += "way";
                } else { // Begins with consonant
                    string consonant = "";
                    bool upperCase = false;
                    bool allCaps = false;
                    bool beginsWithY = false;
                    if (cipherWord[0].ToString().ToUpper() == "Y") { // Begins with y
                        beginsWithY = true;
                    }
                    for (int j = 0; j < cipherWord.Length; j++) { // Determine casing
                        if (j == 0) {
                            if (cipherWord[j].IsUpper()) {
                                upperCase = true;
                                allCaps = true;
                            } else {
                                break;
                            }
                        } else {
                            if (cipherWord[j].IsUpper()) {
                                upperCase = false;
                            } else {
                                allCaps = false;
                            }
                        }
                    }
                    for (int j = 0; j < cipherWord.Length && !cipherWord[j].IsVowel(); j++) { // Find consonant
                        consonant += cipherWord[j];
                    }
                    if (beginsWithY) {
                        cipherWord += consonant + "ou";
                    } else {
                        cipherWord += consonant + "ay";
                    }
                    cipherWord = cipherWord.Substring(consonant.Length);
                    if (upperCase) {
                        cipherWord = cipherWord.UppercaseWord();
                    } else if (allCaps) {
                        cipherWord = cipherWord.ToUpper();
                    }
                }
            }
            cipherWord = prefix + cipherWord + suffix;
            cipherArray[i] = cipherWord;
        }
        for (int i = 0; i < cipherArray.Length; i++) { // Create string from <cipherArray>
            if (i == 0) {
                cipherText += cipherArray[i];
            } else {
                cipherText += " " + cipherArray[i];
            }
        }
        return cipherText;
    }


    public static string PigLatinDecrypt(string cipherText) {
        string[] cipherArray = cipherText.Split(' ');
        string[] normalArray = new string[cipherArray.Length];
        string normalText = "";

        for (int i = 0; i < cipherArray.Length; i++) {
            string normalWord = cipherArray[i];
            for (int j = 0; j < cipherArray[i].Length; j++) {
                normalWord = normalWord.Substring(0, normalWord.Length - 2);
                normalWord += normalWord[normalWord.Length - 1] + normalWord;
                normalWord = normalWord.Substring(0, normalWord.Length - 2);
            }
            normalArray[i] = normalWord;
        }
        for (int i = 0; i < normalArray.Length; i++) {
            if (i == 0) {
                normalText += normalArray[i].ToString();
            } else {
                normalText += " " + normalArray[i];
            }
        }
        return normalText;
    }


}