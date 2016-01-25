using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Inkrypt {
    static class PigLatin {
        private static string alphabetic = @"[a-zA-Z'-]";


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

            // Determine casing
            string casing = input.DetermineCasing();

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

            // Update casing
            if (casing == "uppercase") {
                output = output.UppercaseWord();
            } else if (casing == "allCaps") {
                output = output.ToUpper();
            }
            return output;
        }


        public static string UnpiglatifyWord(this string input) {
            List<string> chunks = new List<string>();
            string output = "";
            string chunk = "";

            // Determine casing
            string casing = input.DetermineCasing();

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

            // Update casing
            if (casing == "uppercase") {
                output = output.UppercaseWord();
            } else if (casing == "allCaps") {
                output = output.ToUpper();
            }
            return output;
        }


        public static string PiglatifyChunk(this string chunk) {

            if (Regex.IsMatch(chunk[0].ToString(), alphabetic)) { // <chunk> is alphabetic
                if (chunk[0].IsVowel()) { // <chunk> begins with vowel
                    chunk += "-way";
    
                } else { // <chunk> begins with consonant
                    string consonant = "";
                    bool beginsWithY = false;
                    if (chunk[0].ToString().ToUpper() == "Y") { // Begins with y
                        beginsWithY = true;
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
                }
            } // nothing happens if <chunk> is not alphabetical

            return chunk;
        }


        public static string UnpiglatifyChunk(this string chunk) {

            if (Regex.IsMatch(chunk[0].ToString(), alphabetic)) { // <chunk> is alphabetic
                if (chunk.Length > 3 && chunk.Substring(chunk.Length - 3).ToUpper() == "WAY" && chunk.Substring(chunk.Length - 4).ToUpper() != "-WAY") { // <chunk> ends with "way" or "-way"
                    chunk = chunk.Substring(0, chunk.Length - 3);
                } else if (chunk.Length > 4 && chunk.Substring(chunk.Length - 4).ToUpper() == "-WAY") {
                    chunk = chunk.Substring(0, chunk.Length - 4);

                } else if (chunk.Length > 2 && chunk.Substring(chunk.Length - 2).ToUpper() == "AY" && !chunk[chunk.Length - 3].IsVowel() && chunk.Dashed()) { // <chunk> ends with a consonant + "ay" and contains a dash between consonants
                    string consonant = "";
                    for (int i = chunk.Length - 3; i > 0; i--) { // Find consonant
                        if (chunk[i] == '-' || chunk[i].IsVowel()) {
                            break;
                        } else {
                            consonant = chunk[i] + consonant;
                        }
                    }
                    chunk = consonant + chunk.Substring(0, chunk.Length - consonant.Length - 3);

                } else if(chunk.Length > 2 && chunk.Substring(chunk.Length - 2).ToUpper() == "AY" && !chunk[chunk.Length - 3].IsVowel() && !chunk.Dashed()) { // <chunk> ends with consonant + "ay" and does not contain a dash between consonants
                    string consonant = "";
                    int breakPoint = 0;
                    for (int i = chunk.Length - 3; i > 0; i--) { // Find consonant
                        if (chunk[i].IsVowel()) {
                            break;
                        } else {
                            consonant = chunk[i] + consonant;
                        }
                    }

                    int length = consonant.Length;
                    int mod = (consonant.Length / 2) + 1;
                    if (consonant.Length > 1 && consonant.Length % 2 != 0 &&
                        consonant[(consonant.Length / 2)] == 's') { // Find consonant breakpoint
                        breakPoint = (consonant.Length / 2) + 1;
                    } else {
                        breakPoint = consonant.Length / 2;
                    }
                    consonant = consonant.Substring(breakPoint);
                    chunk = consonant + chunk.Substring(0, chunk.Length - consonant.Length - 2);
                } // nothing happens the above criteria not met
            }

            return chunk;
        }


    }
}