using Lecture_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestTools.ConsoleSession;
using TestTools.Structure;
using TestTools.Structure.Generic;

namespace Lecture_3_Tests
{
    [TestClass]
    public class Exercise_6_Tests
    {
        private ClassElement<FileExplorer> fileExplorer => new ClassElement<FileExplorer>();
        private ActionMethodElement<FileExplorer, DirectoryInfo> fileExplorerPrintDirectory => fileExplorer.ActionMethod<DirectoryInfo>("PrintDirectory", new MethodOptions() { AccessLevel = AccessLevel.Public });
        private ActionMethodElement<FileExplorer, DirectoryInfo> fileExplorerPrintTree => fileExplorer.ActionMethod<DirectoryInfo>("PrintTree", new MethodOptions() { AccessLevel = AccessLevel.Public });

        private FileExplorer CreateFileExplorer()
        {
            return fileExplorer.Constructor().Invoke();
        }

        [TestMethod("FileExplorer.PrintDirectory(DirectoryInfo info) prints correct output"), TestCategory("Exercise 6A")]
        public void FileExplorerPrintDirectoryPrintsCorrectOutput()
        {
            static string ProduceExpected(DirectoryInfo info)
            {
                string buffer = $"Directory of {info.FullName}\n\n";
                
                foreach (DirectoryInfo subDirectory in info.GetDirectories())
                    buffer += $"{subDirectory.LastWriteTime}\t<DIR>\t{subDirectory.Name}\n";
                
                foreach (FileInfo file in info.GetFiles())
                    buffer += $"{file.LastWriteTime}\t{file.Length / 1000.0}kb\t{file.Name}\n";
                
                return buffer; 
            }

            ConsoleSession session = new ConsoleSession();
            DirectoryInfo info = new DirectoryInfo("../../../");
            session.Out(ProduceExpected(info));
            session.Start(() => fileExplorerPrintDirectory.Invoke(CreateFileExplorer(), info));
        }

        /*
        [TestMethod("FileExplorer.PrintTree(DirectoryInfo info) prints correct output"), TestCategory("Exercise 6B")]
        public void FileExplorerPrintTreePrintsCorrectOutput()
        {
            string ProduceExpected(DirectoryInfo info, int depth)
            {
                string buffer = ""; 
                
                if (depth == 0)
                    buffer += info.FullName;

                foreach (DirectoryInfo subDirectory in info.GetDirectories())
                {
                    for (int i = 0; i < depth + 1; i++)
                        buffer += (i == depth - 1) ? "|---" : "|   ";
                    buffer += subDirectory.Name + "\n";
                    buffer += ProduceExpected(subDirectory, depth + 1);
                }
                foreach (FileInfo file in info.GetFiles())
                {
                    for (int i = 0; i < depth + 1; i++)
                        buffer += (i == depth - 1) ? "|---" : "|   ";
                    buffer += file.Name + "\n";
                }
                return buffer; 
            }

            ConsoleSession session = new ConsoleSession();
            DirectoryInfo info = new DirectoryInfo("../../");
            session.Out(ProduceExpected(info, 0));
            session.Start(() => fileExplorerPrintDirectory.Invoke(CreateFileExplorer(), info));
        }
        */
    }
}
