using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestTools.Helpers;
using static TestTools.Helpers.FormatHelper;

namespace TestTools.Operation.Exceptions
{
    public abstract class InvalidResultException : AssertFailedException
    {
        public InvalidResultException(string message) 
            : base(message)
        {
        }
    }
}
