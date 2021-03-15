﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TestTools.Unit
{
    // For object members
    public class TestVariable<T> : TestExpression<T>
    {
        public TestVariable(ParameterExpression expression) 
            : base(expression)
        {
        }
    }
}
