using System;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathLine;
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
            
            char choise;
            do
            {
                FileManager fm = new FileManager(pathLine);

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
                        FileManager.Replace(fm.PathLine);
                        break;
                    case 'd':
                        FileManager.Delete(fm.PathLine);
                        break;
                    case 'f':
                        FileManager.Find(fm.PathLine);
                        break;
                    default:
                        Console.WriteLine("RT");
                        break;
                }
            } while (true);

        }
    }
}
