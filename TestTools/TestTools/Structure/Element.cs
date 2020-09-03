using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools.Helpers;
using TestTools.Structure.Exceptions;

namespace TestTools.Structure
{
    public abstract class Element : IElement
    {
        public abstract string Name { get; }
        public IElement PreviousElement { get; set; }

        public object GetValueOfPreviousElement(object instance)
        {
            if (PreviousElement is IAccessible accessible)
                instance = accessible.Get(instance);
            
            else if (PreviousElement is ClassElement classDefinition)
            {
                if (instance == null)
                    throw new ElementNullException(PreviousElement);
                else if (!TypeHelper.IsOfType(classDefinition.Type, instance))
                    throw new Exception($"INTERNAL: Value {instance} is not an instance of {classDefinition.Type}");
            }
            return instance;
        }
    }
}
