using System;
using System.Collections.Generic;
using System.Text;
using TestTools.Helpers;

namespace TestTools.Structure.Exceptions
{
    public class MissingConstructorException : InvalidStructureException
    {
        public MissingConstructorException(Type @class, ConstructorRequirements options)
            : base ("{0} does not contain constructor {1}", FormatHelper.FormatType(@class), FormatHelper.FormatConstructorDeclaration(@class, options))
        {
            Type = @class;
            Options = options;
        }

        public Type Type { get; }
        public ConstructorRequirements Options { get; }
    }
}
