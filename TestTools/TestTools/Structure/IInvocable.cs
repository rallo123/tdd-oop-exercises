﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure
{
    public interface IInvocable
    {
        public abstract object Invoke(object instance, object[] parameters);
    }
}
