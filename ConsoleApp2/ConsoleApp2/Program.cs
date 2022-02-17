using System;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        public  void Find(string pathLine)
        {
            Console.WriteLine("Input a word for find!");

            string findWord = Console.ReadLine();

            int wordsCounter = 0;

            for (int i = 0; i < splitedText.Length; i++)
            {
                if (String.Equals(splitedText[i], findWord, StringComparison.CurrentCultureIgnoreCase))
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

        public static void Delete(string pathLine)
        {
            Console.WriteLine("Input a word for Deleting!");
            string deleteWord = Console.ReadLine();
            Console.WriteLine();

            //fm.Read(pathLine);

            int deleteCounter = 0;

            char[] separator = new char[] { ' ', '.', ',', '!', '?', '-' };

            string str = string.Empty;

            string[] splitedText = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < splitedText.Length; i++)
            {
                if (String.Equals(splitedText[i], deleteWord, StringComparison.CurrentCultureIgnoreCase))
                {
                    str = str.Replace(deleteWord, "", StringComparison.CurrentCultureIgnoreCase);
                    deleteCounter++;
                }
            }
            Console.WriteLine("Was delete: " + deleteCounter);
            Console.WriteLine();
        }

        public static void Replace(string pathLine)
        {
            Console.WriteLine("Input a word for Replace");
            string replaceWord = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Input a word for Write!");

            Console.WriteLine();
            string writeWord = Console.ReadLine();

            string str = String.Empty;
            using (StreamReader reader = File.OpenText(pathLine))
            {
                str = reader.ReadToEnd();
            }

            str = str.Replace(replaceWord, writeWord, StringComparison.CurrentCultureIgnoreCase);
        }

        static void Main(string[] args)
        {
            FileManager fm = new FileManager(pathLine: "");
            
            fm.Check();

            string s = fm.str;

            //D:\Words.txt

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
                        Replace(fm.PathLine);
                        break;
                    case 'd':
                        Delete(fm.PathLine);
                        break;
                    case 'f':
                        //Find(fm.PathLine);
                        break;
                    default:
                        Console.WriteLine("RT");
                        break;
                }
            } while (true);

        }
    }
}
