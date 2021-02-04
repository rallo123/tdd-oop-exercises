using Lecture_3_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Structure;
using TestTools.Operation;
using TestTools.Structure;
using static TestTools.Unit.TestExpression;
using static Lecture_3_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;
using TestTools.Unit;

namespace Lecture_3_Tests
{
    [TestClass]
    public class Exercise_2_Tests 
    {   
        private void TestAssignmentOfEmployeePropertyIgnoresValue<T>(Expression<Func<Employee, T>> property, T value, T defaultValue)
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> employee = test.CreateVariable<Employee>(nameof(employee));

            test.Arrange(employee, Expr(() => new Employee("abc")));
            test.Assign(Expr(employee, property), Const(value));
            test.Assert.AreEqual(Expr(employee, property), Const(defaultValue));

            test.Execute();
        }

        private void TestAssignmentOfManagerPropertyIgnoresValue<T>(Expression<Func<Manager, T>> property, T value, T defaultValue)
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Manager> manager = test.CreateVariable<Manager>(nameof(manager));

            test.Arrange(manager, Expr(() => new Manager("abc")));
            test.Assign(Expr(manager, property), Const(value));
            test.Assert.AreEqual(Expr(manager, property), Const(defaultValue));

            test.Execute();
        }

        private void TestEmployeeCalculateYearlySalary(decimal monthlySalary, int senority)
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> employee = test.CreateVariable<Employee>(nameof(employee));
            
            Employee originalEmployee = new Employee("abc") { MonthlySalary = monthlySalary, Seniority = senority };
            test.Arrange(employee, Expr(() => new Employee("abc") { MonthlySalary = monthlySalary, Seniority = senority }));
            test.Assert.AreEqual(Expr(employee, e => e.CalculateYearlySalary()), Const(originalEmployee.CalculateYearlySalary()));

            test.Execute();
        }

        public void TestManagerCalculateYearlySalary(decimal monthlySalary, decimal bonus, int senority)
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Manager> manager = test.CreateVariable<Manager>(nameof(manager));

            Manager originalManager = new Manager("abc") { MonthlySalary = monthlySalary, Bonus = bonus, Seniority = senority };
            test.Arrange(manager, Expr(() => new Manager("abc") { MonthlySalary = monthlySalary, Bonus = bonus, Seniority = senority }));
            test.Assert.AreEqual(Expr(manager, e => e.CalculateYearlySalary()), Const(originalManager.CalculateYearlySalary()));

            test.Execute();
        }

        #region Exercise 2A
        [TestMethod("a. Name is public string property"), TestCategory("Exercise 2A")]
        public void NameIsPublicStringProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Employee, string>(e => e.Name, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("b. Title is public string property"), TestCategory("Exercise 2A")]
        public void TitleIsPublicStringProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Employee, string>(e => e.Title, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("c. MonthlySalary is public decimal property"), TestCategory("Exercise 2A")]
        public void MonthlySalaryIsPublicDecimalProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Employee, decimal>(e => e.MonthlySalary, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("d. Seniority is public int property"), TestCategory("Exercise 2A")]
        public void SeniorityIsPublicIntProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Employee, int>(e => e.Seniority, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("e. Employee constructor takes string as argument"), TestCategory("Exercise 2A")]
        public void EmployeeConstructorTakesStringAsArgument()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertConstructor<string, Employee>(name => new Employee(name), IsPublicConstructor);
            test.Execute();
        }

        [TestMethod("e. Employee constructor(string name) sets name property"), TestCategory("Exercise 2A")]
        public void EmployeeConstructorNameSetsNameProperty()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> employee = test.CreateVariable<Employee>(nameof(employee));

            test.Arrange(employee, Expr(() => new Employee("abc")));
            test.Assert.AreEqual(Expr(employee, e => e.Name), Const("abc"));

            test.Execute();
        }

        [TestMethod("f. Employee.MonthlySalary is initialized as 0"), TestCategory("Exercise 2A")]
        public void MonthlySalaryIsInitializedAs0()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> employee = test.CreateVariable<Employee>(nameof(employee));

            test.Arrange(employee, Expr(() => new Employee("abc")));
            test.Assert.AreEqual(Expr(employee, e => e.MonthlySalary), Const(0M)); ;

            test.Execute();
        }

        [TestMethod("g. Employee.Senority is initialized as 1"), TestCategory("Exercise 2A")]
        public void SenorityIsInitializedAs1()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> employee = test.CreateVariable<Employee>(nameof(employee));

            test.Arrange(employee, Expr(() => new Employee("abc")));
            test.Assert.AreEqual(Expr(employee, e => e.Seniority), Const(1)); ;

            test.Execute();
        }

        [TestMethod("h. Title ignores assignment of null"), TestCategory("Exercise 2A")]
        public void TitleIgnoresAssignmentOfNull() => TestAssignmentOfEmployeePropertyIgnoresValue(e => e.Title, null, "abc");

        [TestMethod("i. Title ignores assignment of empty string"), TestCategory("Exercise 2A")]
        public void TitleIgnoresAssignmentOfEmptyString() => TestAssignmentOfEmployeePropertyIgnoresValue(e => e.Title, "", "abc");
        
        [TestMethod("j. MonthlySalary ignores assignment of -1M"), TestCategory("Exercise 2A")]
        public void MonthlySalaryIgnoresAssignmentOfMinusOne() => TestAssignmentOfEmployeePropertyIgnoresValue(e => e.MonthlySalary, -1M, 0M);

        [TestMethod("k. Seniority ignores assignment of 0"), TestCategory("Exercise 2A")]
        public void SeniorityIgnoresAssignmentOfZero() => TestAssignmentOfEmployeePropertyIgnoresValue(e => e.Seniority, 0, 1);

        [TestMethod("l. Seniority ignores assigment of 11"), TestCategory("Exercise 2A")]
        public void SeniorityIgnoresAssignmentOfEleven() => TestAssignmentOfEmployeePropertyIgnoresValue(e => e.Seniority, 11, 1);
        #endregion

        #region Exercise 2B
        [TestMethod("a. Employee.CalculateYearlySalary() returns expected output for seniority 1"), TestCategory("Exercise 2B")]
        public void EmployeeCalculateYearlySalaryAddsTenProcentForSeniorityLevelOne()  => TestEmployeeCalculateYearlySalary(34000, 1);

        [TestMethod("b. Employee.CalculateYearlySalary() returns expected output for seniority 2"), TestCategory("Exercise 2B")]
        public void EmployeeCalculateYearlySalaryAddsTenProcentForSeniorityLevelTwo() => TestEmployeeCalculateYearlySalary(15340, 2);

        [TestMethod("c. Employee.CalculateYearlySalary() returns expected output for seniority 3"), TestCategory("Exercise 2B")]
        public void EmployeeCalculateYearlySalaryAddsTenProcentForSeniorityLevelThree() => TestEmployeeCalculateYearlySalary(26500, 3);

        [TestMethod("d. Employee.CalculateYearlySalary() returns expected output for seniority 6"), TestCategory("Exercise 2B")]
        public void EmployeeCalculateYearlySalaryAddsTenProcentForSeniorityLevelSix() => TestEmployeeCalculateYearlySalary(20000, 6);

        [TestMethod("e. Employee.CalculateYearlySalary() returns expected output for seniority 7"), TestCategory("Exercise 2B")]
        public void EmployeeCalculateYearlySalaryAddsTenProcentForSeniorityLevelSeven() => TestEmployeeCalculateYearlySalary(12300, 7);

        [TestMethod("f. Employee.CalculateYearlySalary() returns expected output for seniority 10"), TestCategory("Exercise 2B")]
        public void EmployeeCalculateYearlySalaryAddsTenProcentForSeniorityLevelTen() => TestEmployeeCalculateYearlySalary(35250, 10);
        #endregion

        #region Exercise 2C
        [TestMethod("a. Manager is subclass of Employee"), TestCategory("Exercise 2C")]
        public void ManagerIsSubclassOfEmployee()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<Manager>(t => t.BaseType == typeof(Employee));
            test.Execute();
        }

        [TestMethod("b. Bonus is public decimal property"), TestCategory("Exercise 2C")]
        public void BonusIsPublicDecimalProperty() 
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Manager, decimal>(e => e.Bonus, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("c. Manager.Bonus is initialized as 0"), TestCategory("Exercise 2A")]
        public void BonusIsInitializedAs0()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Manager> manager = test.CreateVariable<Manager>(nameof(manager));

            test.Arrange(manager, Expr(() => new Manager("abc")));
            test.Assert.AreEqual(Expr(manager, e => e.Bonus), Const(0M));

            test.Execute();
        }

        [TestMethod("d. Bonus ignores assignment of -1M"), TestCategory("Exercise 2C")]
        public void BonusIgnoresAssignmentOfMinusOne() => TestAssignmentOfManagerPropertyIgnoresValue(m => m.Bonus, -1, 0);
        #endregion

        #region Exercise 2D
        [TestMethod("a. Manager.CalculateYearlySalary() returns expected output for seniority 1"), TestCategory("Exercise 2D")]
        public void ManagerCalculateYearlySalaryAddsTenProcentForSeniorityLevelOne() => TestManagerCalculateYearlySalary(34000, 0, 1);

        [TestMethod("b. Manager.CalculateYearlySalary() returns expected output for seniority 2"), TestCategory("Exercise 2D")]
        public void ManagerCalculateYearlySalaryAddsTenProcentForSeniorityLevelTwo() => TestManagerCalculateYearlySalary(15340, 500, 2);

        [TestMethod("c. Manager.CalculateYearlySalary() returns expected output for seniority 3"), TestCategory("Exercise 2D")]
        public void ManagerCalculateYearlySalaryAddsTenProcentForSeniorityLevelThree() => TestManagerCalculateYearlySalary(26500, 1000, 3);

        [TestMethod("d. Manager.CalculateYearlySalary() returns expected output for seniority 6"), TestCategory("Exercise 2D")]
        public void ManagerCalculateYearlySalaryAddsTenProcentForSeniorityLevelSix() => TestManagerCalculateYearlySalary(20000, 300, 6);

        [TestMethod("e. Manager.CalculateYearlySalary() returns expected output for seniority 7"), TestCategory("Exercise 2D")]
        public void ManagerCalculateYearlySalaryAddsTenProcentForSeniorityLevelSeven() => TestManagerCalculateYearlySalary(12300, 3000,  7);

        [TestMethod("f. Employee.CalculateYearlySalary() returns expected output for seniority 10"), TestCategory("Exercise 2D")]
        public void ManagerCalculateYearlySalaryAddsTenProcentForSeniorityLevelTen() => TestManagerCalculateYearlySalary(35250, 3400, 10);
        #endregion

        #region Exercise 2E
        [TestMethod("a. Company.Employees is a public read-only List<Employee> property"), TestCategory("Exercise 2E")]
        public void EmployeesIsPublicListEmployeeProperty() {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Company, List<Employee>>(c => c.Employees, IsPublicReadonlyProperty);
            test.Execute();
        }

        [TestMethod("b. Company.Hire(Employee e) adds employee to Employees"), TestCategory("Exercise 2E")]
        public void CompanyHireAddsEmployeeToEmployees()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> employee = test.CreateVariable<Employee>(nameof(employee));
            TestVariable<Company> company = test.CreateVariable<Company>(nameof(company));

            test.Arrange(employee, Expr(() => new Employee("Ellen Stevens")));
            test.Arrange(company, Expr(() => new Company()));
            test.Act(Expr(company, employee, (c, e) => c.Hire(e)));
            test.Assert.IsTrue(Expr(company, employee, (c, e) => c.Employees.Contains(e)));

            test.Execute();
        }

        [TestMethod("c. Company.Fire(Employee e) removes employee from Employees"), TestCategory("Exercise 2E")]
        public void CompanyFireAddsEmployeeToEmployees()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> employee = test.CreateVariable<Employee>(nameof(employee));
            TestVariable<Company> company = test.CreateVariable<Company>(nameof(company));

            test.Arrange(employee, Expr(() => new Employee("Ellen Stevens")));
            test.Arrange(company, Expr(() => new Company()));
            test.Act(Expr(company, employee, (c, e) => c.Hire(e)));
            test.Act(Expr(company, employee, (c, e) => c.Fire(e)));
            test.Assert.IsFalse(Expr(company, c => c.Employees.Any()));

            test.Execute();
        }

        [TestMethod("d. Company.Hire(Employee e) adds manager to Employees"), TestCategory("Exercise 2E")]
        public void CompanyHireAddsManagerToEmployees()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Manager> manager = test.CreateVariable<Manager>(nameof(manager));
            TestVariable<Company> company = test.CreateVariable<Company>(nameof(company));

            test.Arrange(manager, Expr(() => new Manager("Katja Holmes")));
            test.Arrange(company, Expr(() => new Company()));
            test.Act(Expr(company, manager, (c, m) => c.Hire(m)));
            test.Assert.IsTrue(Expr(company, manager, (c, m) => c.Employees.Contains(m)));

            test.Execute();
        }

        [TestMethod("e. Company.Fire(Employee e) removes manager to Employees"), TestCategory("Exercise 2E")]
        public void CompanyFireAddsManagerToEmployees()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Manager> manager = test.CreateVariable<Manager>(nameof(manager));
            TestVariable<Company> company = test.CreateVariable<Company>(nameof(company));

            test.Arrange(manager, Expr(() => new Manager("Katja Holmes")));
            test.Arrange(company, Expr(() => new Company()));
            test.Act(Expr(company, manager, (c, m) => c.Hire(m)));
            test.Act(Expr(company, manager, (c, m) => c.Fire(m)));
            test.Assert.IsFalse(Expr(company, c => c.Employees.Any()));

            test.Execute();
        }
        #endregion

        #region Exercise 2F
        /* Exercise 2F */
        [TestMethod("a. Company.CalculateYearlySalaryCosts() returns 0 for company without employees"), TestCategory("Exercise 2F")]
        public void CompanyCalculateYearlySalaryCostsReturnsZeroForCompanyWithoutEmployees()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Company> company = test.CreateVariable<Company>(nameof(company));

            test.Arrange(company, Expr(() => new Company()));
            test.Assert.AreEqual(Expr(company, c => c.CalculateYearlySalaryCosts()), Const(0M));

            test.Execute();
        }
        
        [TestMethod("b. Company.CalculateYearlySalaryCosts() returns expected output for company with 1 Employee"), TestCategory("Exercise 2F")]
        public void CompanyCalculateYearlySalaryCostsReturnsExpectedOutputForCompanyWithOneEmployee()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Company> company = test.CreateVariable<Company>(nameof(company));
            TestVariable<Employee> employee = test.CreateVariable<Employee>(nameof(employee));

            Company originalCompany = new Company();
            Employee originalEmployee = new Employee("Allan Walker") { MonthlySalary = 30000M, Seniority = 4 };
            test.Arrange(company, Expr(() => new Company()));
            test.Arrange(employee, Expr(() => new Employee("Allan Walker") { MonthlySalary = 30000M, Seniority = 4 }));
            originalCompany.Hire(originalEmployee);
            test.Act(Expr(company, employee, (c, e) => c.Hire(e)));
            test.Assert.AreEqual(Expr(company, c => c.CalculateYearlySalaryCosts()), Const(originalCompany.CalculateYearlySalaryCosts()));

            test.Execute();
        }

    [TestMethod("c. Company.CalculateYearlySalaryCosts() returns expected output for company with 2 Employees"), TestCategory("Exercise 2F")]
        public void CompanyCalculateYearlySalaryCostsReturnsExpectedOutputForCompanyWithTwoEmployee() 
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Company> company = test.CreateVariable<Company>(nameof(company));
            TestVariable<Employee> employee1 = test.CreateVariable<Employee>(nameof(employee1));
            TestVariable<Employee> employee2 = test.CreateVariable<Employee>(nameof(employee1));

            Company originalCompany = new Company();
            Employee originalEmployee1 = new Employee("Allan Walker") { MonthlySalary = 30000M, Seniority = 4 };
            Employee originalEmployee2 = new Employee("Amy Walker") { MonthlySalary = 30000M, Seniority = 7 };
            test.Arrange(company, Expr(() => new Company()));
            test.Arrange(employee1, Expr(() => new Employee("Allan Walker") { MonthlySalary = 30000M, Seniority = 4 }));
            test.Arrange(employee2, Expr(() => new Employee("Amy Walker") { MonthlySalary = 30000M, Seniority = 7 }));
            originalCompany.Hire(originalEmployee1);
            originalCompany.Hire(originalEmployee2);
            test.Act(Expr(company, employee1, (c, e) => c.Hire(e)));
            test.Act(Expr(company, employee2, (c, e) => c.Hire(e)));
            test.Assert.AreEqual(Expr(company, c => c.CalculateYearlySalaryCosts()), Const(originalCompany.CalculateYearlySalaryCosts()));

            test.Execute();
        }
        #endregion
    }
}
