using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools.Helpers;

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
                if(instance == null)
                {
                    string errorMessage = String.Format(
                        ErrorCodes.ElementIsNull,
                        FormatHelper.FormatDefinitionChain(PreviousElement)
                    );
                    throw new AssertFailedException(errorMessage);
                }
                else if (!TypeHelper.IsOfType(classDefinition.Type, instance))
                {
                    string errorMessage = String.Format(
                        ErrorCodes.ObjectIsWrongType,
                        ObjectMethodRegistry.ToString(instance),
                        FormatHelper.FormatType(classDefinition.Type)
                    );
                    throw new AssertFailedException(errorMessage);
                }
            }
            return instance;
        }
    }
}
