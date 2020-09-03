using System;
using System.Collections.Generic;
using System.Text;
using static TestTools.Helpers.FormatHelper;

namespace TestTools.Structure.Exceptions
{
    public class InvalidPropertySetDeclaringTypeException : InvalidStructureException
    {
        public InvalidPropertySetDeclaringTypeException(Type @class, PropertyOptions options)
            : base("{0} does not declare its own version of {1} set accessor", FormatType(@class), options.Name)
        {
            Type = @class;
            Options = options;
        }

        public Type Type { get; }
        public PropertyOptions Options { get; }
    }
}
