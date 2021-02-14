using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using NSubstitute;
using TestTools.Syntax;
using System.Reflection;

namespace TestTools_Tests.Syntax
{
    [TestClass]
    public class SyntaxVisitorTests
    {
        class FixtureAttribute : Attribute, ISyntaxTransformer
        {
            public Expression Transform(Expression expression)
            {
                return Expression.Constant(5);
            }
        }

        class Fixture
        {
            [FixtureAttribute]
            static int Field;
        }

        FieldInfo FixureField = typeof(Fixture).GetField("Field");

        [TestMethod]
        public void Visit_AppliesTransformOnFieldExpression()
        {
            Expression input = Expression.Field(null, FixureField);
            Expression expected = Expression.Constant(5);
            SyntaxVisitor visitor = new SyntaxVisitor();

            Expression actual = visitor.Visit(input);

            Assert.AreEqual(expected, actual);            
        }

    }
}
