using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TestTools.Structure;
using TestTools.Unit;
using Lecture_3_Solutions;
using static Lecture_3_Tests.TestHelper;

namespace Lecture_3_Tests
{
    [TestClass]
    public class Exercise_6_Tests
    {
        #region Exercise 6A
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

            UnitTest test = Factory.CreateTest();
            TestVariable<FileExplorer> explorer = test.CreateVariable<FileExplorer>();
            TestConsole console = test.CaptureConsole();
            DirectoryInfo directoryInfo = new DirectoryInfo("../../../");

            test.Arrange(explorer, Expr(() => new FileExplorer()));
            test.Act(Expr(explorer, e => e.PrintDirectory(directoryInfo)));
            console.Assert.HasWritten(ProduceExpected(directoryInfo));

            test.Execute();
        }
        #endregion
    }
}
