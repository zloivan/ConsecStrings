using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsecStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] temp = { "zone", "abigail", "theta", "form", "libe", "zas" };
            
            Console.WriteLine(LongestConsec(new String[] { "it", "wkppv", "ixoyx", "3452", "zzzzzzzzzzzz" }, 3));
            Console.WriteLine($"LC with LIQN: {LongestConsecWithLinq(temp, 1)}");

        }
        public static String LongestConsec(string[] strarr, int k)
        {
            List<string> AllConsecStrings = new List<string>();

            if (k > strarr.Length || strarr.Length==0|| k<=0)
                return "";
                for (int i = 0; i < strarr.Length+1-k; i++)
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
                         .Select(x => string.Join("", s.Skip(x).Take(k)))
                         .OrderByDescending(x => x.Length)
                         .First();
        }
    }
}
