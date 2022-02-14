using System;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
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

            Console.WriteLine("Input a word for find!");
            findWord = Console.ReadLine();

            string readText = File.ReadAllText(pathLine);

            string[] splitedText = readText.Split(' ');

            int counter = 0;    

            for (int i = 0; i < splitedText.Length; i++)
            {
                //Console.WriteLine(splitedText[i]);
                if(string.Equals(splitedText[i], findWord, StringComparison.CurrentCultureIgnoreCase))
                {
                    counter++;
                }
                else
                {
                    continue;
                }
            }
            Console.WriteLine("Count: " + counter);

            //D:\Words.txt
            //sit

            //while (true)
            //{
            //    Console.WriteLine("Commands:" + "\n ***********************");
            //}
        }
    }
}
