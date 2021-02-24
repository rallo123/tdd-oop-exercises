using Lecture_3_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        #region Exercise 2A
        [TestMethod("a. Name is public string property"), TestCategory("Exercise 2A")]
        public void NameIsPublicStringProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Employee, string>(e => e.Name);
            test.Execute();
        }

        [TestMethod("b. Title is public string property"), TestCategory("Exercise 2A")]
        public void TitleIsPublicStringProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Employee, string>(e => e.Title);
            test.Execute();
        }

        [TestMethod("c. MonthlySalary is public decimal property"), TestCategory("Exercise 2A")]
        public void MonthlySalaryIsPublicDecimalProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Employee, decimal>(e => e.MonthlySalary);
            test.Execute();
        }

        [TestMethod("d. Seniority is public int property"), TestCategory("Exercise 2A")]
        public void SeniorityIsPublicIntProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Employee, int>(e => e.Seniority);
            test.Execute();
        }

        [TestMethod("e. Employee constructor takes string as argument"), TestCategory("Exercise 2A")]
        public void EmployeeConstructorTakesStringAsArgument()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicConstructor<string, Employee>(name => new Employee(name));
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
        public void TitleIgnoresAssignmentOfNull()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> employee = test.CreateVariable<Employee>(nameof(employee));

            test.Arrange(employee, Expr(() => new Employee("abc")));
            test.Act(Expr(employee, e => e.SetTitle(null)));
            test.Assert.AreEqual(Expr(employee, e => e.Title), Const("Unknown")); ;

            test.Execute();
        }
       
        [TestMethod("i. Title ignores assignment of empty string"), TestCategory("Exercise 2A")]
        public void TitleIgnoresAssignmentOfEmptyString()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> employee = test.CreateVariable<Employee>(nameof(employee));

            test.Arrange(employee, Expr(() => new Employee("abc")));
            test.Act(Expr(employee, e => e.SetTitle("")));
            test.Assert.AreEqual(Expr(employee, e => e.Title), Const("Unknown")); ;

            test.Execute();
        }
        
        [TestMethod("j. MonthlySalary ignores assignment of -1M"), TestCategory("Exercise 2A")]
        public void MonthlySalaryIgnoresAssignmentOfMinusOne()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> employee = test.CreateVariable<Employee>(nameof(employee));

            test.Arrange(employee, Expr(() => new Employee("abc")));
            test.Act(Expr(employee, e => e.SetMonthlySalary(-1M)));
            test.Assert.AreEqual(Expr(employee, e => e.MonthlySalary), Const(0M)); ;

            test.Execute();
        }

        [TestMethod("k. Seniority ignores assignment of 0"), TestCategory("Exercise 2A")]
        public void SeniorityIgnoresAssignmentOfZero()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> employee = test.CreateVariable<Employee>(nameof(employee));

            test.Arrange(employee, Expr(() => new Employee("abc")));
            test.Act(Expr(employee, e => e.SetSeniority(0)));
            test.Assert.AreEqual(Expr(employee, e => e.Seniority), Const(1)); ;

            test.Execute();
        }

        [TestMethod("l. Seniority ignores assigment of 11"), TestCategory("Exercise 2A")]
        public void SeniorityIgnoresAssignmentOfEleven()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> employee = test.CreateVariable<Employee>(nameof(employee));

            test.Arrange(employee, Expr(() => new Employee("abc")));
            test.Act(Expr(employee, e => e.SetSeniority(11)));
            test.Assert.AreEqual(Expr(employee, e => e.Seniority), Const(1)); ;

            test.Execute();
        }
        #endregion

        #region Exercise 2B
        [TestMethod("a. Employee.CalculateYearlySalary() returns expected output for seniority 1"), TestCategory("Exercise 2B")]
        public void EmployeeCalculateYearlySalaryAddsTenProcentForSeniorityLevelOne()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> employee = test.CreateVariable<Employee>(nameof(employee));

            test.Arrange(employee, Expr(() => new Employee("abc") { MonthlySalary = 34000M, Seniority = 1 }));
            test.Assert.AreEqual(Expr(employee, e => e.CalculateYearlySalary()), Const(0M)); ;

            test.Execute();
        }

        [TestMethod("b. Employee.CalculateYearlySalary() returns expected output for seniority 2"), TestCategory("Exercise 2B")]
        public void EmployeeCalculateYearlySalaryAddsTenProcentForSeniorityLevelTwo()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> employee = test.CreateVariable<Employee>(nameof(employee));

            test.Arrange(employee, Expr(() => new Employee("abc") { MonthlySalary = 15340, Seniority = 2 }));
            test.Assert.AreEqual(Expr(employee, e => e.CalculateYearlySalary()), Const(0M)); ;

            test.Execute();
        }

        [TestMethod("c. Employee.CalculateYearlySalary() returns expected output for seniority 3"), TestCategory("Exercise 2B")]
        public void EmployeeCalculateYearlySalaryAddsTenProcentForSeniorityLevelThree()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> employee = test.CreateVariable<Employee>(nameof(employee));

            test.Arrange(employee, Expr(() => new Employee("abc") { MonthlySalary = 20000, Seniority = 3 }));
            test.Assert.AreEqual(Expr(employee, e => e.CalculateYearlySalary()), Const(0M)); ;

            test.Execute();
        }

        [TestMethod("d. Employee.CalculateYearlySalary() returns expected output for seniority 6"), TestCategory("Exercise 2B")]
        public void EmployeeCalculateYearlySalaryAddsTenProcentForSeniorityLevelSix()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> employee = test.CreateVariable<Employee>(nameof(employee));

            test.Arrange(employee, Expr(() => new Employee("abc") { MonthlySalary = 20000, Seniority = 6 }));
            test.Assert.AreEqual(Expr(employee, e => e.CalculateYearlySalary()), Const(0M)); ;

            test.Execute();
        }

        [TestMethod("e. Employee.CalculateYearlySalary() returns expected output for seniority 7"), TestCategory("Exercise 2B")]
        public void EmployeeCalculateYearlySalaryAddsTenProcentForSeniorityLevelSeven()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> employee = test.CreateVariable<Employee>(nameof(employee));

            test.Arrange(employee, Expr(() => new Employee("abc") { MonthlySalary = 12300, Seniority = 7 }));
            test.Assert.AreEqual(Expr(employee, e => e.CalculateYearlySalary()), Const(0M)); ;

            test.Execute();
        }

        [TestMethod("f. Employee.CalculateYearlySalary() returns expected output for seniority 10"), TestCategory("Exercise 2B")]
        public void EmployeeCalculateYearlySalaryAddsTenProcentForSeniorityLevelTen()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> employee = test.CreateVariable<Employee>(nameof(employee));

            test.Arrange(employee, Expr(() => new Employee("abc") { MonthlySalary = 35250, Seniority = 10 }));
            test.Assert.AreEqual(Expr(employee, e => e.CalculateYearlySalary()), Const(0M)); ;

            test.Execute();
        }
        #endregion

        #region Exercise 2C
        [TestMethod("a. Manager is subclass of Employee"), TestCategory("Exercise 2C")]
        public void ManagerIsSubclassOfEmployee()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<Manager>(new TypeBaseClassVerifier(typeof(Employee)));
            test.Execute();
        }

        [TestMethod("b. Bonus is public decimal property"), TestCategory("Exercise 2C")]
        public void BonusIsPublicDecimalProperty() 
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Manager, decimal>(e => e.Bonus);
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
        public void BonusIgnoresAssignmentOfMinusOne()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Manager> manager = test.CreateVariable<Manager>(nameof(manager));

            test.Arrange(manager, Expr(() => new Manager("abc")));
            test.Act(Expr(manager, e => e.SetBonus(-1M)));
            test.Assert.AreEqual(Expr(manager, e => e.Bonus), Const(0M)); ;

            test.Execute();
        }
        #endregion

        #region Exercise 2D
        [TestMethod("a. Manager.CalculateYearlySalary() returns expected output for seniority 1"), TestCategory("Exercise 2D")]
        public void ManagerCalculateYearlySalaryAddsTenProcentForSeniorityLevelOne()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Manager> manager = test.CreateVariable<Manager>(nameof(manager));

            test.Arrange(manager, Expr(() => new Manager("abc") { MonthlySalary = 35250, Bonus = 0, Seniority = 1 }));
            test.Assert.AreEqual(Expr(manager, e => e.CalculateYearlySalary()), Const(0M)); ;

            test.Execute();
        }

        [TestMethod("b. Manager.CalculateYearlySalary() returns expected output for seniority 2"), TestCategory("Exercise 2D")]
        public void ManagerCalculateYearlySalaryAddsTenProcentForSeniorityLevelTwo()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Manager> manager = test.CreateVariable<Manager>(nameof(manager));

            test.Arrange(manager, Expr(() => new Manager("abc") { MonthlySalary = 15340, Bonus = 500, Seniority = 2 }));
            test.Assert.AreEqual(Expr(manager, e => e.CalculateYearlySalary()), Const(0M)); ;

            test.Execute();
        }

        [TestMethod("c. Manager.CalculateYearlySalary() returns expected output for seniority 3"), TestCategory("Exercise 2D")]
        public void ManagerCalculateYearlySalaryAddsTenProcentForSeniorityLevelThree()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Manager> manager = test.CreateVariable<Manager>(nameof(manager));

            test.Arrange(manager, Expr(() => new Manager("abc") { MonthlySalary = 26500, Bonus = 1000, Seniority = 3 }));
            test.Assert.AreEqual(Expr(manager, e => e.CalculateYearlySalary()), Const(0M)); ;

            test.Execute();
        }

        [TestMethod("d. Manager.CalculateYearlySalary() returns expected output for seniority 6"), TestCategory("Exercise 2D")]
        public void ManagerCalculateYearlySalaryAddsTenProcentForSeniorityLevelSix()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Manager> manager = test.CreateVariable<Manager>(nameof(manager));

            test.Arrange(manager, Expr(() => new Manager("abc") { MonthlySalary = 20000, Bonus = 300, Seniority = 6 }));
            test.Assert.AreEqual(Expr(manager, e => e.CalculateYearlySalary()), Const(0M)); ;

            test.Execute();
        }

        [TestMethod("e. Manager.CalculateYearlySalary() returns expected output for seniority 7"), TestCategory("Exercise 2D")]
        public void ManagerCalculateYearlySalaryAddsTenProcentForSeniorityLevelSeven()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Manager> manager = test.CreateVariable<Manager>(nameof(manager));

            test.Arrange(manager, Expr(() => new Manager("abc") { MonthlySalary = 12300, Bonus = 3000, Seniority = 7 }));
            test.Assert.AreEqual(Expr(manager, e => e.CalculateYearlySalary()), Const(0M)); ;

            test.Execute();
        }

        [TestMethod("f. Employee.CalculateYearlySalary() returns expected output for seniority 10"), TestCategory("Exercise 2D")]
        public void ManagerCalculateYearlySalaryAddsTenProcentForSeniorityLevelTen()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Manager> manager = test.CreateVariable<Manager>(nameof(manager));

            test.Arrange(manager, Expr(() => new Manager("abc") { MonthlySalary = 35250, Bonus = 34000, Seniority = 10 }));
            test.Assert.AreEqual(Expr(manager, e => e.CalculateYearlySalary()), Const(0M)); ;

            test.Execute();
        }
        #endregion

        #region Exercise 2E
        [TestMethod("a. Company.Employees is a public read-only List<Employee> property"), TestCategory("Exercise 2E")]
        public void EmployeesIsPublicListEmployeeProperty() {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicReadonlyProperty<Company, List<Employee>>(c => c.Employees);
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

            test.Arrange(company, Expr(() => new Company()));
            test.Arrange(employee1, Expr(() => new Employee("Allan Walker") { MonthlySalary = 30000M, Seniority = 4 }));
            test.Arrange(employee2, Expr(() => new Employee("Amy Walker") { MonthlySalary = 30000M, Seniority = 7 }));
            test.Act(Expr(company, employee1, (c, e) => c.Hire(e)));
            test.Act(Expr(company, employee2, (c, e) => c.Hire(e)));
            test.Assert.AreEqual(Expr(company, c => c.CalculateYearlySalaryCosts()), Const(0M));

            test.Execute();
        }
        #endregion
    }
}
