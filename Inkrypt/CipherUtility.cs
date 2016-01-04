using System;
using System.Text;
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
        string[] normalArray = normalText.Split(' ');
        string[] cipherArray = new string[normalArray.Length];
        string cipherText = "";

        for (int i = 0; i < normalArray.Length && normalArray[i].Length > 0; i++) {
            string piglet = normalArray[i];
            piglet += piglet[0] + "ay";
            piglet = piglet.Substring(1);
            cipherArray[i] = piglet;
        }
        for (int i = 0; i < cipherArray.Length; i++) {
            if (i == 0) {
                cipherText += Convert.ToString(cipherArray[i]);
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
                normalText += Convert.ToString(normalArray[i]);
            } else {
                normalText += " " + normalArray[i];
            }
        }
        return normalText;
    }
}