using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inkrypt {
    public static class MyMethods {

        public static bool IsVowel(this char character) {
            switch (character) {
                case 'a':
                    return true;
                case 'e':
                    return true;
                case 'i':
                    return true;
                case 'o':
                    return true;
                case 'u':
                    return true;
                default:
                    return false;
            }
        }

    }
}
