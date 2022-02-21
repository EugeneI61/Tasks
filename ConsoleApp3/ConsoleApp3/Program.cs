using System;
using System.IO;

namespace ConsoleApp3
{
    class Program
    {
        public static void Find(string Str)
        {
            Console.WriteLine("Input a word for find!");

            string findWord = Console.ReadLine();

            int wordsCounter = 0;

            char[] separator = new char[] { ' ', '.', ',', '!', '?', '-' };

            string[] splitedText = Str.Split(separator, StringSplitOptions.RemoveEmptyEntries);

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
            Console.WriteLine("Count: " + wordsCounter + "\n");
        }

        public static string Delete(string Str)
        {
            Console.WriteLine("Input a word for Deleting!" + "\n");
            string deleteWord = Console.ReadLine();

            int deleteCounter = 0;

            char[] separator = new char[] { ' ', '.', ',', '!', '?', '-' };

            string[] splitedText = Str.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < splitedText.Length; i++)
            {
                if (String.Equals(splitedText[i], deleteWord, StringComparison.CurrentCultureIgnoreCase))
                {
                    Str = Str.Replace(deleteWord, "", StringComparison.CurrentCultureIgnoreCase);
                    deleteCounter++;
                }
            }
            Console.WriteLine("Was delete: " + deleteCounter + "\n");
            return Str;
        }

        public static string Replace(string Str)
        {
            Console.WriteLine("Input a word for Replace" + "\n");

            string replaceWord = Console.ReadLine();

            Console.WriteLine("Input a word for Write!" + "\n");

            string writeWord = Console.ReadLine();

            char[] separator = new char[] { ' ', '.', ',', '!', '?', '-' };

            string[] splitedText = Str.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < splitedText.Length; i++)
            {
                if (String.Equals(splitedText[i], replaceWord, StringComparison.CurrentCultureIgnoreCase))
                {
                    Str = Str.Replace(replaceWord, writeWord, StringComparison.CurrentCultureIgnoreCase);
                }
            }

            return Str;
        }

        static void Main(string[] args)
        {
            FileManager fm = new(" ", " ");

            fm.Check();
            //D:\Words.txt

            char choise;
            do
            {
                Console.WriteLine("Commands: " + "\n" + "***********************");
                Console.WriteLine("f - find word;");
                Console.WriteLine("r - replace word;");
                Console.WriteLine("d - delete word;");
                Console.WriteLine();

                Console.WriteLine("Make a chose!" + "\n");

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
                        fm.Write(Replace(fm.Read()));
                        break;
                    case 'd':
                        fm.Write(Delete(fm.Read()));
                        break;
                    case 'f':
                        Find(fm.Read());
                        break;
                    default:
                        Console.WriteLine("RT");
                        break;
                }
            } while (true);

        }
    }
}
