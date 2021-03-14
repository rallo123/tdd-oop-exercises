using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestTools.Unit
{
    public static class ConsoleInputter
    {
        static BufferedReader InternalReader = new BufferedReader();

        public static void Write()
        {
            Write("");
        }

        public static void Write(string input)
        {
            if (Console.In != InternalReader)
                InternalReader.CaptureConsoleIn();

            InternalReader.Buffer += input;
        }

        public static void WriteLine()
        {
            WriteLine("");
        }

        public static void WriteLine(string input)
        {
            Write(input + Environment.NewLine);
        }

        private class BufferedReader : TextReader
        {
            TextReader OriginalReader;

            string _buffer = "";

            public string Buffer
            {
                get => _buffer;
                set {
                    if (string.IsNullOrEmpty(value))
                        Console.SetIn(OriginalReader);

                    _buffer = value;
                }
            }

            public override int Read()
            {
                char charToRead = Buffer[0];

                Buffer = Buffer.Substring(1);

                return (int)charToRead;
            }

            public void CaptureConsoleIn()
            {
                // Read-in existing Console.In content
                if (Console.KeyAvailable)
                    Buffer = Console.In.ReadToEnd();

                // Take control of Console.In
                OriginalReader = Console.In;
                Console.SetIn(this);
            }
        }
    }
}
