using System;
using System.Text;
using Converter.Models;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace EncodingAssignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string unicodeString = "This string contains the unicode character Pi (\u03a0)";
            int[] cipher = new[] { 1, 1, 2, 3, 5, 8, 13 }; //Fibonacci Sequence
            string cipherasString = String.Join(",", cipher.Select(x => x.ToString())); //FOr display

            int encryptionDepth = 20;
            //int number;

            //Input User
            Console.WriteLine("Enter username:");
            string userName = Console.ReadLine();

            Console.WriteLine("Menu:\nSelect the conversion for your name\n 1)Binary Conversion\n" +
            	" 2)Hexadecimal Conversions\n " +
            	"3)Base64 Conversion\n " +
            	"4) Encryption\n");



            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Enter the number:");
                int number = Convert.ToInt32(Console.ReadLine());

                if (number == 1)
                {
                    //String  Binary 
                    string StrBin = StringToBinary(userName);
                    Console.WriteLine("Binary form is: " + StrBin);
                    string BinStr = BinaryToString(StrBin);
                    Console.WriteLine("Binary to ASCII: " + BinStr);

                }

                if (number == 2)
                {
                    //String Hexadecimal
                    string StrHex = StringToHex(userName);
                    Console.WriteLine("Hexadecimal form is: " + StrHex);
                    string HexStr = ConvertHex(StrHex);
                    Console.WriteLine("Hexadecimal to ASCII: " + HexStr);


                }

                if (number == 3)
                {
                    //String Base64
                    string StrBase = StringToBase64(userName);
                    Console.WriteLine("Base64 form is: " + StrBase);
                    string BaseStr = Base64ToString(StrBase);
                    Console.WriteLine("Base64 to ASCII: " + BaseStr);

                }

                if (number == 4)
                {
                    //encryption

                    Encrypter encrypter = new Encrypter(userName, cipher, encryptionDepth);

                    string nameEncryptWithCipher = Encrypter.EncryptWithCipher(userName, cipher);
                    Console.WriteLine($"Encrypted once using the cipher {{{cipherasString}}} {nameEncryptWithCipher}");

                    string nameDecryptWithCipher = Encrypter.DecryptWithCipher(nameEncryptWithCipher, cipher);
                    Console.WriteLine($"Decrypted once using the cipher {{{cipherasString}}} {nameDecryptWithCipher}");

                    //Deep Encrytion
                    string nameDeepEncryptWithCipher = Encrypter.DeepEncryptWithCipher(userName, cipher, encryptionDepth);
                    Console.WriteLine($"Deep Encrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepEncryptWithCipher}");

                    string nameDeepDecryptWithCipher = Encrypter.DeepDecryptWithCipher(nameDeepEncryptWithCipher, cipher, encryptionDepth);
                    Console.WriteLine($"Deep Decrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepDecryptWithCipher}");

                    //Base64 Encoded
                    Console.WriteLine($"Base64 encoded {userName} {encrypter.Base64}");

                    string base64toPlainText = Encrypter.Base64ToString(encrypter.Base64);
                    Console.WriteLine($"Base64 decoded {encrypter.Base64} {base64toPlainText}");

                }

            }

        }


       //Binary Conversions
        public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                //Convert the char to base 2 and pad the output with 0
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        public static string BinaryToString(string data)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }



        //Hexadecimal conversions
        public static string StringToHex(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                //Convert the char to base 16 and pad the output with 0
                sb.Append(Convert.ToString(c, 16).PadLeft(2, '0'));
            }

            return sb.ToString().ToUpper();
        }

        public static string ConvertHex(String hexString)
        {
            try
            {
                string ascii = string.Empty;

                for (int i = 0; i < hexString.Length; i += 2)
                {
                    String hs = string.Empty;

                    hs = hexString.Substring(i, 2);
                    uint decval = System.Convert.ToUInt32(hs, 16);
                    char character = System.Convert.ToChar(decval);
                    ascii += character;

                }

                return ascii;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return string.Empty;
        }


        //Base64 Conversions
        public static string StringToBase64(string data)
        {
            byte[] bytearray = Encoding.ASCII.GetBytes(data);

            string result = Convert.ToBase64String(bytearray);

            return result;
        }
        public static string Base64ToString(string base64String)
        {
            byte[] bytearray = Convert.FromBase64String(base64String);

            using (var ms = new MemoryStream(bytearray))
            {
                using (StreamReader reader = new StreamReader(ms))
                {
                    string text = reader.ReadToEnd();
                    return text;
                }
            }
        }
    }
}
