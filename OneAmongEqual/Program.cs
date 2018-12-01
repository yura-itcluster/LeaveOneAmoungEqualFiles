using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneAmongEqual
{
    class Program
    {
        static bool FileEquals(string path1, string path2)
        {
            byte[] file1 = File.ReadAllBytes(path1);
            byte[] file2 = File.ReadAllBytes(path2);
            if (file1.Length == file2.Length)
            {
                for (int i = 0; i < file1.Length; i++)
                {
                    if (file1[i] != file2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        static void Method0(string PATH, int j)
        {
            FileInfo[] files = new DirectoryInfo(PATH).GetFiles().ToArray();
            if (j < files.Length - 1)
            {
                string path1 = PATH + @"\" + files[j].Name;
                for (int i = j + 1; i < files.Length; i++)
                {
                    string path2 = PATH + @"\" + files[i].Name;
                    if (FileEquals(path1, path2))
                    {
                        files[i].Delete();
                    }
                }

            }
        }
        static void MainMethod(string PATH)
        {

            if (new DirectoryInfo(PATH).GetFiles().Length > 1)
            {
                int j = 0;

                do
                {
                    Method0(PATH, j);
                    j++;
                }
                while (j < new DirectoryInfo(PATH).GetFiles().Length);

            }
        }
        static void Main(string[] args)
        {
            string PATH = @"D:\S";
            // write the path
            MainMethod(PATH);
            Console.ReadKey();
        }
    }
}