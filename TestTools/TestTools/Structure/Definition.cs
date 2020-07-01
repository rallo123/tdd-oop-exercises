using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools.Helpers;

namespace TestTools.Structure
{
    public abstract class Definition {
        public abstract string Name { get; }
        public Definition PreviousDefinition { get; set; }

        public object GetValueOfPreviousDefinition(object instance)
        {
            if (PreviousDefinition is IAccessible accessible)
                instance = accessible.Get(instance);
            
            else if (PreviousDefinition is ClassDefinition classDefinition)
            {
                if(instance == null)
                {
                    string errorMessage = String.Format(
                        ErrorCodes.ElementIsNull,
                        FormatHelper.FormatDefinitionChain(PreviousDefinition)
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
