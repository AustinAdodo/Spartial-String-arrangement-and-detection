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
        //Assume all bills are always available 1000, 
        public static List<int> Withdraw(int amount)
        {
            int a, b, c;
            List<int> result = new List<int>();
            a = (amount > 100) ? (amount / 100) : 0;
            result.Add(a);
            //b = (amount % 100 > 50) ? Convert.ToInt32(Math.Floor(Convert.ToDecimal(amount % 100 / 50))) : 0;
            if (amount % 100 > 50 && (amount % 100) % 50 == 0)
            {
                result.Add((amount % 100) % 50);
            }
            if (amount % 100 > 50 && amount % 100 % 50 != 0)
            {
                result.Add(amount % 100 % 50);
            }
            c = (b % 50 > 20) ? Convert.ToInt32(Math.Floor(Convert.ToDecimal(b % 50 / 20))) : 0;
            result.Add(c);
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
            return result.ToArray();
        }


    }
}
