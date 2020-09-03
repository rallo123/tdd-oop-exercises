using System;
using System.Collections.Generic;
using System.Text;
using TestTools.Helpers;
using TestTools.Structure;
using TestTools.Structure.Exceptions;

namespace TestTools.Errors
{
    public class PropertyMissingGetException : InvalidStructureException
    {
        public PropertyMissingGetException(Type @class, PropertyOptions options)
            : base("{0} property {1} is missing get accessor", FormatHelper.FormatType(@class), options.Name)
        {
            Type = @class;
            Options = options;
        }

        public Type Type { get; }
        public PropertyOptions Options { get; }
    }
}
