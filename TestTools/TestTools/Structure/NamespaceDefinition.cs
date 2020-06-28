using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestTools.Structure
{
    public class NamespaceDefinition
    {
        readonly string namespaceName;

        public NamespaceDefinition(string namespaceName)
        {
            this.namespaceName = namespaceName;

            if(!GetTypes().Any())
                throw new AssertFailedException($"Namespace {namespaceName} does not contain any members");
        }

        public ClassDefinition Class(string className)
        {
            Type classType = GetTypes().Where(t => t.IsClass)
                                       .Where(t => t.Name == className)
                                       .FirstOrDefault();
            
            if (classType == null)
                throw new AssertFailedException($"Class ${className} does not exist in namespace {className}");

            return new ClassDefinition(classType);
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
