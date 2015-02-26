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

        static char* reverseCstring(char* s)
        {
            char* right = s;
            char* left = s;
            char tmp;


            while (*right != '\0')
                right++;

            while (left < right)
            {
                tmp = *left;
                *left = *right;
                *right = tmp;

                left++;
                right--;

            }


            return s;
        }

        static String removeDup(String s)
        {
            int bitArray = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int unicodeValue = s[i] - 97;
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

        static void anagrams(String s1, String s2)
        {
            if (s1.Length != s2.Length)
            {
                Console.WriteLine("Pas anagram");
                return;
            }

            foreach (char c in s1)
            {
                s1 = s1.Replace("" + c, "");
                s2 = s2.Replace("" + c, "");
            }
            if (s1.Length == 0 && s2.Length == 0)
            {
                Console.WriteLine("Anagram");
            }
            else
            {

                Console.WriteLine("Nope!");
            }


        }
        static void replaceSpace(String s)
        {

        }

        static void rotateGrid(char[][] grid, int N)
        {

            printGrid(grid, N);
            int nbInner = (int)Math.Ceiling((Convert.ToDecimal(N) / 2));
            for (int i = 0; i < nbInner; i++)
            {
                for (int j = 0; j < N - i - 1; j++)
                {
                    int floor = i;
                    int top = (N - 1) - i;

                    char t1 = grid[i][i + j];
                    char t2 = grid[j + i][top];
                    char t3 = grid[top][top - j];
                    char t4 = grid[top - j][i];


                    grid[i][i + j] = t4;
                    grid[j + i][top] = t1;
                    grid[top][top - j] = t2;
                    grid[top - j][i] = t3;

                }
            }
            Console.WriteLine();
            printGrid(grid, N);

        }
        static void printGrid(char[][] grid, int N)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(string.Format("{0} ", grid[i][j]));
                }
                Console.Write(Environment.NewLine);
            }
        }


        static void setEmptyCrossInGrid(int[,] grid)
        {
            printGrid2(grid);
            Console.WriteLine();
            int[,] grid2 = new int[grid.GetLength(0), grid.GetLength(1)];
            for (int i = 0; i < grid2.Length; i++) { grid2[i % grid2.GetLength(0), i / grid2.GetLength(0)] = -1; }

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == 0 )
                    {
                        for (int r = 0; r < grid2.GetLength(0); r++)
                        {
                            grid2[r, j] = 0;
                        }
                        for (int c = 0; c < grid2.GetLength(1); c++)
                        {
                            grid2[i, c] = 0;
                        }

                    }
                    else if (grid2[i, j] != 0)
                    {

                        grid2[i, j] = grid[i, j];
                    }

                }
            }
            printGrid2(grid2);
        }
        static void printGrid2(int[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0}", grid[i, j]));
                }
                Console.Write(Environment.NewLine);
            }
        }



        static void Main(string[] args)
        {
            char[][] grid = {new char[] {'a','b','c','d'},
                             new char[] {'e','f','g','h'},
                             new char[] {'i','j','k','l'},
                            new char[] {'m','n','o','p'}};

            //rotateGrid(grid, 4);

            int[,] test = new int[,] { { 1, 4, 5, 6, 2 }, { 3, 0, 1, 1, 4 }, { 5, 5, 5, 5, 6 }, { 0, 7, 7, 7, 8 } };
            Console.WriteLine("Line : {0}, Col: {1}, nbElem: {2}", test.Rank, test.GetLength(0), test.Length);
            setEmptyCrossInGrid(test);


            //reverseCstring(ref cstring);
            //Console.WriteLine((new string(t)));
            //string s = "abbcccccccffded";

            // anagrams("silent", "listen");
            // anagrams("listena", "silenta");
            //  String cleaned = removeDup(s);
            // Console.WriteLine(cleaned);
            Console.Read();

        }
    }
}
