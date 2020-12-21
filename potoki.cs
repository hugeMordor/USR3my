using System.Text;
using System.IO;
using System;

namespace potoki_i_fayly
{
    class potoki
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ВВедите путь к файлу: ");
            string path = Console.ReadLine();
            //string path = @"C:\Users\Home\Desktop\";
            
            //string newpath = @"D:\.Programms\";
            string text;
            FileInfo fileinf = new FileInfo(path);
            if (fileinf.Exists)
            {
                Console.WriteLine("file exists");
                Console.WriteLine("name:{0} ", fileinf.Name);
                Console.WriteLine("path:{0} ", fileinf.DirectoryName);
                Console.WriteLine("full name:{0} ", fileinf.FullName);
                Console.WriteLine("Введите новый путь для копирования  файла: ");
                string newpath = Console.ReadLine();
                Console.WriteLine("Введите новый путь для перемещения  файла: ");
                string newpath2 = Console.ReadLine();
                try 
                {
                    fileinf.CopyTo(newpath, true);
                    fileinf.MoveTo(newpath2);
                }
                catch
                {
                    Console.WriteLine("файл уже перемещен");
                }
                fileinf.Delete();
            }
            else
            {
                Console.WriteLine("file does not exists");
            }
        Repeat:
            ConsoleKeyInfo rep;
            Console.WriteLine("Введите текст для файла: ");
            text = Console.ReadLine();
            string secpath = @"D:\.Programms\newText.txt";
            FileStream newfile = new FileStream(secpath,FileMode.Append,FileAccess.Write);
            StreamWriter writer = new StreamWriter(newfile);
            writer.WriteLine(text);
            writer.Close();
            StreamReader reader = new StreamReader(secpath);
            Console.ReadLine();
            Console.WriteLine(reader.ReadToEnd());
            reader.Close();
            Console.WriteLine("y repeat  n exit");
            rep = Console.ReadKey(true);
            if(rep.Key == ConsoleKey.Y) goto Repeat;

            if(rep.Key == ConsoleKey.N) return;
        }
    }
}
