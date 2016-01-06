using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Inkrypt {
    static class PigLatin {
        private static string alphabetic = @"[a-zA-Z']";


        public static string PigLatinEncrypt(string normalText) {
            string[] normalArray = normalText.SanatizeWhitespace().Split(' ');
            string[] cipherArray = new string[normalArray.Length];
            string cipherText = "";

            for (int i = 0; i < normalArray.Length && normalArray[i].Length > 0; i++) { // Piglatify <normalArray> and add them to <cipherArray>
                string cipherWord = normalArray[i].PiglatifyWord();
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


        public static string PigLatinDecrypt(string normalText) {
            string[] normalArray = normalText.SanatizeWhitespace().Split(' ');
            string[] cipherArray = new string[normalArray.Length];
            string cipherText = "";

            for (int i = 0; i < normalArray.Length && normalArray[i].Length > 0; i++) { // Piglatify <normalArray> and add them to <cipherArray>
                string cipherWord = normalArray[i].UnpiglatifyWord();
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


        public static string PiglatifyWord(this string input) {
            List<string> chunks = new List<string>();
            string output = "";
            string chunk = "";

            for (int i = 0; i < input.Length; i++) { // Iterate over each character of <input>

                if (i == 0) { // First char  
                    chunks.Add(input[i].ToString()); // Create new chunk

                } else if (i > 0 && Regex.IsMatch(input[i].ToString(), alphabetic) != Regex.IsMatch(input[i - 1].ToString(), alphabetic)) { // Next chunk
                    // Piglatify previous chunk
                    chunk = chunks[chunks.Count - 1].PiglatifyChunk();
                    chunks[chunks.Count - 1] = chunk;
                    // Create new chunk
                    chunks.Add(input[i].ToString());

                } else { // Add to same chunk
                    chunk = chunks[chunks.Count - 1] + input[i].ToString();
                    chunks[chunks.Count - 1] = chunk;
                }
            }

            // Piglatify last chunk
            chunk = chunks[chunks.Count - 1].PiglatifyChunk();
            chunks[chunks.Count - 1] = chunk;

            // Generate <output>
            for (int i = 0; i < chunks.Count; i++) {
                output += chunks[i];
            }
            return output;
        }


        public static string UnpiglatifyWord(this string input) {
            List<string> chunks = new List<string>();
            string output = "";
            string chunk = "";

            for (int i = 0; i < input.Length; i++) { // Iterate over each character of <input>

                if (i == 0) { // First char  
                    chunks.Add(input[i].ToString()); // Create new chunk

                } else if (i > 0 && Regex.IsMatch(input[i].ToString(), alphabetic) != Regex.IsMatch(input[i - 1].ToString(), alphabetic)) { // Next chunk
                    // Piglatify previous chunk
                    chunk = chunks[chunks.Count - 1].UnpiglatifyChunk();
                    chunks[chunks.Count - 1] = chunk;
                    // Create new chunk
                    chunks.Add(input[i].ToString());

                } else { // Add to same chunk
                    chunk = chunks[chunks.Count - 1] + input[i].ToString();
                    chunks[chunks.Count - 1] = chunk;
                }
            }

            // Piglatify last chunk
            chunk = chunks[chunks.Count - 1].UnpiglatifyChunk();
            chunks[chunks.Count - 1] = chunk;

            // Generate <output>
            for (int i = 0; i < chunks.Count; i++) {
                output += chunks[i];
            }
            return output;
        }


        public static string PiglatifyChunk(this string chunk) {

            if (Regex.IsMatch(chunk[0].ToString(), alphabetic)) { // <chunk> is alphabetic
                if (chunk[0].IsVowel()) { // <chunk> begins with vowel
                    chunk += "-way";
    
                } else { // <chunk> begins with consonant
                    string consonant = "";
                    bool upperCase = false;
                    bool allCaps = false;
                    bool beginsWithY = false;
                    if (chunk[0].ToString().ToUpper() == "Y") { // Begins with y
                        beginsWithY = true;
                    }
                    for (int j = 0; j < chunk.Length; j++) { // Determine casing
                        if (j == 0) {
                            if (chunk[j].IsUpper()) {
                                upperCase = true;
                                allCaps = true;
                            } else {
                                break;
                            }
                        } else {
                            if (chunk[j].IsUpper()) {
                                upperCase = false;
                            } else {
                                allCaps = false;
                            }
                        }
                    }
                    for (int j = 0; j < chunk.Length && !chunk[j].IsVowel(); j++) { // Find <consonant>
                        consonant += chunk[j];
                    }
                    if (consonant.Length != chunk.Length) { // Remove consonant from begining and add dash
                        consonant = '-' + consonant;
                        chunk = chunk.Substring(consonant.Length - 1);
                    } else {
                        chunk = chunk.Substring(consonant.Length);
                    }
                    if (beginsWithY) { // Piglatify
                        chunk += consonant + "ay";
                    } else {
                        chunk += consonant + "ay";
                    }
                    if (upperCase) { // Update casing
                        chunk = chunk.UppercaseWord();
                    } else if (allCaps) {
                        chunk = chunk.ToUpper();
                    }
                }
            } // nothing happens if <chunk> is not alphabetical

            return chunk;
        }


        public static string UnpiglatifyChunk(this string chunk) {

            if (Regex.IsMatch(chunk[0].ToString(), alphabetic)) { // <chunk> is alphabetic
                if (chunk.Length > 3 && chunk.Substring(chunk.Length - 3) == "way") { // <chunk> ends with "way"
                    chunk = chunk.Substring(0, chunk.Length - 3);

                } else if (chunk.Length > 2) { // <chunk> ends with a consonant + "ay"
                    string consonant = "";
                    bool upperCase = false;
                    bool allCaps = false;
                    bool endsWithYay = false;
                    if (chunk.Substring(chunk.Length - 3).ToUpper() == "YAH") { // Ends with "yay"
                        endsWithYay = true;
                    }
                    for (int j = 0; j < chunk.Length; j++) { // Determine casing
                        if (j == 0) {
                            if (chunk[j].IsUpper()) {
                                upperCase = true;
                                allCaps = true;
                            } else {
                                break;
                            }
                        } else {
                            if (chunk[j].IsUpper()) {
                                upperCase = false;
                            } else {
                                allCaps = false;
                            }
                        }
                    }
                    /* for (int j = chunk.Length - 1; j > 0; j--) {
                        if () {
                            consonant += chunk[j];
                        }

                    } */
                    for (int j = 0; j < chunk.Length && !chunk[j].IsVowel(); j++) { // Find <consonant>
                        consonant += chunk[j];
                    }
                    if (endsWithYay) { // Piglatify
                        chunk += consonant + "ou";
                    } else {
                        chunk += consonant + "ay";
                    }
                    chunk = chunk.Substring(consonant.Length);
                    if (upperCase) { // Update casing
                        chunk = chunk.UppercaseWord();
                    } else if (allCaps) {
                        chunk = chunk.ToUpper();
                    }
                } // nothing happens if <chunk> is not alphabetical
            }

            return chunk;
        }


    }
}