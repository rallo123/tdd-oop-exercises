using Lecture_3_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTools.Integrated;
using static Lecture_3_Tests.TestHelper;

namespace Lecture_3_Tests
{
    [TestClass]
    public class Exercise_4_Tests
    {
        /* Exercise 4A */
        [TestMethod("a. Employee.ToString() returns expected output"), TestCategory("Exercise 4A")]
        public void EmployeeToStringReturnsExpectedOutput()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Employee> employee = test.CreateObject<Employee>();

            employee.Arrange(() => new Employee("Joe Stevens") { Title = "Programmer" });
            employee.Assert.IsTrue(e => e.ToString() == "Employee Joe Stevens (Programmer)");

            test.Execute();
        }

        /* Exercise 4B */
        [TestMethod("a. Manager.ToString() returns expected output"), TestCategory("Exercise 4B")]
        public void ManagerToStringReturnsExpectedOutput()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Manager> manager = test.CreateObject<Manager>();

            manager.Arrange(() => new Manager("Mary Stevens") { Title = "Software Engineer" });
            manager.Assert.IsTrue(m => m.ToString() == "Manager Mary Stevens (Software Engineer)");

            test.Execute();
        }
    }
}
