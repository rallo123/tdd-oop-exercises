using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure.Exceptions
{
    public class EmptyNamespaceException : InvalidStructureException
    {
        public EmptyNamespaceException(string namespaceName)
            : base("Namespace {0} does not contain any members", namespaceName)
        {
        }
    }
}
