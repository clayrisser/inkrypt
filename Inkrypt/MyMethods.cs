using System;
using System.Text.RegularExpressions;

namespace Inkrypt {
    public static class MyMethods {


        public static bool IsVowel(this char character, bool y) {
            character = Convert.ToChar(character.ToString().ToUpper());
            switch (character) {
                case 'A':
                    return true;
                case 'E':
                    return true;
                case 'I':
                    return true;
                case 'O':
                    return true;
                case 'U':
                    return true;
                case 'Y':
                    if (y) {
                        return true;
                    } else {
                        return false;
                    }
                default:
                    return false;
            }
        }


        public static bool IsVowel(this char character) {
            character = Convert.ToChar(character.ToString().ToUpper());
            switch (character) {
                case 'A':
                    return true;
                case 'E':
                    return true;
                case 'I':
                    return true;
                case 'O':
                    return true;
                case 'U':
                    return true;
                default:
                    return false;
            }
        }


        public static bool IsUpper(this char input) {
            if (Regex.IsMatch(input.ToString(), "[A-Z]")) {
                return true;
            } else {
                return false;
            }
        }


        public static string UppercaseWord(this string input) {
            if (input[0].IsUpper()) {
                return input;
            } else {
                return input[0].ToString().ToUpper() + input.Substring(1).ToLower();
            }
        }


        public static string SanatizeWhitespace(this string input) {
            string output = "";
            bool ignore = false;
            for (int i = 0; i < input.Length; i++) {
                if (ignore) {
                    if (input[i] != ' ') {
                        output += input[i];
                        ignore = false;
                    }
                } else {
                    output += input[i];
                    if (input[i] == ' ') {
                        ignore = true;
                    }
                }
            }
            return output;
        }


        public static string GetPrefix(this string input) {
            string output = "";
            for (int i = 0; i < input.Length; i++) {
                if (Regex.IsMatch(input[i].ToString(), @"[\w]")) {
                    return output;
                } else {
                    output += input[i];
                }
            }
            return output;
        }


        public static string GetSuffix(this string input) {
            string output = "";
            for (int i = input.Length - 1; i > 0; i--) {
                if (Regex.IsMatch(input[i].ToString(), @"[\w]")) {
                    return output;
                } else {
                    output = input[i] + output;
                }
            }
            return output;
        }


        public static bool Dashed(this string input) {
            bool output = false;
            for (int i = input.Length - 3; i > 0; i--) {
                if (input[i] == '-') {
                    output = true;
                    break;
                } else if (input[i].IsVowel()) {
                    break;
                }
            }
            return output;
        }


        public static string DetermineCasing(this string input) {
            string output = "";
            bool upperCase = false;
            bool allCaps = false;
            if (input.Length > 1) {
                for (int i = 0; i < input.Length; i++) {
                    if (i == 0) {
                        if (input[i].IsUpper() || !Regex.IsMatch(input[i].ToString(), @"[A-Za-z]")) {
                            upperCase = true;
                            allCaps = true;
                        } else {
                            break;
                        }
                    } else {
                        if (Regex.IsMatch(input[i].ToString(), @"[A-Za-z]")) {
                            if (input[i].IsUpper()) {
                                upperCase = false;
                            } else {
                                allCaps = false;
                            }
                        }
                    }
                }
            } else {
                if (input[0].IsUpper()) {
                    upperCase = true;
                }
            }
            if (allCaps) {
                output = "allCaps";
            } else if (upperCase) {
                output = "uppercase";
            } else {
                output = "lowercase";
            }
            return output;
        }


    }
}