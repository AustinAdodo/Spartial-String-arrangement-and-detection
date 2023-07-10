using System.Net.Http.Headers;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Diagnostics.CodeAnalysis;

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

        public static IList<string> CommonChars(string[] words)
        {
            Dictionary<char, int> reg = new Dictionary<char, int>();
            string s = "";//["bella","label","roller"] -> [e,l,l]  //["cool","lock","cook"] -> [c,o]
            foreach (var item in words)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    if (words.ToList().IndexOf(item) == 0 && reg.ContainsKey(item[i])) reg[item[i]]++;
                    if (words.ToList().IndexOf(item) == 0 && !reg.ContainsKey(item[i])) reg.Add(item[i], 1);
                }
            }
            for (int i = 1; i < words.Length; i++)
            {
                foreach (KeyValuePair<char, int> kvp in reg)
                {
                    int check = words[i].Split(kvp.Key).Length - 1;
                    bool check1 = check > 0 && check < kvp.Value;
                    if (words.ToList().IndexOf(words[i]) > 0 && check == 0) reg.Remove(kvp.Key);
                    if (words.ToList().IndexOf(words[i]) > 0 && check1 && reg.ContainsKey(kvp.Key)) reg[kvp.Key] = check;
                }
            }
            foreach (KeyValuePair<Char, int> kvp in reg)
            {
                s += new string(kvp.Key, kvp.Value);
            }
            return Array.ConvertAll(s.ToCharArray(), s => s.ToString());
        }

        public static string decryptPassword(string s)
        {
            string result = ""; int b = 0;
            string[] nums = Array.ConvertAll(s.ToCharArray(), s => s.ToString()).
                Where(a => int.TryParse(a, out b) == true && a != "0").ToArray();
            int check = 1;
            for (int i = 0; i < s.Length; i++)
            {
                if (int.TryParse(s[i].ToString(), out b) == true && s[i] != '0') continue;
                if (i > 1 && i + 2 <= s.Length - 1 && s[i + 2] == '*')
                {
                    result += s[i + 1].ToString().ToLower() +
                        s[i].ToString().ToUpper(); i += 2;
                }
                if (s[i] == '*') continue;
                if (s[i] == '0') { result += nums[nums.Length - check]; check++; }
                else { result += s[i]; }
            }
            return result;
        }

        public static List<long> findSum(List<int> numbers, List<List<int>> queries)
        {
            int zeros = 0;// 20.30,0,10
            List<int> temp = new List<int>();
            int ans = 0;
            List<long> result = new List<long>();
            for (int i = 0; i < queries.Count; i++)
            {
                temp = numbers.Where((x, r) => queries[i][0] - 1 >= 0 && queries[i][1] - 1 <= numbers.Count - 1 &&
                r >= queries[i][0] - 1 && r <= queries[i][1] - 1).ToList();
                zeros = temp.Where(x => x == 0).Count();
                ans = temp.Sum() + (zeros * queries[i][2]);
                result.Add(ans);
                temp.Clear();
            }
            return result;
        }

        public static int balancedStringSplit(string s)
        {

            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (i + 1 <= s.Length - 1 &&
                    (s[i].ToString() + s[i + 1].ToString() == "LR" || s[i].ToString() + s[i + 1].ToString() == "RL"))
                {
                    result++; i++;
                }
            }
            return result;
        }

        public static List<string> DetectExteriorCells(List<string> grid)
        {
            List<List<string>> result = new List<List<string>>();
            List<string> rec = new List<string>();
            for (int i = 0; i < grid.Count; i++)
            {
                rec.Add(grid[i]);
                if (grid[i].ToString() == "\n") { result.Add(rec); rec.Clear(); }
            }
            foreach (var row in result)
            {
                for (int i = 0; i < row.Count; i++)
                {
                    //if()
                }
            }
            return new List<string>();
        }

        //public static long[][] spin(long[][] matrix)
        //{
        //    // Type your solution here
        //}
        //check TakeWhile
        static void Main(string[] args)
        {  
            //string s = "((((()))))()()(())";
            //string s1 = "()))))((((()))))))";
            //string test = "abstqayqjktla";
            //Console.WriteLine(Check(s1));
            //Console.Write(MaxDistancebtwCharacters(test));
            //string[] words = new string[] { "cool", "lock", "cook" };
            //CommonChars(words);
            //List<int> numbers = new List<int>() { 20, 30, 0, 10 };
            //List<List<int>> queries = new();
            //queries.Add(new List<int>() { 1, 3, 10 });
            //queries.Add(new List<int>() { 2, 4, 6 });
            //findSum(numbers, queries);
            //Console.Write( balancedStringSplit("LLLLRRRR"));
            //230
            //Console.Write(String.Join(" ",Additional_Solutions.Withdraw(354)));
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