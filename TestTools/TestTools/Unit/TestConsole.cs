using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;

namespace TestTools.Unit
{
    public class TestConsole
    {
        // writes to stdin
        public void Act(Expression<Action<StreamWriter>> action)
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
