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
            int[] m5 = { 1, 1, 1, 1, 1 };
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

            int[] sum = { 3, 3, 3, 4, 9 };

            for (int i = 1; i < sum.Length - 1; i++)
            {
                if (sum.Take(i).Aggregate((a, b) => a + b) == sum.Skip(i + 1).Aggregate((a, b) => a + b))
                {
                    Console.WriteLine(i);
                }

            }
            Console.WriteLine(-1);
            int[][] array = new int[][]
            {
            new int[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
            new int[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
            new int[] {1, 9, 8, 3, 4, 2, 5, 6, 7},
            new int[] {8, 5, 9, 7, 6, 1, 4, 2, 3},
            new int[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
            new int[] {7, 1, 3, 9, 2, 4, 8, 5, 6},
            new int[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
            new int[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
            new int[] {3, 4, 5, 2, 8, 6, 1, 7, 9},
            };

            Console.WriteLine($"Result: {SumOfArea(array, 3, 0)}");
            Console.WriteLine(CheckAllAreaSum(array));
            Console.WriteLine(ContainAllRow(array));
            foreach (string floor in BuildTower(4))
            {
                Console.WriteLine(floor);
            }

            Console.WriteLine(TripleDouble(111234,1234));
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
            char[] ErrorLetters = { 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };//Если в троке есть такая буква, то принтер допускает ошибку.
            foreach (var item in ErrorLetters)
            {
                if (s.ToCharArray().Contains(item))
                {

                    ErrorCount += s.ToCharArray().Count(c => c.Equals(item));
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
                resultingInteger += BinaryArray[i] * (int)(Math.Pow(2, (BinaryArray.Length - 1 - i)));
            }

            return resultingInteger;

        }

        public static int FindSmallestInt(int[] args)
        {
            return args.Min();
        }

        public static int Solution(int value)
        {
            List<int> ListOfMultipliers = new List<int>();

            for (int i = 5; i < value; i += 5)
            {
                ListOfMultipliers.Add(i);
            }
            for (int i = 3; i < value; i += 3)
            {
                ListOfMultipliers.Add(i);
            }
            return ListOfMultipliers.Distinct().Sum();
        }
        public static int Solution1(int n)
        {
            return Enumerable.Range(0, n).Where(e => e % 3 == 0 || e % 5 == 0).Sum();
        }
        

        public static bool ContainAllRow(int[][] row)
        {
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i].Sum() == 45)
                {
                    continue;
                }
                else return false;
            }
            return true;

        }

        public static int SumOfArea(int[][] board, int x, int y)
        {
            int result = 0;
            for (int i = x; i < x+3; i++)
            {
                for (int j = y; j < y+3; j++)
                {
                    result+=board[i][j];
                }
            }
            return result;
        }
        public static bool CheckAllAreaSum(int[][] board)
        {
            for (int i = 0; i < 9; i+=3)
            {
                for (int j = 0; j  <9; j+=3)
                {
                    if (SumOfArea(board, i, j) == 45) continue;
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static string DoneOrNot(int[][] board)
        {
            if (CheckAllAreaSum(board) && ContainAllRow(board)) return "Finished!";
            else return "Try again!";
        }

        public static string[] BuildTower(int floorsCount)
        {
            string[] tower = new string[floorsCount];
            for (int i = 0; i < floorsCount; i++)
            {
                string  floor ="";
                floor += "'";
                for (int emptySpace = 0; emptySpace < floorsCount-i-1; emptySpace++)
                {
                    floor += " ";
                }
                for (int blocks = 0; blocks < 2*i+1; blocks++)
                {
                    floor += "*";
                }
                for (int emptySpace = 0; emptySpace < floorsCount - i-1; emptySpace++)
                {
                    floor += " ";
                }
                floor += "'";
                tower[i] = floor;
            }
            return tower;
        }

        public static string[] BestTowerBuilder(int nFloors)
        {
            var result = new string[nFloors];
            for (int i = 0; i < nFloors; i++)
                //Красивое решение, на каждой итерации создается новая строка, состоящая из 3х обьедененных новых строк.
                result[i] = string.Concat(new string(' ', nFloors - i - 1),
                                          new string('*', i * 2 + 1),
                                          new string(' ', nFloors - i - 1));
            return result;
        }

        public static int TripleDouble(long num1, long num2)
        {
            

            return Enumerable.Range(1, 9).Where(i => num1.ToString().Split().Contains(new string(Convert.ToChar(i), 3))).FirstOrDefault() ;
        }


        public static int BouncingBall(double height, double bounceK, double window)
        {
            return (height < 0 || bounceK < 0 || bounceK > 1 || window > height) ? -1 : 0;
            
            for (double i = height; i < window; i*=bounceK)
            {

            }

            

        }
    }
}
