using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Find(string pathLine)
        {
            Console.WriteLine("Input a word for find!");
            string findWord = Console.ReadLine();

            string readText = File.ReadAllText(pathLine);

            char[] separator = new char[] { ' ', '.', ',', '!', '?', '-' };

            string[] splitedText = readText.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            int wordsCounter = 0;

            for (int i = 0; i < splitedText.Length; i++)
            {
                //Console.WriteLine(splitedText[i]);
                if (string.Equals(splitedText[i], findWord, StringComparison.CurrentCultureIgnoreCase))
                {
                    wordsCounter++;
                }
                else
                {
                    continue;
                }
            }
            Console.WriteLine("Count: " + wordsCounter);
            Console.WriteLine();
        }

        static void Delete(string pathLine)
        {
            Console.WriteLine("Input a word for Delete!");
            string deleteWord = Console.ReadLine();
            Console.WriteLine();

            string str = string.Empty;
            using (System.IO.StreamReader reader = System.IO.File.OpenText(pathLine))
            {
                str = reader.ReadToEnd();
            }

            str = str.Replace(deleteWord, "", StringComparison.CurrentCultureIgnoreCase);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(pathLine))
            {
                file.Write(str);
            }
        }

        static void Replace(string pathLine)
        {
            Console.WriteLine("Input a word for Replace");
            string replaceWord = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Input a word for Write!");
            Console.WriteLine();
            string writeWord = Console.ReadLine();

            string str = string.Empty;
            using (System.IO.StreamReader reader = System.IO.File.OpenText(pathLine))
            {
                str = reader.ReadToEnd();
            }

            str = str.Replace(replaceWord, writeWord, StringComparison.CurrentCultureIgnoreCase);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(pathLine))
            {
                file.Write(str);
            }

        }

        static void Main(string[] args)
        {
            string pathLine;
            // string findWord;
            while (true)
            {
                Console.WriteLine("Input path to file!");
                pathLine = Console.ReadLine();

                if (File.Exists(pathLine))
                {
                    Console.WriteLine("File exists!");
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine("File does not exist!");
                    Console.WriteLine();
                    continue;
                }
            }

            //D:\Words.txt
            //sit
            //Faucibus

            char choise;
            do
            {
                Console.WriteLine("Commands: " + "\n" + "***********************");
                Console.WriteLine("f - find word;");
                Console.WriteLine("r - replace word;");
                Console.WriteLine("d - delete word;");
                Console.WriteLine();

                Console.WriteLine("Make a chose!");
                Console.WriteLine();
                string smallChoise = Console.ReadLine();
                if (Char.TryParse(smallChoise, out choise) && (choise == 'r' || choise == 'f' || choise == 'd'))
                {
                    Console.WriteLine("Good!");
                }
                else
                {
                    Console.WriteLine("Wrong symbol!");
                    continue;
                }
                switch (choise)
                {
                    case 'r':
                        Replace(pathLine);
                        break;
                    case 'd':
                        Delete(pathLine);
                        break;

                    case 'f':
                        Find(pathLine);
                        break;
                    default:
                        Console.WriteLine("RT");
                        break;
                }
            } while (true);

        }
    }
}
