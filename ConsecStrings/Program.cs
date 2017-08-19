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
            Console.WriteLine(LongestConsec(temp,2));

        }
        public static String LongestConsec(string[] strarr, int k)
        {
            List<string> ConsecStrings = new List<string>();
            int i = 0;
            do
            {
                string temp = "";
                for (int j = i; j < j + k; j++)
                {
                    temp += strarr[j];
                }
                ConsecStrings.Add(temp);
                i++;
            } while (i + k < strarr.Length);

            int maxLength = ConsecStrings[0].Count;
            int indexOfString = 0;

            return "";
            
                
        // your code
    }
    }
}
