using System;
using System.Collections.Generic;
using System.Text;
using static TestTools.Helpers.FormatHelper;

namespace TestTools.Structure.Exceptions
{
    public class InvalidMethodReturnTypeException : InvalidStructureException
    {
        public InvalidMethodReturnTypeException(Type @class, MethodOptions options)
            : base("{0}.{1}'s return type is not {2}", FormatType(@class), FormatMethodAccess(@class, options), FormatType(options.ReturnType))
        {
            Type = @class;
            Options = options;
        }

        public Type Type { get; }
        public MethodOptions Options { get; }
    }
}
