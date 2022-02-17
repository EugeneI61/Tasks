using System;
using System.IO;

class FileManager
{
    public string PathLine;

    public string str;
    public FileManager(string pathLine)
    {
        PathLine = pathLine;
    }
    public void Check()
    {
        while (true)
        {
            Console.WriteLine("Input path to file!");
            PathLine = Console.ReadLine();

            if (File.Exists(PathLine))
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
    }

    public void Write()
    {
        string str = String.Empty;

        using (StreamWriter file = new StreamWriter(PathLine))
        {
            file.Write(str);
        }
    }

    public void Read(string pathline)
    {
        string str = String.Empty;

        char[] separator = new char[] { ' ', '.', ',', '!', '?', '-' };

        string[] splitedText = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);

        using (StreamReader reader = File.OpenText(PathLine))
        {
            str = reader.ReadToEnd();
        }
    }
}