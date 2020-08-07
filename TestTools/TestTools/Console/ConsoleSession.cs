using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTools.ConsoleSession
{
    public class ConsoleSession
    {
        private string stdinContent = "";
        private string expectedContent = "";
        
        public ConsoleSession() { }

        public void In(string input)
        {
            stdinContent += ReplaceNewLine(input);
            expectedContent += ReplaceNewLine(input);
        }

        public void Out(string output)
        {
            expectedContent += ReplaceNewLine(output);
        }

        public void Start(Action action)
        {
            StringBuilder logger = new StringBuilder();
            
            LoggedTextReader stdin = new LoggedTextReader(stdinContent, logger);
            LoggedTextWriter stdout = new LoggedTextWriter(logger);
            LoggedTextWriter stderr = new LoggedTextWriter(logger);

            TextReader originalStdin = Console.In;
            TextWriter originalStdout = Console.Out;
            TextWriter originalStderr = Console.Error;

            Console.SetIn(stdin);
            Console.SetOut(stdout);
            Console.SetError(stderr);
            
            action();

            Console.SetIn(originalStdin);
            Console.SetOut(originalStdout);
            Console.SetError(originalStderr);
        
            string actualContent = logger.ToString();
            ReportExpectedAndActual(expectedContent, actualContent);
            if (!AreExpectedAndActualEqual(expectedContent, actualContent))
                throw new AssertFailedException("Expected and actual output (might) differ");
        } 

        private string ReplaceNewLine(string str)
        {
            return str.Replace("\n", Environment.NewLine);
        }

        private static void ReportExpectedAndActual(string expected, string actual)
        {
            Console.WriteLine("# Expected: ");
            Console.WriteLine(!string.IsNullOrEmpty(expected) ? expected.TrimEnd() : "no output");
            Console.WriteLine();
            Console.WriteLine("# Actual: ");
            Console.WriteLine(!string.IsNullOrEmpty(actual) ? actual.TrimEnd() : "no output");
        }

        private static bool AreExpectedAndActualEqual(string expected, string actual)
        {
            string[] splitIntoLines(string input) => input.Trim().Split(Environment.NewLine).Select(l => l.Trim()).ToArray();

            string[] expectedLines = splitIntoLines(expected);
            string[] actualLines = splitIntoLines(actual);

            if (expectedLines.Length != actualLines.Length)
                return false;

            for(int i = 0; i < expectedLines.Length; i++)
            {
                if (expectedLines[i] != actualLines[i])
                    return false;
            }

            return true;
        }


    }
}
