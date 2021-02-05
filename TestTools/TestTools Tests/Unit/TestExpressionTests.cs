using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TestTools.Unit;

namespace TestTools_Tests.Unit
{
    [TestClass]
    public class TestExpressionTests
    {
        #region Constructor Methods Tests
        [TestMethod("Expr with equal arguments returns equal TestExpressions"), TestCategory("Constructor Methods")]
        public void Expr_WithSameParameter_AreEqual()
        {
            var expr1 = TestExpression.Expr(() => 5);
            var expr2 = TestExpression.Expr(() => 5);

            Assert.AreEqual(expr1, expr2);
        }

        [TestMethod("Expr inserts 1 variable into TestExpression"), TestCategory("Constructor Methods")]
        public void Expr_Inserts1VariableIntoTestExpression()
        {
            var expression = Expression.Lambda<Action>(Expression.Parameter(typeof(int), "a"));
            var expected = TestExpression.Expr(expression);

            var variable = TestExpression.Var<int>("a");
            var actual = TestExpression.Expr(variable, a => a);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Expr inserts 2 variable into TestExpression"), TestCategory("Constructor Methods")]
        public void Expr_Inserts2VariablesIntoTestExpression()
        {
            var addition = Expression.Add(
                Expression.Parameter(typeof(int), "a"),
                Expression.Parameter(typeof(int), "b"));
            var expression = Expression.Lambda<Action>(addition);
            var expected = TestExpression.Expr(expression);

            var variable1 = TestExpression.Var<int>("a");
            var variable2 = TestExpression.Var<int>("b");
            var actual = TestExpression.Expr(variable1, variable2, (a, b) => a + b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Expr inserts 3 variable into TestExpression"), TestCategory("Constructor Methods")]
        public void Expr_Inserts3VariablesIntoTestExpression()
        {
            var addition1 = Expression.Add(
                Expression.Parameter(typeof(int), "a"),
                Expression.Parameter(typeof(int), "b"));
            var addition2 = Expression.Add(
                addition1,
                Expression.Parameter(typeof(int), "c"));
            var expression = Expression.Lambda<Action>(addition1);
            var expected = TestExpression.Expr(expression);

            var variable1 = TestExpression.Var<int>("a");
            var variable2 = TestExpression.Var<int>("b");
            var variable3 = TestExpression.Var<int>("c");
            var actual = TestExpression.Expr(variable1, variable2, variable3, (a, b, c) => a + b + c);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Const with equal arguments returns equal TestExpressions"), TestCategory("Constructor Methods")]
        public void Const_WithEqualArguments_ReturnsEqualTestExpressions()
        {
            var expr1 = TestExpression.Const(5);
            var expr2 = TestExpression.Const(5);

            Assert.AreEqual(expr1, expr2);
        }

        [TestMethod("Const(v) returns equal to Expr(() => v)"), TestCategory("Constructor Methods")]
        public void Const_MayReturnEqualToExpr()
        {
            var expected = TestExpression.Expr(() => 5);
            var actual = TestExpression.Const(5);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Var with equal arguments returns equal TestExpressions"), TestCategory("Constructor Methods")]
        public void Var_WithEqualArguments_ReturnsEqualTestExpressions()
        {
            var expr1 = TestExpression.Var<int>("n");
            var expr2 = TestExpression.Var<int>("n");

            Assert.AreEqual(expr1, expr2);
        }
        #endregion

        #region Operator Methods Tests
        [TestMethod("Add returns TestExpression where + operator is applied on arguments"), TestCategory("Operator Methods")]
        public void Add_ReturnsTestExpressionWherePlusOperatorIsAppliedOnArguments()
        {
            var expected = TestExpression.Expr(() => 5 + 7);

            var operand1 = TestExpression.Const(5);
            var operand2 = TestExpression.Const(7);
            var actual = TestExpression.Add(operand1, operand2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("AddAssign returns TestExpression where += operator is applied on arguments"), TestCategory("Operator Methods")]
        public void AddAssign_ReturnsTestExpressionWhereAddAssignOperatorIsAppliedOnArguments()
        {
            var assigment = Expression.AddAssign(
                Expression.Parameter(typeof(int), "n"),
                Expression.Constant(5));
            var expression = Expression.Lambda<Action>(assigment);
            var expected = TestExpression.Expr(expression);

            var operand1 = TestExpression.Var<int>("n");
            var operand2 = TestExpression.Const(5);
            var actual = TestExpression.AddAssign(operand1, operand2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("And returns TestExpression where && operator is applied on arguments"), TestCategory("Operator Methods")]
        public void And_ReturnsTestExpressionWhereAndOperatorIsAppliedOnArguments()
        {
            var expected = TestExpression.Expr(() => true && false);

            var operand1 = TestExpression.Const(true);
            var operand2 = TestExpression.Const(false);
            var actual = TestExpression.And(operand1, operand2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Assign returns TestExpression where = operator is applied on arguments"), TestCategory("Operator Methods")]
        public void Assign_ReturnsTestExpressionEqualToExpressionAssign()
        {
            var assigment = Expression.Assign(
                Expression.Parameter(typeof(int), "n"),
                Expression.Constant(5));
            var expression = Expression.Lambda<Action>(assigment); 
            var expected = TestExpression.Expr(expression);

            var operand1 = TestExpression.Var<int>("n");
            var operand2 = TestExpression.Const(5);
            var actual = TestExpression.Assign(operand1, operand2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Or returns TestExpression where || operator is applied on arguments"), TestCategory("Operator Methods")]
        public void Or_ReturnsTestExpressionWhereOrOperatorIsAppliedOnArguments()
        {
            var expected = TestExpression.Expr(() => true || false);

            var operand1 = TestExpression.Const(true);
            var operand2 = TestExpression.Const(false);
            var actual = TestExpression.Or(operand1, operand2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Not returns TestExpression where ! operator is applied on arguments"), TestCategory("Operator Methods")]
        public void Not_ReturnsTestExpressionWhereNotOperatorIsAppliedOnArguments()
        {
            var expected = TestExpression.Expr(() => !true);

            var operand = TestExpression.Const(true);
            var actual = TestExpression.Not(operand);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Subtract returns TestExpression where - operator is applied on arguments"), TestCategory("Operator Methods")]
        public void Subtract_ReturnsTestExpressionWhereSubtractOperatorIsAppliedOnArguments()
        {
            var expected = TestExpression.Expr(() => 5 - 7);

            var operand1 = TestExpression.Const(5);
            var operand2 = TestExpression.Const(7);
            var actual = TestExpression.Subtract(operand1, operand2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("SubtractAssign returns TestExpression where -= operator is applied on arguments"), TestCategory("Operator Methods")]
        public void SubtractAssign_ReturnsTestExpressionWhereSubtractAssignOperatorIsAppliedOnArguments()
        {
            var assigment = Expression.AddAssign(
                Expression.Parameter(typeof(int), "n"),
                Expression.Constant(5));
            var expression = Expression.Lambda<Action>(assigment);
            var expected = TestExpression.Expr(expression);

            var operand1 = TestExpression.Var<int>("n");
            var operand2 = TestExpression.Const(5);
            var actual = TestExpression.AddAssign(operand1, operand2);

            Assert.AreEqual(expected, actual);
        }
        #endregion
    }
}
