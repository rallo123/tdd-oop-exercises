using System;
using System.Collections.Generic;
using System.Text;
using TestTools.Helpers;
using TestTools.Structure;
using TestTools.Structure.Exceptions;

namespace TestTools.Errors
{
    public class PropertyMissingSetException : InvalidStructureException
    {
        public PropertyMissingSetException(Type @class, PropertyRequirements options)
            : base("{0} property {1} is missing set accessor", FormatHelper.FormatType(@class), options.Name)
        {
            Type = @class;
            Options = options;
        }

        public Type Type { get; }
        public PropertyRequirements Options { get; }
    }
}
