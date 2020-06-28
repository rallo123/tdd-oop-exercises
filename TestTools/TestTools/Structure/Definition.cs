using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static TestTools.Structure.Helper;

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
                    string chain = FormatDefinitionChain(PreviousDefinition);
                    throw new AssertFailedException($"{chain} cannot be null");
                }
                else if (!Helper.IsOfType(instance, classDefinition.Type))
                {
                    string formattedInstance = ObjectMethodRegistry.ToString(instance);
                    string formattedClass = FormatType(classDefinition.Type);
                    throw new AssertFailedException($"{formattedInstance} is not of type {formattedClass}");
                }
            }
            return instance;
        }
    }
}
