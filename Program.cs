namespace Spartial_String_arrangement_and_detection
{
    internal class Program
    {
        public static string Check(string s)
        {
            string result = "invalid";
            int a = s.Split('[').Length - 1;
            int a1 = s.Split(']').Length - 1;
            int b = s.Split('(').Length - 1;
            int b1 = s.Split(')').Length - 1;
            List<int> chk = new List<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' && s[i + 1] == ')' && i + 1 <= s.Length - 1) chk.Add(1);
                if (s[i] == '[' && s[i + 1] == ']' && i + 1 <= s.Length - 1) chk.Add(1);
                //handle composites.
                if (s[i] == '(' && s[i + 1] == ']' && i + 1 <= s.Length - 1) chk.Add(0);
                if (s[i] == '[' && s[i + 1] == ')' && i + 1 <= s.Length - 1) chk.Add(0);
            }
            if (a != a1) return result;
            if (b != b1) return result;
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
                    results.Remove(s[i].ToString()); results.Add(s[i].ToString(), i-b);
                }
                int c = s.Split(s[i].ToString()).Length - 1;
                if (!results.ContainsKey(s[i].ToString()) &&  c > 1 ) { results.Add(s[i].ToString(), i); }
            }
            return results.Values.Max() - 1;
        }
        static void Main(string[] args)
        {
            string s = "((((([[[[]]]])))))";
            string test = "abstqayqjktla";
            //Console.WriteLine(Check(s));
            Console.Write(MaxDistancebtwCharacters(test));
        }
    }
}