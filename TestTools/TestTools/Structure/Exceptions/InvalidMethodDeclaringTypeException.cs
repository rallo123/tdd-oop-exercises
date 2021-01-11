using System;
using System.Collections.Generic;
using System.Text;
using static TestTools.Helpers.FormatHelper;

namespace TestTools.Structure.Exceptions
{
    public class InvalidMethodDeclaringTypeException : InvalidStructureException
    {
        public InvalidMethodDeclaringTypeException(Type @class, MethodRequirements options) 
            : base("{0} does not declare its own version of {1}", FormatType(@class), FormatMethodDeclaration(options))
        {
            Type = @class;
            Options = options;
        }

        public Type Type { get; }
        public MethodRequirements Options { get; }
    }
}
