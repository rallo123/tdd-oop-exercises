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
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Employee, string>(e => e.Name);
            test.Execute();
        }

        [TestMethod("b. Title is public string property"), TestCategory("Exercise 2A")]
        public void TitleIsPublicStringProperty()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Employee, string>(e => e.Title);
            test.Execute();
        }

        [TestMethod("c. MonthlySalary is public decimal property"), TestCategory("Exercise 2A")]
        public void MonthlySalaryIsPublicDecimalProperty()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Employee, decimal>(e => e.MonthlySalary);
            test.Execute();
        }

        [TestMethod("d. Seniority is public int property"), TestCategory("Exercise 2A")]
        public void SeniorityIsPublicIntProperty()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Employee, int>(e => e.Seniority);
            test.Execute();
        }

        [TestMethod("e. Employee constructor takes string as argument"), TestCategory("Exercise 2A")]
        public void EmployeeConstructorTakesStringAsArgument()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicConstructor<string, Employee>(name => new Employee(name));
            test.Execute();
        }

        [TestMethod("e. Employee constructor(string name) sets name property"), TestCategory("Exercise 2A")]
        public void EmployeeConstructorNameSetsNameProperty()
        {
            Employee employee = new Employee("abc");
            Assert.AreEqual(employee.Name, "abc");

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> _employee = test.CreateVariable<Employee>(nameof(_employee));
            test.Arrange(_employee, Expr(() => new Employee("abc")));
            test.Assert.AreEqual(Expr(_employee, e => e.Name), Const("abc"));
            test.Execute();
        }

        [TestMethod("f. Employee.MonthlySalary is initialized as 0"), TestCategory("Exercise 2A")]
        public void MonthlySalaryIsInitializedAs0()
        {
            Employee employee = new Employee("abc");
            Assert.AreEqual(employee.MonthlySalary, 0M);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> _employee = test.CreateVariable<Employee>(nameof(_employee));
            test.Arrange(_employee, Expr(() => new Employee("abc")));
            test.Assert.AreEqual(Expr(_employee, e => e.MonthlySalary), Const(0M)); ;
            test.Execute();
        }

        [TestMethod("g. Employee.Seniority is initialized as 1"), TestCategory("Exercise 2A")]
        public void SenorityIsInitializedAs1()
        {
            Employee employee = new Employee("abc");
            Assert.AreEqual(employee.Seniority, 1);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> _employee = test.CreateVariable<Employee>(nameof(_employee));
            test.Arrange(_employee, Expr(() => new Employee("abc")));
            test.Assert.AreEqual(Expr(_employee, e => e.Seniority), Const(1)); ;
            test.Execute();
        }

        [TestMethod("h. Title ignores assignment of null"), TestCategory("Exercise 2A")]
        public void TitleIgnoresAssignmentOfNull()
        {
            Employee employee = new Employee("abc");
            Assert.AreEqual(employee.Title, "Unknown");

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> _employee = test.CreateVariable<Employee>(nameof(_employee));
            test.Arrange(_employee, Expr(() => new Employee("abc")));
            test.Act(Expr(_employee, e => e.SetTitle(null)));
            test.Assert.AreEqual(Expr(_employee, e => e.Title), Const("Unknown")); ;
            test.Execute();
        }
       
        [TestMethod("i. Title ignores assignment of empty string"), TestCategory("Exercise 2A")]
        public void TitleIgnoresAssignmentOfEmptyString()
        {
            Employee employee = new Employee("abc");
            
            employee.Title = "";
            
            Assert.AreEqual(employee.Title, "Unknown");

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> _employee = test.CreateVariable<Employee>(nameof(_employee));
            test.Arrange(_employee, Expr(() => new Employee("abc")));
            test.Act(Expr(_employee, e => e.SetTitle("")));
            test.Assert.AreEqual(Expr(_employee, e => e.Title), Const("Unknown")); ;
            test.Execute();
        }
        
        [TestMethod("j. MonthlySalary ignores assignment of -1M"), TestCategory("Exercise 2A")]
        public void MonthlySalaryIgnoresAssignmentOfMinusOne()
        {
            Employee employee = new Employee("abc");

            employee.MonthlySalary = -1;

            Assert.AreEqual(employee.MonthlySalary, 0M);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> _employee = test.CreateVariable<Employee>(nameof(_employee));
            test.Arrange(_employee, Expr(() => new Employee("abc")));
            test.Act(Expr(_employee, e => e.SetMonthlySalary(-1M)));
            test.Assert.AreEqual(Expr(_employee, e => e.MonthlySalary), Const(0M)); ;
            test.Execute();
        }

        [TestMethod("k. Seniority ignores assignment of 0"), TestCategory("Exercise 2A")]
        public void SeniorityIgnoresAssignmentOfZero()
        {
            Employee employee = new Employee("abc");

            employee.Seniority = 0;

            Assert.AreEqual(employee.Seniority, 1);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> _employee = test.CreateVariable<Employee>(nameof(_employee));
            test.Arrange(_employee, Expr(() => new Employee("abc")));
            test.Act(Expr(_employee, e => e.SetSeniority(0)));
            test.Assert.AreEqual(Expr(_employee, e => e.Seniority), Const(1)); ;
            test.Execute();
        }

        [TestMethod("l. Seniority ignores assigment of 11"), TestCategory("Exercise 2A")]
        public void SeniorityIgnoresAssignmentOfEleven()
        {
            Employee employee = new Employee("abc");

            employee.Seniority = 11;

            Assert.AreEqual(employee.Seniority, 1);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> _employee = test.CreateVariable<Employee>(nameof(_employee));
            test.Arrange(_employee, Expr(() => new Employee("abc")));
            test.Act(Expr(_employee, e => e.SetSeniority(11)));
            test.Assert.AreEqual(Expr(_employee, e => e.Seniority), Const(1)); ;
            test.Execute();
        }
        #endregion

        #region Exercise 2B
        [TestMethod("a. Employee.CalculateYearlySalary() returns expected output for seniority 1"), TestCategory("Exercise 2B")]
        public void EmployeeCalculateYearlySalaryAddsTenProcentForSeniorityLevelOne()
        {
            Employee employee = new Employee("abc") 
            { 
                MonthlySalary = 34000M, 
                Seniority = 1 
            };
            Assert.AreEqual(employee.CalculateYearlySalary(), 0M);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> _employee = test.CreateVariable<Employee>(nameof(_employee));
            test.Arrange(_employee, Expr(() => new Employee("abc") { MonthlySalary = 34000M, Seniority = 1 }));
            test.Assert.AreEqual(Expr(_employee, e => e.CalculateYearlySalary()), Const(0M)); ;
            test.Execute();
        }

        [TestMethod("b. Employee.CalculateYearlySalary() returns expected output for seniority 2"), TestCategory("Exercise 2B")]
        public void EmployeeCalculateYearlySalaryAddsTenProcentForSeniorityLevelTwo()
        {
            Employee employee = new Employee("abc")
            {
                MonthlySalary = 15340,
                Seniority = 2
            };
            Assert.AreEqual(employee.CalculateYearlySalary(), 0M);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> _employee = test.CreateVariable<Employee>(nameof(_employee));
            test.Arrange(_employee, Expr(() => new Employee("abc") { MonthlySalary = 15340, Seniority = 2 }));
            test.Assert.AreEqual(Expr(_employee, e => e.CalculateYearlySalary()), Const(0M)); ;
            test.Execute();
        }

        [TestMethod("c. Employee.CalculateYearlySalary() returns expected output for seniority 3"), TestCategory("Exercise 2B")]
        public void EmployeeCalculateYearlySalaryAddsTenProcentForSeniorityLevelThree()
        {
            Employee employee = new Employee("abc")
            {
                MonthlySalary = 20000,
                Seniority = 3
            };
            Assert.AreEqual(employee.CalculateYearlySalary(), 0M);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> _employee = test.CreateVariable<Employee>(nameof(_employee));
            test.Arrange(_employee, Expr(() => new Employee("abc") { MonthlySalary = 20000, Seniority = 3 }));
            test.Assert.AreEqual(Expr(_employee, e => e.CalculateYearlySalary()), Const(0M)); ;
            test.Execute();
        }

        [TestMethod("d. Employee.CalculateYearlySalary() returns expected output for seniority 6"), TestCategory("Exercise 2B")]
        public void EmployeeCalculateYearlySalaryAddsTenProcentForSeniorityLevelSix()
        {
            Employee employee = new Employee("abc")
            {
                MonthlySalary = 20000,
                Seniority = 6
            };
            Assert.AreEqual(employee.CalculateYearlySalary(), 0M);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> _employee = test.CreateVariable<Employee>(nameof(_employee));
            test.Arrange(_employee, Expr(() => new Employee("abc") { MonthlySalary = 20000, Seniority = 6 }));
            test.Assert.AreEqual(Expr(_employee, e => e.CalculateYearlySalary()), Const(0M)); ;
            test.Execute();
        }

        [TestMethod("e. Employee.CalculateYearlySalary() returns expected output for seniority 7"), TestCategory("Exercise 2B")]
        public void EmployeeCalculateYearlySalaryAddsTenProcentForSeniorityLevelSeven()
        {
            Employee employee = new Employee("abc")
            {
                MonthlySalary = 12300,
                Seniority = 7
            };
            Assert.AreEqual(employee.CalculateYearlySalary(), 0M);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> _employee = test.CreateVariable<Employee>(nameof(_employee));
            test.Arrange(_employee, Expr(() => new Employee("abc") { MonthlySalary = 12300, Seniority = 7 }));
            test.Assert.AreEqual(Expr(_employee, e => e.CalculateYearlySalary()), Const(0M));
            test.Execute();
        }

        [TestMethod("f. Employee.CalculateYearlySalary() returns expected output for seniority 10"), TestCategory("Exercise 2B")]
        public void EmployeeCalculateYearlySalaryAddsTenProcentForSeniorityLevelTen()
        {
            Employee employee = new Employee("abc")
            {
                MonthlySalary = 35250,
                Seniority = 10
            };
            Assert.AreEqual(employee.CalculateYearlySalary(), 0M);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> _employee = test.CreateVariable<Employee>(nameof(_employee));
            test.Arrange(_employee, Expr(() => new Employee("abc") { MonthlySalary = 35250, Seniority = 10 }));
            test.Assert.AreEqual(Expr(_employee, e => e.CalculateYearlySalary()), Const(0M));
            test.Execute();
        }
        #endregion

        #region Exercise 2C
        [TestMethod("a. Manager is subclass of Employee"), TestCategory("Exercise 2C")]
        public void ManagerIsSubclassOfEmployee()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<Manager>(new TypeBaseClassVerifier(typeof(Employee)));
            test.Execute();
        }

        [TestMethod("b. Bonus is public decimal property"), TestCategory("Exercise 2C")]
        public void BonusIsPublicDecimalProperty() 
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Manager, decimal>(e => e.Bonus);
            test.Execute();
        }

        [TestMethod("c. Manager.Bonus is initialized as 0"), TestCategory("Exercise 2A")]
        public void BonusIsInitializedAs0()
        {
            Manager manager = new Manager("abc");
            Assert.AreEqual(manager.Bonus, 0M);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Manager> _manager = test.CreateVariable<Manager>(nameof(_manager));
            test.Arrange(_manager, Expr(() => new Manager("abc")));
            test.Assert.AreEqual(Expr(_manager, e => e.Bonus), Const(0M));
            test.Execute();
        }

        [TestMethod("d. Bonus ignores assignment of -1M"), TestCategory("Exercise 2C")]
        public void BonusIgnoresAssignmentOfMinusOne()
        {
            Manager manager = new Manager("abc");

            manager.Bonus = -1;

            Assert.AreEqual(manager.Bonus, 0M);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Manager> _manager = test.CreateVariable<Manager>(nameof(_manager));
            test.Arrange(_manager, Expr(() => new Manager("abc")));
            test.Act(Expr(_manager, e => e.SetBonus(-1M)));
            test.Assert.AreEqual(Expr(_manager, e => e.Bonus), Const(0M)); ;
            test.Execute();
        }
        #endregion

        #region Exercise 2D
        [TestMethod("a. Manager.CalculateYearlySalary() returns expected output for seniority 1"), TestCategory("Exercise 2D")]
        public void ManagerCalculateYearlySalaryAddsTenProcentForSeniorityLevelOne()
        {
            Manager manager = new Manager("abc")
            {
                MonthlySalary = 35250,
                Bonus = 0,
                Seniority = 1
            };
            Assert.AreEqual(manager.CalculateYearlySalary(), 0);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Manager> _manager = test.CreateVariable<Manager>(nameof(_manager));
            test.Arrange(_manager, Expr(() => new Manager("abc") { MonthlySalary = 35250, Bonus = 0, Seniority = 1 }));
            test.Assert.AreEqual(Expr(_manager, e => e.CalculateYearlySalary()), Const(0M)); ;
            test.Execute();
        }

        [TestMethod("b. Manager.CalculateYearlySalary() returns expected output for seniority 2"), TestCategory("Exercise 2D")]
        public void ManagerCalculateYearlySalaryAddsTenProcentForSeniorityLevelTwo()
        {
            Manager manager = new Manager("abc")
            {
                MonthlySalary = 15340,
                Bonus = 500,
                Seniority = 2
            };
            Assert.AreEqual(manager.CalculateYearlySalary(), 0);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Manager> _manager = test.CreateVariable<Manager>(nameof(_manager));
            test.Arrange(_manager, Expr(() => new Manager("abc") { MonthlySalary = 15340, Bonus = 500, Seniority = 2 }));
            test.Assert.AreEqual(Expr(_manager, e => e.CalculateYearlySalary()), Const(0M)); ;
            test.Execute();
        }

        [TestMethod("c. Manager.CalculateYearlySalary() returns expected output for seniority 3"), TestCategory("Exercise 2D")]
        public void ManagerCalculateYearlySalaryAddsTenProcentForSeniorityLevelThree()
        {
            Manager manager = new Manager("abc")
            {
                MonthlySalary = 26500,
                Bonus = 1000,
                Seniority = 3
            };
            Assert.AreEqual(manager.CalculateYearlySalary(), 0);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Manager> _manager = test.CreateVariable<Manager>(nameof(_manager));
            test.Arrange(_manager, Expr(() => new Manager("abc") { MonthlySalary = 26500, Bonus = 1000, Seniority = 3 }));
            test.Assert.AreEqual(Expr(_manager, e => e.CalculateYearlySalary()), Const(0M)); ;
            test.Execute();
        }

        [TestMethod("d. Manager.CalculateYearlySalary() returns expected output for seniority 6"), TestCategory("Exercise 2D")]
        public void ManagerCalculateYearlySalaryAddsTenProcentForSeniorityLevelSix()
        {
            Manager manager = new Manager("abc")
            {
                MonthlySalary = 20000,
                Bonus = 300,
                Seniority = 6
            };
            Assert.AreEqual(manager.CalculateYearlySalary(), 0);


            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Manager> _manager = test.CreateVariable<Manager>(nameof(_manager));
            test.Arrange(_manager, Expr(() => new Manager("abc") { MonthlySalary = 20000, Bonus = 300, Seniority = 6 }));
            test.Assert.AreEqual(Expr(_manager, e => e.CalculateYearlySalary()), Const(0M)); ;
            test.Execute();
        }

        [TestMethod("e. Manager.CalculateYearlySalary() returns expected output for seniority 7"), TestCategory("Exercise 2D")]
        public void ManagerCalculateYearlySalaryAddsTenProcentForSeniorityLevelSeven()
        {
            Manager manager = new Manager("abc")
            {
                MonthlySalary = 12300,
                Bonus = 3000,
                Seniority = 7
            };
            Assert.AreEqual(manager.CalculateYearlySalary(), 0);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Manager> _manager = test.CreateVariable<Manager>(nameof(_manager));
            test.Arrange(_manager, Expr(() => new Manager("abc") { MonthlySalary = 12300, Bonus = 3000, Seniority = 7 }));
            test.Assert.AreEqual(Expr(_manager, e => e.CalculateYearlySalary()), Const(0M)); ;
            test.Execute();
        }

        [TestMethod("f. Employee.CalculateYearlySalary() returns expected output for seniority 10"), TestCategory("Exercise 2D")]
        public void ManagerCalculateYearlySalaryAddsTenProcentForSeniorityLevelTen()
        {
            Manager manager = new Manager("abc")
            {
                MonthlySalary = 35250,
                Bonus = 34000,
                Seniority = 10
            };
            Assert.AreEqual(manager.CalculateYearlySalary(), 0);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Manager> _manager = test.CreateVariable<Manager>(nameof(_manager));
            test.Arrange(_manager, Expr(() => new Manager("abc") { MonthlySalary = 35250, Bonus = 34000, Seniority = 10 }));
            test.Assert.AreEqual(Expr(_manager, e => e.CalculateYearlySalary()), Const(0M)); ;
            test.Execute();
        }
        #endregion

        #region Exercise 2E
        [TestMethod("a. Company.Employees is a public read-only List<Employee> property"), TestCategory("Exercise 2E")]
        public void EmployeesIsPublicListEmployeeProperty() {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicReadonlyProperty<Company, List<Employee>>(c => c.Employees);
            test.Execute();
        }

        [TestMethod("b. Company.Hire(Employee e) adds employee to Employees"), TestCategory("Exercise 2E")]
        public void CompanyHireAddsEmployeeToEmployees()
        {
            Company company = new Company();
            Employee employee = new Employee("Ellen Stevens");

            company.Hire(employee);

            Assert.AreEqual(company.Employees.Count, 1);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> _employee = test.CreateVariable<Employee>(nameof(_employee));
            TestVariable<Company> _company = test.CreateVariable<Company>(nameof(_company));
            test.Arrange(_employee, Expr(() => new Employee("Ellen Stevens")));
            test.Arrange(_company, Expr(() => new Company()));
            test.Act(Expr(_company, _employee, (c, e) => c.Hire(e)));
            test.Assert.AreEqual(Expr(_company, c => c.Employees.Count), Const(1));
            test.Execute();
        }

        [TestMethod("c. Company.Fire(Employee e) removes employee from Employees"), TestCategory("Exercise 2E")]
        public void CompanyFireAddsEmployeeToEmployees()
        {
            Company company = new Company();
            Employee employee = new Employee("Ellen Stevens");

            company.Hire(employee);
            company.Fire(employee);

            Assert.AreEqual(company.Employees.Count, 0);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Employee> _employee = test.CreateVariable<Employee>(nameof(_employee));
            TestVariable<Company> _company = test.CreateVariable<Company>(nameof(_company));
            test.Arrange(_employee, Expr(() => new Employee("Ellen Stevens")));
            test.Arrange(_company, Expr(() => new Company()));
            test.Act(Expr(_company, _employee, (c, e) => c.Hire(e)));
            test.Act(Expr(_company, _employee, (c, e) => c.Fire(e)));
            test.Assert.AreEqual(Expr(_company, c => c.Employees.Count), Const(0));
            test.Execute();
        }

        [TestMethod("d. Company.Hire(Employee e) adds manager to Employees"), TestCategory("Exercise 2E")]
        public void CompanyHireAddsManagerToEmployees()
        {
            Company company = new Company();
            Employee employee = new Employee("Katja Holmes");

            company.Hire(employee);

            Assert.AreEqual(company.Employees.Count, 1);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Manager> _manager = test.CreateVariable<Manager>(nameof(_manager));
            TestVariable<Company> _company = test.CreateVariable<Company>(nameof(_company));
            test.Arrange(_manager, Expr(() => new Manager("Katja Holmes")));
            test.Arrange(_company, Expr(() => new Company()));
            test.Act(Expr(_company, _manager, (c, m) => c.Hire(m)));
            test.Assert.AreEqual(Expr(_company, c => c.Employees.Count), Const(1));
            test.Execute();
        }

        [TestMethod("e. Company.Fire(Employee e) removes manager to Employees"), TestCategory("Exercise 2E")]
        public void CompanyFireAddsManagerToEmployees()
        {
            Company company = new Company();
            Manager manager = new Manager("Katja Holmes");

            company.Hire(manager);
            company.Fire(manager);

            Assert.AreEqual(company.Employees.Count, 0);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Manager> _manager = test.CreateVariable<Manager>(nameof(_manager));
            TestVariable<Company> _company = test.CreateVariable<Company>(nameof(_company));
            test.Arrange(_manager, Expr(() => new Manager("Katja Holmes")));
            test.Arrange(_company, Expr(() => new Company()));
            test.Act(Expr(_company, _manager, (c, m) => c.Hire(m)));
            test.Act(Expr(_company, _manager, (c, m) => c.Fire(m)));
            test.Assert.AreEqual(Expr(_company, c => c.Employees.Count), Const(0));
            test.Execute();
        }
        #endregion

        #region Exercise 2F
        [TestMethod("a. Company.CalculateYearlySalaryCosts() returns 0 for company without employees"), TestCategory("Exercise 2F")]
        public void CompanyCalculateYearlySalaryCostsReturnsZeroForCompanyWithoutEmployees()
        {
            Company company = new Company();
            Assert.AreEqual(company.CalculateYearlySalaryCosts(), 0M);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Company> _company = test.CreateVariable<Company>(nameof(_company));
            test.Arrange(_company, Expr(() => new Company()));
            test.Assert.AreEqual(Expr(_company, c => c.CalculateYearlySalaryCosts()), Const(0M));
            test.Execute();
        }
        
        [TestMethod("b. Company.CalculateYearlySalaryCosts() returns expected output for company with 1 Employee"), TestCategory("Exercise 2F")]
        public void CompanyCalculateYearlySalaryCostsReturnsExpectedOutputForCompanyWithOneEmployee()
        {
            Company company = new Company();
            Employee employee = new Employee("Allan Walker") 
            { 
                MonthlySalary = 30000M, 
                Seniority = 4 
            };

            company.Hire(employee);

            Assert.AreEqual(company.CalculateYearlySalaryCosts(), 0M);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Company> _company = test.CreateVariable<Company>(nameof(_company));
            TestVariable<Employee> _employee = test.CreateVariable<Employee>(nameof(_employee));
            test.Arrange(_company, Expr(() => new Company()));
            test.Arrange(_employee, Expr(() => new Employee("Allan Walker") { MonthlySalary = 30000M, Seniority = 4 }));
            test.Act(Expr(_company, _employee, (c, e) => c.Hire(e)));
            test.Assert.AreEqual(Expr(_company, c => c.CalculateYearlySalaryCosts()), Const(0M)); ;
            test.Execute();
        }

    [TestMethod("c. Company.CalculateYearlySalaryCosts() returns expected output for company with 2 Employees"), TestCategory("Exercise 2F")]
        public void CompanyCalculateYearlySalaryCostsReturnsExpectedOutputForCompanyWithTwoEmployee() 
        {
            Company company = new Company();
            Employee employee1 = new Employee("Allan Walker")
            {
                MonthlySalary = 30000M,
                Seniority = 4
            };
            Employee employee2 = new Employee("Amy Walker")
            {
                MonthlySalary = 30000M,
                Seniority = 7
            };

            company.Hire(employee1);
            company.Hire(employee2);

            Assert.AreEqual(company.CalculateYearlySalaryCosts(), 0M);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Company> _company = test.CreateVariable<Company>(nameof(_company));
            TestVariable<Employee> _employee1 = test.CreateVariable<Employee>(nameof(_employee1));
            TestVariable<Employee> _employee2 = test.CreateVariable<Employee>(nameof(_employee1));
            test.Arrange(_company, Expr(() => new Company()));
            test.Arrange(_employee1, Expr(() => new Employee("Allan Walker") { MonthlySalary = 30000M, Seniority = 4 }));
            test.Arrange(_employee2, Expr(() => new Employee("Amy Walker") { MonthlySalary = 30000M, Seniority = 7 }));
            test.Act(Expr(_company, _employee1, (c, e) => c.Hire(e)));
            test.Act(Expr(_company, _employee2, (c, e) => c.Hire(e)));
            test.Assert.AreEqual(Expr(_company, c => c.CalculateYearlySalaryCosts()), Const(0M));
            test.Execute();
        }
        #endregion
    }
}
