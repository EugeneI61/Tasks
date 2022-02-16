using System;
using System.IO;

namespace ConsoleApp2
{
    class FileManager
    {
        public string PathLine;
        public static void Find(string pathLine)
        {
            Console.WriteLine("Input a word for find!");
            string findWord = Console.ReadLine();

            string readText = File.ReadAllText(pathLine);

            char[] separator = new char[] { ' ', '.', ',', '!', '?', '-' };

            string[] splitedText = readText.Split(separator, StringSplitOptions.RemoveEmptyEntries);

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

            int deleteCounter = 0;

            string str = String.Empty;

            using (StreamReader reader = File.OpenText(pathLine))
            {
                str = reader.ReadToEnd();
            }

            char[] separator = new char[] { ' ', '.', ',', '!', '?', '-' };

            string[] splitedText = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < splitedText.Length; i++)
            {
                if (String.Equals(splitedText[i], deleteWord, StringComparison.CurrentCultureIgnoreCase))
                {
                    str = str.Replace(deleteWord, "", StringComparison.CurrentCultureIgnoreCase);
                    deleteCounter++;
                }
            }

            using (StreamWriter file = new StreamWriter(pathLine))
            {
                file.Write(str);
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

            using (StreamWriter file = new StreamWriter(pathLine))
            {
                file.Write(str);
            }
        }
        public FileManager(string pathLine)
        {
            this.PathLine = pathLine;
        }

    }
}
