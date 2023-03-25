using System.Net.Http.Headers;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Spartial_String_arrangement_and_detection
{
    internal class Program
    {
        public static Dictionary<char, int> Count(string str)
        {
            return str.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
        }
        public static string Likes(string[] name)
        {
            switch (name.Length)//=> name.Length switch
            {
                case 0: return "no one likes this"; // :(
                case 1: return $"{name[0]} likes this";
                case 2: return $"{name[0]} and {name[1]} like this";
                case 3: return $"{name[0]}, {name[1]} and {name[2]} like this";
                default: return $"{name[0]}, {name[1]} and {name.Length - 2} others like this";
            }
        }
        public static string ReverseWords(string str)
        {
            return string.Join(" ", str.Split(' ').Select(i => new string(i.Reverse().ToArray())));
        }
        public static string Check(string s)
        {
            string result = "invalid"; int k = 0; string s2 = "";
            if (s.Length % 2 != 0) return result;
            if (s == "()") { result = "valid"; return result; }
            if (s.Length > 2) { s2 = s.Replace("()", ""); }
            if (s2.Length % 2 == 0) { k = s2.Length / 2; }
            if (s2.Length % 2 != 0) { return result; }
            string s21 = s.Substring(0, k);
            string s22 = s.Substring(k + 1, k);
            List<string> test = new List<string>();
            List<string> test1 = new List<string>();
            //int a = s.Split('[').Length - 1;
            //int a1 = s.Split(']').Length - 1;
            int b = s.Split('(').Length - 1;
            int b1 = s.Split(')').Length - 1;
            int c = s2.Split('(').Length - 1;
            int c1 = s2.Split(')').Length - 1;
            List<int> chk = new List<int>();
            //check if all ')' come before '(' 
            if (s[0] == ')' || s[0] == ']' || s[s.Length - 1] == '(' || s[s.Length - 1] == '[') return result;
            //if (s2.All(a => a == ')' && (s2.IndexOf(a) < s2.IndexOf('(')))) return result;
            //if (a != a1) return result;
            if (b != b1) return result;
            if (c != c1) return result;
            if (s22 != new string(')', s2.Length)) return result;
            result = "valid";
            return result;
        }
        //Max Distance betweeen charaacters.
        static int MaxDistancebtwCharacters(string s)
        {
            List<string> arr = Array.ConvertAll(s.ToCharArray(), a => a.ToString()).ToList();
            Dictionary<string, int> results = new Dictionary<string, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (results.ContainsKey(s[i].ToString()) && i == arr.LastIndexOf(s[i].ToString()))
                {
                    int b = results.Where(a => a.Key == s[i].ToString()).First().Value;
                    results.Remove(s[i].ToString()); results.Add(s[i].ToString(), i - b);
                }
                int c = s.Split(s[i].ToString()).Length - 1;
                if (!results.ContainsKey(s[i].ToString()) && c > 1) { results.Add(s[i].ToString(), i); }
            }
            return results.Values.Max() - 1;
        }
        static int swap(int num)
        {
            int b = 0;
            string a = string.Join("", num.ToString().Reverse());
            int result = (int.TryParse(a, out b)) ? b : num;
            return result;
        }

        static bool qual(int[] numbers)
        {
            List<int> lis = numbers.ToList();
            bool result = numbers.Zip(lis.Skip(1), (a, b) => a.CompareTo(b) < 0)
        .All(b => b);
            return result;
        }

        static bool solution1(int[] numbers)
        {
            bool result = false;
         
            if (qual(numbers)) return true;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i + 1 <= numbers.Length - 1 && numbers[i] > numbers[i + 1]) { numbers[numbers.ToList().IndexOf(numbers[i])] = swap(numbers[i]); }
                if (qual(numbers)) return true;
            }
            return result;
        }

        static void Main1(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                int E = int.Parse(Console.ReadLine());
            }

            // Write an answer using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Console.WriteLine("answer");
        }
        static void Main(string[] args) 
        {
            //string s = "((((()))))()()(())";
            //string s1 = "()))))((((()))))))";
            //string test = "abstqayqjktla";
            //Console.WriteLine(Check(s1));
            //Console.Write(MaxDistancebtwCharacters(test));
        }
    }

    public class Node
    {
        public int Value;
        public Node Left;
        public Node Right;
    }

    public class BST
    {
        public Node Root;

        public int LongestPathOnLeft()
        {
            int maxLength = 0;
            LongestPathOnLeftHelper(Root, ref maxLength);
            return maxLength;
        }

        private void LongestPathOnLeftHelper(Node node, ref int maxLength)
        {
            if (node == null)
            {
                return;
            }

            // Check if the left path is longer
            int leftLength = PathLength(node.Left);
            if (leftLength > maxLength)
            {
                maxLength = leftLength;
            }

            // Recurse on the left child
            LongestPathOnLeftHelper(node.Left, ref maxLength);

            // Recurse on the right child
            LongestPathOnLeftHelper(node.Right, ref maxLength);
        }

        public int LongestPathOnRight()
        {
            int maxLength = 0;
            LongestPathOnRightHelper(Root, ref maxLength);
            return maxLength;
        }

        private void LongestPathOnRightHelper(Node node, ref int maxLength)
        {
            if (node == null)
            {
                return;
            }

            // Check if the right path is longer
            int rightLength = PathLength(node.Right);
            if (rightLength > maxLength)
            {
                maxLength = rightLength;
            }

            // Recurse on the right child
            LongestPathOnRightHelper(node.Right, ref maxLength);

            // Recurse on the left child
            LongestPathOnRightHelper(node.Left, ref maxLength);
        }

        private int PathLength(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            int leftPathLength = PathLength(node.Left);
            int rightPathLength = PathLength(node.Right);

            // Return the maximum path length between left and right paths
            return 1 + Math.Max(leftPathLength, rightPathLength);
        }
    }

}