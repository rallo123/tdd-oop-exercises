using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure
{
    public interface IElement
    {
        string Name { get; }
        IElement PreviousElement { get; set; }
    }
}