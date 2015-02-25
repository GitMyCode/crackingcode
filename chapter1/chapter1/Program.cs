using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter1
{
    unsafe
    class Program
    {


        static void checkIfUniqueChar(String s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                int occur = 0;
                for (int j = 0; j < s.Length; j++)
                {
                    if (s[j] == c)
                    {
                        occur += 1;
                    }


                }
                if (occur > 1)
                {
                    Console.WriteLine("NON pas unique");
                    return;
                }

            }
            Console.WriteLine(" OUI unique");
        }
        
        static char* reverseCstring(char *s)
        {
            
            return s;
        }
        
        static String removeDup(String s)
        {
            int bitArray = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int unicodeValue = s[i] -97;
                int shifted = 0;
                shifted = 1 << unicodeValue;
                if ((bitArray & shifted) != 0)
                {
                    if (i == s.Length - 1)
                    {
                        s = s.Substring(0, i);
                    }
                    else
                    {
                        s = s.Substring(0, i) + s.Substring(i + 1);
                        i--;
                        
                    }

                }
                else
                {
                    bitArray += 1 << unicodeValue;
                }

            }
                return s;
        }

        static void Main(string[] args)
        {

            string s = "abbcccccccffded";
          
            String cleaned = removeDup(s);
            Console.WriteLine(cleaned);
            Console.Read();
           
        }
    }
}
