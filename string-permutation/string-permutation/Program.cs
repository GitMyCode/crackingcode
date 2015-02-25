using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_permutation
{
    class Program
    {


        static void swap(ref char a, ref char b)
        {
            if (a == b)
            {
                return;
            }
            a ^= b;
            b ^= a;
            a ^= b;

        }


        static void print_permutation(char[] s, int i)
        {

            if (i == s.Length)
            {
                Console.WriteLine(s);
            }
            else
            {
                for (int j = i; j < s.Length; j++)
                {
                    swap(ref s[i], ref s[j]);
                    print_permutation(s, i + 1);
                    swap(ref s[i], ref s[j]);

                }
            }
        }



        static void permuteString(String start, String end)
        {
            if (end.Length <= 1)
            {
                Console.WriteLine(start + end);
            }
            else
            {
                for (int i = 0; i < end.Length; i++)
                {
                    String removeIchar = end.Substring(0, i) + end.Substring(i + 1);
                    permuteString((start + end[i]), removeIchar);
                }
            }
        }



        static void Main(string[] args)
        {

            string s = "abc";
            char[] test = s.ToCharArray();
            permuteString("", s);
            //print_permutation(test, 0);



            Console.Read();
        }
    }
}
