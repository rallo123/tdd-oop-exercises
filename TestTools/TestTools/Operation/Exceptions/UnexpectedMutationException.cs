using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Operation.Exceptions
{
    public class UnexpectedMutationException : AssertFailedException
    {
        public UnexpectedMutationException(string variable, object actualValue, MutationOptions options)
            : base("") 
        { 
        }

        public MutationOptions Options { get; }

    }
}
