using System;
using System.Collections.Generic;
using System.Text;
using static TestTools.Helpers.FormatHelper;

namespace TestTools.Structure.Exceptions
{
    public class InvalidFieldTypeException : InvalidStructureException
    {
        public InvalidFieldTypeException(Type @class, FieldRequirements options)
            : base("{0}.{1} is not of type {2}", FormatType(@class), options.Name, FormatType(options.FieldType))
        {
            Type = @class;
            Options = options;
        }

        public Type Type { get; }
        public FieldRequirements Options { get; }
    }
}
