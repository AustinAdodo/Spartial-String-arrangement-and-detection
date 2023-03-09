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
            string result = "invalid";
            string s2 = s.Replace("()", "");  
            //string[] arr = Array.ConvertAll(s.ToCharArray(), a => a.ToString());
            List<string> test = new List<string>(); int z = 0;
            List<string> test1 = new List<string>();
            int a = s.Split('[').Length - 1;
            int a1 = s.Split(']').Length - 1;
            int b = s.Split('(').Length - 1;
            int b1 = s.Split(')').Length - 1;
            int c = s2.Split('(').Length - 1;
            int c1 = s2.Split(')').Length - 1;
            List<int> chk = new List<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (i + 1 <= s.Length - 1 && s[i] == '(' && s[i + 1] == ')' && i + 1 <= s.Length - 1) chk.Add(1);
                if (i + 1 <= s.Length - 1 && s[i] == '[' && s[i + 1] == ']' && i + 1 <= s.Length - 1) chk.Add(1);
                //handle composites.
                if (s[0] == ')' || s[0] == ']' || s[s.Length - 1] == '(' || s[s.Length - 1] == '[') chk.Add(0);
            }
            if (s2.All(a => a == ')' && s2.IndexOf(a) < s2.IndexOf('('))) return result;
            if (a != a1) return result;
            if (b != b1) return result;
            if (c != c1) return result;
            if (!chk.Contains(0)) return "valid";
            return result;
        }
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
        static void Main(string[] args)
        {
            string s = "((((()))))()()(())";
            string s1 = "))))((((()))))))";
            string test = "abstqayqjktla";
            //Console.WriteLine(Check(s));
            //Console.Write(MaxDistancebtwCharacters(test));
        }
    }
}