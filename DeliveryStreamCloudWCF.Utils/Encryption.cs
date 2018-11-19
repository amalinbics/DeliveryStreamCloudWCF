using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliveryStreamCloudWCF.Utils
{
    /// <summary>
    /// Encryption class
    /// </summary>
    public class Encryption
    {
        private static int[] KeyIntArray = new int[34]{

        121, 101, 75, 121, 116, 105, 114, 117, 99, 101,

        83, 101, 114, 97, 119, 116, 102, 111, 83, 121,

        103, 114, 101, 110, 69, 101, 103, 97, 116, 110,

        97, 118, 100, 65};

        private const String x = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        /// <summary>
        /// ANSICrypt
        /// Function to generate encrypted or decrypted string based upon the string and encryption key passed
        /// </summary>
        /// <param name="S">String</param>
        /// <param name="shift">Encryption key</param>
        /// <returns>Eencrypted or decrypted string</returns>
        private static string ANSICrypt(string S, int shift)
        {
            int i = 0;
            int j = 0;
            int h = 0;
            int maxx = x.Length;
            StringBuilder result = new StringBuilder();
            result.Append(S);

            for (i = 1; i <= result.Length; i++)
            {
                j = 1;
                while (j <= maxx)
                {
                    if (result[i - 1] == x[j - 1])
                    {
                        h = (j + (shift * i)) % maxx;

                        if (h > x.Length)
                        {
                            h = h - maxx;
                        }

                        if (h < 1)
                        {
                            h = h + maxx;
                        }

                        result[i - 1] = x[h - 1];
                        j = maxx + 10;
                    }
                    j = j + 1;
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Key
        /// Function to generate encryption key base upon the string passed
        /// </summary>
        /// <param name="S">String</param>
        /// <returns>Encryption key</returns>
        private static Int32 Key(String S)
        {

            int id = S.Length;

            if (id < KeyIntArray.Length)
            {

                return KeyIntArray[id];

            }
            else
            {

                return 113;

            }
        }

        /// <summary>
        /// doEncrypt
        /// Function to encrypt the given plain-text string
        /// </summary>
        /// <param name="InputString">Input String</param>
        /// <returns>Encrypted string</returns>
        public static string doEncrypt(string InputString)
        {
            string result = "";
            if (InputString.Length != 0)
            {
                result = ANSICrypt(InputString, Key(InputString));
            }
            return result;
        }

        /// <summary>
        /// doDecrypt
        /// Function to decrypt a string value previously encrypted
        /// </summary>
        /// <param name="InputString">Input String</param>
        /// <returns>The original, plain-text string</returns>
        public static string doDecrypt(string InputString)
        {
            string result = "";
            if (InputString.Length != 0)
            {
                result = ANSICrypt(InputString, -1 * Key(InputString));
            }
            return result;
        }
    }
}
