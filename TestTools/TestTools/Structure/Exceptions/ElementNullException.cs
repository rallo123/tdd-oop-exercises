using System;
using System.Collections.Generic;
using System.Text;
using static TestTools.Helpers.FormatHelper;

namespace TestTools.Structure.Exceptions
{
    public class ElementNullException : InvalidStructureException
    {
        public ElementNullException(IElement element)
            : base("{0} cannot be null", FormatDefinitionChain(element))
        {
            Element = element;
        }

        public IElement Element { get; }
    }
}
