using System;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Find()
        {

        }
        static void Main(string[] args)
        {
            string pathLine;
            string findWord;
            while (true)
            {
                Console.WriteLine("Input path to file!");
                pathLine = Console.ReadLine();

                if (File.Exists(pathLine))
                {
                    Console.WriteLine("File exists!");
                    break;
                }
                else
                {
                    Console.WriteLine("File does not exist!");
                    continue;
                }
            }
            do
            {
                Console.WriteLine("Input a word for find!");
                findWord = Console.ReadLine();

                string readText = File.ReadAllText(pathLine);

                string[] splitedText = readText.Split(' ');

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
            }
            while(findWord != null);

            //D:\Words.txt
            //sit

            char choise;
            do
            {
                Console.WriteLine("Commands: " + "\n" + "***********************");
                Console.WriteLine("f - find word;");
                Console.WriteLine("r - replace word;");
                Console.WriteLine("d - delete word;");

                Console.WriteLine("Make a choise!");
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
            }
            while (choise != ' ');


            switch (choise)
            {
                case 'r':

                    break;
                case 'd':

                    break;

                case 'f':

                    break;
                default:
                    Console.WriteLine("RT");
                    break;
            }
        }
    }
}
