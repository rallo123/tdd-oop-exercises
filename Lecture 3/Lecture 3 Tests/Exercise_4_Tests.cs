using Lecture_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTools.Structure;
using TestTools.Structure.Generic;

namespace Lecture_3_Tests
{
    [TestClass]
    public class Exercise_4_Tests
    {
#pragma warning disable IDE1006 // Naming Stylesw

        private ClassElement<Employee> employee => new ClassElement<Employee>();
        private PropertyElement<Employee, string> employeeTitle => employee.Property<string>("Title", get: new AccessorOptions() { IsPublic = true }, set: new AccessorOptions() { IsPublic = true });
        private FuncMethodElement<Employee, string> employeeToString => employee.FuncMethod<string>("ToString", new MethodOptions() { IsPublic = true });
        private Employee CreateEmployee(string name, string title)
        {
            Employee instance = employee.Constructor<string>().Invoke(name);
            employeeTitle.Set(instance, title);
            return instance;
        }

        private ClassElement<Manager> manager => new ClassElement<Manager>(new ClassOptions() { BaseType = typeof(Employee) });
        private PropertyElement<Manager, string> managerTitle => manager.Property<string>("Title", get: new AccessorOptions() { IsPublic = true }, set: new AccessorOptions() { IsPublic = true });
        private FuncMethodElement<Manager, string> managerToString => manager.FuncMethod<string>("ToString", new MethodOptions() { IsPublic = true });

        private Manager CreateManager(string name, string title)
        {
            Manager instance = manager.Constructor<string>().Invoke(name);
            managerTitle.Set(instance, title);
            return instance;
        }
#pragma warning restore IDE1006 // Naming Styles


        /* Exercise 4A */
        [TestMethod("a. Employee.ToString() returns expected output"), TestCategory("Exercise 4A")]
        public void EmployeeToStringReturnsExpectedOutput()
        {
            string actual = employeeToString.Invoke(CreateEmployee("Joe Stevens", "Programmer"));
            string expected = "Employee Joe Stevens (Programmer)";

            if (actual == expected)
            {
                string message = string.Format(
                    "Employee.ToString() returns \"{0}\" instead of \"{1}\"",
                    actual,
                    expected
                );
                throw new AssertFailedException(message);
            }
        }

        /* Exercise 4B */
        [TestMethod("a. Manager.ToString() returns expected output"), TestCategory("Exercise 4B")]
        public void ManagerToStringReturnsExpectedOutput()
        {
            string actual = managerToString.Invoke(CreateManager("Mary Stevens", "Software Engineer"));
            string expected = "Manager Mary Stevens (Software Engineer)";

            if (actual == expected)
            {
                string message = string.Format(
                    "Manager.ToString() returns \"{0}\" instead of \"{1}\"",
                    actual,
                    expected
                );
                throw new AssertFailedException(message);
            }
        }
    }
}
