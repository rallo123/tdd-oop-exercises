using System;
using System.Collections.Generic;
using System.Text;
using static TestTools.Helpers.FormatHelper;

namespace TestTools.Structure.Exceptions
{
    public class InvalidPropertyGetDeclaringTypeException : InvalidStructureException
    {
        public InvalidPropertyGetDeclaringTypeException(Type @class, PropertyRequirements options)
            : base("{0} does not declare its own version of {1} get accessor", FormatType(@class), options.Name)
        {
            Type = @class;
            Options = options;
        }

        public Type Type { get; }
        public PropertyRequirements Options { get; }
    }
}
