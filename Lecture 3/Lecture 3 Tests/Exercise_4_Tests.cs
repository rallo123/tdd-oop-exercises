using Lecture_3_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTools.Unit;
using TestTools;
using TestTools.Structure;
using static Lecture_3_Tests.TestHelper;
using static TestTools.Unit.TestExpression;

namespace Lecture_3_Tests
{
    [TestClass]
    public class Exercise_4_Tests
    {
        #region Exercise 4A
        [TestMethod("a. Employee.ToString() returns expected output"), TestCategory("Exercise 4A")]
        public void EmployeeToStringReturnsExpectedOutput()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> employee = test.CreateVariable<Employee>(nameof(employee));

            test.Arrange(employee, Expr(() => new Employee("Joe Stevens") { Title = "Programmer" }));
            test.Assert.AreEqual(Expr(employee, e => e.ToString()), Const("Employee Joe Stevens (Programmer)"));

            test.Execute();
        }
        #endregion

        #region Exercise 4B
        [TestMethod("a. Manager.ToString() returns expected output"), TestCategory("Exercise 4B")]
        public void ManagerToStringReturnsExpectedOutput()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Manager> manager = test.CreateVariable<Manager>(nameof(manager));

            test.Arrange(manager, Expr(() => new Manager("Mary Stevens") { Title = "Software Engineer" }));
            test.Assert.AreEqual(Expr(manager, m => m.ToString()), Const("Manager Mary Stevens (Software Engineer)"));

            test.Execute();
        }
        #endregion
    }
}
