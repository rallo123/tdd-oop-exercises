using System;
using System.Collections.Generic;
using System.Text;
using TestTools.Helpers;

namespace TestTools.Structure.Exceptions
{
    public class MissingMethodException : InvalidStructureException
    {
        public MissingMethodException(Type @class, MethodRequirements options)
            : base("{0} does not contain method {1}", FormatHelper.FormatType(@class), FormatHelper.FormatMethodAccess(@class, options))
        {
            Type = @class;
            Options = options;
        }

        public Type Type { get; }
        public MethodRequirements Options { get; }
    }
}
