using System;
using System.IO;

class FileManager
{
    public string PathLine;

    public string Str;
    public FileManager(string pathLine, string str)
    {
        PathLine = pathLine;

        Str = str;
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
                break;
            }
            else
            {
                Console.WriteLine("File does not exist!" + "\n");
                continue;
            }
        }
    }

    public void Write(string str)
    {
        using (StreamWriter writer = new StreamWriter(PathLine, false))
        {
            writer.Write(str);
        }
    }

    public string Read()
    {
        using (StreamReader reader = File.OpenText(PathLine))
        {
            Str = reader.ReadToEnd();
        }
        //Console.WriteLine("sick + " + Str);
        return Str;

    }
}