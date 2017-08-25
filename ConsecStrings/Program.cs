using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ConsecStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] temp = { "zone", "abigail", "theta", "form", "libe", "zas" };
            int[] m5 = {1,1,1,1,1 }; 
            Console.WriteLine(LongestConsec(new String[] { "it", "wkppv", "ixoyx", "3452", "zzzzzzzzzzzz" }, 3));
            Console.WriteLine($"LC with LIQN: {LongestConsecWithLinq(temp, 1)}");
            Console.WriteLine(PrinterError("aaaaaaaaaaaaaaaabbbbbbbwwwwbbbbbbbbbbbbbmmrmzzzmmmmmmmmmmmmmmmxyz"));
            Console.WriteLine(PrinterErrorWithLinq("aaaaaaaaaaaaaaaabbbbbbbwwwwbbbbbbbbbbbbbmmrmzzzmmmmmmmmmmmmmmmxyz"));
            Console.WriteLine(binaryArrayToNumber(m5));
            Console.WriteLine(Convert.ToInt32("0010", 2));
            //int num = 3;
            //var myenum = Enumerable.Range(0, temp.Length - num + 1).
            //    Select(x=>string.Join("",temp.Skip(x).Take(num))).
            //    OrderByDescending(x=>x.Length).
            //    First();
            //foreach (var item in myenum)
            //{
            //    Console.WriteLine(item);
            //}
            // 1 2 3 4 5 (a - b) => 1-2-3-4-5 [(((a-b)-b)-b)]
            var agr = Enumerable.Range(1, 5).Aggregate((a, b) => a - b);

            Console.WriteLine($"Result: {agr}");
            // 1 2 3 4 5 (b-a) =>(5-(4-(3-(2-1))))[(b-(b-(b-a)))]
            var agr1 = Enumerable.Range(1, 5).Aggregate((a, b) => b - a);

            Console.WriteLine($"Result: {agr1}");

            int[] sum = {3,3,3,4,9 };
            
            for (int i = 1; i < sum.Length-1; i++)
            {
                if (sum.Take(i).Aggregate((a, b) => a + b) == sum.Skip(i + 1).Aggregate((a, b) => a + b))
                {
                    Console.WriteLine(i);
                }
                    
            }
            Console.WriteLine(-1);

            Console.WriteLine(Solution(15));
        }
        public static String LongestConsec(string[] strarr, int k)
        {
            List<string> AllConsecStrings = new List<string>();

            if (k > strarr.Length || strarr.Length == 0 || k <= 0)
                return "";
            for (int i = 0; i < strarr.Length + 1 - k; i++)
            {
                string BufferString = "";
                for (int j = i; j < i + k; j++)
                {
                    BufferString += strarr[j];
                }
                AllConsecStrings.Add(BufferString);
            }





            int maxLength = AllConsecStrings[0].Length;
            int indexOfString = 0;
            for (int i = 0; i < AllConsecStrings.Count; i++)
            {
                if (AllConsecStrings[i].Length > maxLength)
                {
                    maxLength = AllConsecStrings[i].Length;
                    indexOfString = i;
                }
            }
            return AllConsecStrings[indexOfString];



        }
        public static String LongestConsecWithLinq(string[] s, int k)
        {
            return s.Length == 0 || s.Length < k || k <= 0 ? ""
             : Enumerable.Range(0, s.Length - k + 1)
                         .Select(x => string.Join("", s.Skip(x).Take(k)))//Внимательно с тем что тут происходит
                         .OrderByDescending(x => x.Length)
                         .First();
        }

        public static string PrinterError(string s)
        {
            foreach (var item in s.ToCharArray())
            {
                if (!char.IsLetter(item))
                    return string.Empty;
            }
            
            int ErrorCount = 0;
            char[] ErrorLetters = {'n','o','p','q','r','s','t','u','v','w','x','y','z'};//Если в троке есть такая буква, то принтер допускает ошибку.
            foreach (var item in ErrorLetters)
            {
                if (s.ToCharArray().Contains(item))
                {
                    
                    ErrorCount+= s.ToCharArray().Count(c => c.Equals(item));
                }
            }

                return $"{ErrorCount}/{s.Length}";

         
        }
        public static string PrinterErrorWithLinq(string s)
        {
            return $"{s.Where(c => c > 'm').Count()}/{s.Count()}";
            
        }

        public static int binaryArrayToNumber(int[] BinaryArray)
        {

           
            int resultingInteger = 0;
            for (int i = 0; i < BinaryArray.Length; i++)
            {
                resultingInteger += BinaryArray[i] * (int)(Math.Pow(2,(BinaryArray.Length - 1 - i)));
            } 

            return resultingInteger;

        }

        public static int FindSmallestInt(int[] args)
        {
            return args.Min();
        }

        public static int Solution(int value)
        {
            List<int> ListOfMultipliers= new List<int>() ;
            
            for (int i = 5; i < value; i+=5)
            {
                ListOfMultipliers.Add(i);
            }
            for (int i = 3; i < value; i+=3)
            {
                    ListOfMultipliers.Add(i);
            }
            return ListOfMultipliers.Distinct().Sum();
        }
        public static int Solution1(int n)
        {
            return Enumerable.Range(0, n).Where(e => e % 3 == 0 || e % 5 == 0).Sum();
        }
    }
}
