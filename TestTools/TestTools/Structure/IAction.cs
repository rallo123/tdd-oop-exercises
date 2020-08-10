using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure
{
    public interface IAction
    {
        public abstract void Invoke(object instance, object[] parameters);
    }
}
