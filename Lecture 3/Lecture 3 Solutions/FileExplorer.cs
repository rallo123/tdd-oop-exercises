using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lecture_1_Potential_Solutions
{
    public class FileExplorer
    {
        public void PrintDirectory(DirectoryInfo info)
        {
            Console.WriteLine($"Directory of {info.FullName}");
            Console.WriteLine();

            foreach (DirectoryInfo subDirectory in info.GetDirectories())
                Console.WriteLine($"{subDirectory.LastWriteTime}\t<DIR>\t{subDirectory.Name}");

            foreach (FileInfo file in info.GetFiles())
                Console.WriteLine($"{file.LastWriteTime}\t{file.Length / 1000.0}kb\t{file.Name}");
        }

        public void PrintTree(DirectoryInfo info)
        {
            PrintTree(info, 0);
        }

        private void PrintTree(DirectoryInfo info, int depth)
        {
            if (depth == 0)
                Console.WriteLine(info.FullName);

            foreach(DirectoryInfo subDirectory in info.GetDirectories())
            {
                PrintPadding(depth + 1);
                Console.WriteLine(subDirectory.Name);
            }
            foreach (FileInfo file in info.GetFiles())
            {
                PrintPadding(depth + 1);
                Console.WriteLine(file.Name);
            }
        }

        private void PrintPadding(int indent)
        {
            for (int i = 0; i < indent; i++)
            {
                if (i == indent - 1)
                    Console.Write("|---");
                else Console.Write("|   ");
            }
        }
    }
}
