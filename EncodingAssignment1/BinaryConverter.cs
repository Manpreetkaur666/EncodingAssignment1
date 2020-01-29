//using System;
//using System.Text;

//namespace EncodingAssignment1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Enter username:");
//            string userName = Console.ReadLine();
//            string result1 = StringToBinary(userName);
//            Console.WriteLine("Binary form is: " + result1);
//            string result2 = StringToHex(userName);
//            Console.WriteLine("Hexadecimal form is: " + result2);
//            string result3 = StringToBase64(userName);
//            Console.WriteLine("Base64 form is: " + result3);

//        }


//        public static string StringToBinary(string data)
//        {
//            StringBuilder sb = new StringBuilder();

//            foreach (char c in data.ToCharArray())
//            {
//                //Convert the char to base 2 and pad the output with 0
//                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
//            }
//            return sb.ToString();
//        }
//        public static string StringToHex(string data)
//        {
//            StringBuilder sb = new StringBuilder();

//            foreach (char c in data.ToCharArray())
//            {
//                //Convert the char to base 16 and pad the output with 0
//                sb.Append(Convert.ToString(c, 16).PadLeft(2, '0'));
//            }

//            return sb.ToString().ToUpper();
//        }
//        public static string StringToBase64(string data)
//        {
//            byte[] bytearray = Encoding.ASCII.GetBytes(data);

//            string result = Convert.ToBase64String(bytearray);

//            return result;
//        }
//    }
//}
