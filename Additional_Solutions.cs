using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Spartial_String_arrangement_and_detection
{
    internal class Additional_Solutions
    {
        //Assume all bills are always available 1000, dic[50] += (amount % 100) / 50;
        public static List<int> Withdraw(int amount)
        {
            List<int> result = new List<int>();
            Dictionary<int, int> dic = new Dictionary<int, int>() { { 100, 0 }, { 50, 0 }, { 20, 0 } };
            if (amount >= 100) { dic[100] += amount / 100; amount %= 100; }
            if (amount >= 50 && amount < 100) { dic[50] += (amount / 50); amount %= 50; }
            if (amount < 50 && amount > 0) { dic[20] += (amount / 20); amount %= 20; }
            //check if theres a remainder at the end.
            if (amount != 0 && dic[50] > 0)
            {
                dic[50]--; dic[20] = (50 + amount + (dic[20]) * 20) / 20;
                foreach (var item in dic)
                {
                    result.Add(item.Value);
                }
                return result;
            }
            if (amount != 0 && dic[50] == 0)
            {
                dic[100]--; dic[50]++; dic[20] = (50 + amount + (dic[20]) * 20) / 20;
                foreach (var item in dic)
                {
                    result.Add(item.Value);

                }
                return result;
            }
            foreach (var item in dic)
            {
                result.Add(item.Value);
            }
            return result;
        }
        //complex chunks.
        public static IEnumerable<string> ChunkIter(string s, int chunks)
        {
            string[] arr = Array.ConvertAll(s.ToCharArray(), c => c.ToString());
            int[] arr2 = new int[chunks]; int p = 0;
            List<string> result = new List<string>();
            if (s.Length > 0 && s.Length <= chunks) return arr;
            if (s.Length > 0 && chunks == 0) throw new ArgumentException();
            if (s.Length == 0 && chunks >= 0) return Array.Empty<string>();
            if (s.Length > 0 && s.Length > chunks)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    int b = (s.Length - i > chunks) ? chunks : s.Length - i;
                    for (int j = 0; j < b; j++)
                    {
                        arr2[j]++;
                    }
                    i += (s.Length - i > chunks) ? chunks - 1 : s.Length - i;
                }
            }
            for (int i = 0; i < arr2.Length; i++)
            {
                result.Add(s.Substring(p, arr2[i]));
                p += arr2[i];
            }
            return result;
        }
        public static string[] Chunk(string s, int chunks)
        {
            List<string> result = new List<string>();
            result = ChunkIter(s, chunks).ToList();
            return result.ToArray();
        }


    }
}
