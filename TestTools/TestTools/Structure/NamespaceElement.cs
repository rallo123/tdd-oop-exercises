using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TestTools.Structure.Exceptions;

namespace TestTools.Structure
{
    public class NamespaceElement
    {
        readonly string namespaceName;

        public NamespaceElement(string namespaceName)
        {
            this.namespaceName = namespaceName;

            if (!GetTypes().Any())
                throw new EmptyNamespaceException(namespaceName);
        }

        public ClassElement Class(string className)
        {
            Type classType = GetTypes().Where(t => t.IsClass)
                                       .Where(t => t.Name == className)
                                       .FirstOrDefault();
            
            if (classType == null)
                throw new AssertFailedException($"Class ${className} does not exist in namespace {className}");

            return new ClassElement(classType);
        }

        IEnumerable<Type> GetTypes()
        {
            return AppDomain.CurrentDomain
                            .GetAssemblies()
                            .SelectMany(t => t.GetTypes())
                            .Where(t => t.Namespace == namespaceName);
        }
    }
}
