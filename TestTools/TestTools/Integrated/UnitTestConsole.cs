using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Integrated
{
    public class UnitTestConsole
    {
        public void Read(int charCode)
        {
            throw new NotImplementedException();
        }

        public void ReadKey(ConsoleKeyInfo cki)
        {
            throw new NotImplementedException();
        }

        public void ReadLine(string line)
        {
            throw new NotImplementedException();
        }

        public AssertObject Assert { get; }

        public class AssertObject
        {
            public void HasWritten(string str)
            {
                throw new NotImplementedException();
            }

            public void HasWrittenLine(string str)
            {
                throw new NotImplementedException();
            }
        }
    }
}
