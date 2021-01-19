﻿using Lecture_3_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Integrated;
using TestTools.Operation;
using TestTools.Structure;
using TestTools.Structure.Generic;
using static TestTools.Helpers.ExpressionHelper;

namespace Lecture_3_Tests
{
    [TestClass]
    public class Exercise_2_Tests 
    {
        TestFactory factory = new TestFactory("Lecture_3");
        
        public void TestAssignmentOfEmployeePropertyIgnoresValue<T>(Expression<Func<Employee, T>> property, T value)
        {
            UnitTest test = factory.CreateTest();
            UnitTestObject<Employee> employee = test.Create<Employee>();

            employee.Arrange(() => new Employee("abc"));
            employee.Act(Assignment(property, value));
            employee.Assert.Unchanged(property);

            test.Execute();
        }

        public void TestAssignmentOfManagerPropertyIgnoresValue<T>(Expression<Func<Manager, T>> property, T value)
        {
            UnitTest test = factory.CreateTest();
            UnitTestObject<Manager> manager = test.Create<Manager>();

            manager.Arrange(() => new Manager("abc"));
            manager.Act(Assignment(property, value));
            manager.Assert.Unchanged(property);

            test.Execute();
        }

        public void TestEmployeeCalculateYearlySalary(decimal monthlySalary, int senority)
        {
            UnitTest test = factory.CreateTest();
            DualUnitTestObject<Employee> employee = test.CreateDual<Employee>();

            employee.Arrange(() => new Employee("abc") { MonthlySalary = monthlySalary, Seniority = senority });
            employee.Assert.EqualToDual(e => e.CalculateYearlySalary());

            test.Execute();
        }

        public void TestManagerCalculateYearlySalary(decimal monthlySalary, decimal bonus, int senority)
        {
            UnitTest test = factory.CreateTest();
            DualUnitTestObject<Manager> employee = test.CreateDual<Manager>();

            employee.Arrange(() => new Manager("abc") { MonthlySalary = monthlySalary, Bonus = bonus, Seniority = senority });
            employee.Assert.EqualToDual(e => e.CalculateYearlySalary());

            test.Execute();
        }
        
        /* Exercise 2A */
        [TestMethod("a. Name is public string property"), TestCategory("Exercise 2A")]
        public void NameIsPublicStringProperty()
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertProperty<Employee, string>(
                e => e.Name,
                new PropertyRequirements()
                {
                    GetMethod = new MethodRequirements() { IsPublic = true },
                    SetMethod = new MethodRequirements() { IsPublic = true }
                });
        }

        [TestMethod("b. Title is public string property"), TestCategory("Exercise 2A")]
        public void TitleIsPublicStringProperty()
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertProperty<Employee, string>(
                e => e.Title,
                new PropertyRequirements()
                {
                    GetMethod = new MethodRequirements() { IsPublic = true },
                    SetMethod = new MethodRequirements() { IsPublic = true }
                });
        }

        [TestMethod("c. MonthlySalary is public decimal property"), TestCategory("Exercise 2A")]
        public void MonthlySalaryIsPublicDecimalProperty()
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertProperty<Employee, decimal>(
                e => e.MonthlySalary,
                new PropertyRequirements()
                {
                    GetMethod = new MethodRequirements() { IsPublic = true },
                    SetMethod = new MethodRequirements() { IsPublic = true }
                });
        }

        [TestMethod("d. Seniority is public int property"), TestCategory("Exercise 2A")]
        public void SeniorityIsPublicIntProperty()
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertProperty<Employee, int>(
                e => e.Seniority,
                new PropertyRequirements()
                {
                    GetMethod = new MethodRequirements() { IsPublic = true },
                    SetMethod = new MethodRequirements() { IsPublic = true }
                });
        }

        [TestMethod("e. Employee constructor takes string as argument"), TestCategory("Exercise 2A")]
        public void EmployeeConstructorTakesStringAsArgument()
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertConstructor<string, Employee>(
                name => new Employee(name),
                new ConstructorRequirements()
                {
                    IsPublic = true
                });
        }

        [TestMethod("e. Employee constructor(string name) sets name property"), TestCategory("Exercise 2A")]
        public void EmployeeConstructorNameSetsNameProperty()
        {
            UnitTest test = factory.CreateTest();
            UnitTestObject<Employee> employee = test.Create<Employee>();

            employee.Arrange(() => new Employee("abc"));
            employee.Assert.IsTrue(e => e.Name == "abc");

            test.Execute();
        }

        [TestMethod("f. Title ignores assignment of null"), TestCategory("Exercise 2A")]
        public void TitleIgnoresAssignmentOfNull() => TestAssignmentOfEmployeePropertyIgnoresValue(e => e.Title, null);

        [TestMethod("g. Title ignores assignment of empty string"), TestCategory("Exercise 2A")]
        public void TitleIgnoresAssignmentOfEmptyString() => TestAssignmentOfEmployeePropertyIgnoresValue(e => e.Title, "");
        
        [TestMethod("h. MonthlySalary ignores assignment of -1M"), TestCategory("Exercise 2A")]
        public void MonthlySalaryIgnoresAssignmentOfMinusOne() => TestAssignmentOfEmployeePropertyIgnoresValue(e => e.Title, null);

        [TestMethod("i. Seniority ignores assignment of 0"), TestCategory("Exercise 2A")]
        public void SeniorityIgnoresAssignmentOfZero() => TestAssignmentOfEmployeePropertyIgnoresValue(e => e.Seniority, 0);

        [TestMethod("j. Seniority ignores assigment of 11"), TestCategory("Exercise 2A")]
        public void SeniorityIgnoresAssignmentOfEleven() => TestAssignmentOfEmployeePropertyIgnoresValue(e => e.Seniority, 11);

        /* Exercise 2B */
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

        /* Exercise 2C */
        [TestMethod("a. Manager is subclass of Employee"), TestCategory("Exercise 2C")]
        public void ManagerIsSubclassOfEmployee()
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertClass<Manager>(
                new ClassRequirements()
                {
                    BaseType = typeof(Employee)
                });
        }

        [TestMethod("b. Bonus is public decimal property"), TestCategory("Exercise 2C")]
        public void BonusIsPublicDecimalProperty() 
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertProperty<Manager, decimal>(
                e => e.Bonus,
                new PropertyRequirements()
                {
                    GetMethod = new MethodRequirements() { IsPublic = true },
                    SetMethod = new MethodRequirements() { IsPublic = true }
                });
        }

        [TestMethod("c. Bonus ignores assignment of -1M"), TestCategory("Exercise 2C")]
        public void BonusIgnoresAssignmentOfMinusOne() => TestAssignmentOfManagerPropertyIgnoresValue(m => m.Bonus, -1);

        /* Exercise 2D */
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

        /* Exercise 2E */
        [TestMethod("a. Company.Employees is a public List<Employee> property"), TestCategory("Exercise 2E")]
        public void EmployeesIsPublicListEmployeeProperty() {
            StructureTest test = factory.CreateStructureTest();
            test.AssertProperty<Company, List<Employee>>(
                c => c.Employees,
                new PropertyRequirements()
                {
                    GetMethod = new MethodRequirements() { IsPublic = true },
                });
        }

        [TestMethod("b. Company.Hire(Employee e) adds employee to Employees"), TestCategory("Exercise 2E")]
        public void CompanyHireAddsEmployeeToEmployees()
        {
            UnitTest test = factory.CreateTest();
            UnitTestObject<Employee> employee = test.Create<Employee>();
            UnitTestObject<Company> company = test.Create<Company>();

            employee.Arrange(() => new Employee("Ellen Stevens"));
            company.Arrange(() => new Company());
            company.WithParameters(employee).Act((c, e) => c.Hire(e));
            company.WithParameters(employee).CollectionAssert.Contains(c => c.Employees);

            test.Execute();
        }

        [TestMethod("c. Company.Fire(Employee e) removes employee from Employees"), TestCategory("Exercise 2E")]
        public void CompanyFireAddsEmployeeToEmployees()
        {
            UnitTest test = factory.CreateTest();
            UnitTestObject<Employee> employee = test.Create<Employee>();
            UnitTestObject<Company> company = test.Create<Company>();

            employee.Arrange(() => new Employee("Ellen Stevens"));
            company.Arrange(() => new Company());
            company.WithParameters(employee).Act((c, e) => c.Hire(e));
            company.WithParameters(employee).Act((c, e) => c.Fire(e));
            company.CollectionAssert.IsEmpty(c => c.Employees);

            test.Execute();
        }


        [TestMethod("d. Company.Hire(Employee e) adds manager to Employees"), TestCategory("Exercise 2E")]
        public void CompanyHireAddsManagerToEmployees()
        {
            UnitTest test = factory.CreateTest();
            UnitTestObject<Manager> manager = test.Create<Manager>();
            UnitTestObject<Company> company = test.Create<Company>();

            manager.Arrange(() => new Manager("Katja Holmes"));
            company.Arrange(() => new Company());
            company.WithParameters(manager).Act((c, e) => c.Hire(e));
            company.WithParameters(manager).CollectionAssert.Contains(c => c.Employees);

            test.Execute();
        }

        [TestMethod("e. Company.Fire(Employee e) removes manager to Employees"), TestCategory("Exercise 2E")]
        public void CompanyFireAddsManagerToEmployees()
        {
            UnitTest test = factory.CreateTest();
            UnitTestObject<Manager> manager = test.Create<Manager>();
            UnitTestObject<Company> company = test.Create<Company>();

            manager.Arrange(() => new Manager("Katja Holmes"));
            company.Arrange(() => new Company());
            company.WithParameters(manager).Act((c, e) => c.Hire(e));
            company.WithParameters(manager).Act((c, e) => c.Fire(e));
            company.CollectionAssert.IsEmpty(c => c.Employees);

            test.Execute();
        }

        /* Exercise 2F */
        [TestMethod("a. Company.CalculateYearlySalaryCosts() returns 0 for company without employees"), TestCategory("Exercise 2F")]
        public void CompanyCalculateYearlySalaryCostsReturnsZeroForCompanyWithoutEmployees()
        {
            UnitTest test = factory.CreateTest();
            UnitTestObject<Company> company = test.Create<Company>();

            company.Arrange(() => new Company());
            company.Assert.IsTrue(c => c.CalculateYearlySalaryCosts() == 0);

            test.Execute();
        }
        
        [TestMethod("b. Company.CalculateYearlySalaryCosts() returns expected output for company with 1 Employee"), TestCategory("Exercise 2F")]
        public void CompanyCalculateYearlySalaryCostsReturnsExpectedOutputForCompanyWithOneEmployee()
        {
            UnitTest test = factory.CreateTest();
            DualUnitTestObject<Company> company = test.CreateDual<Company>();
            DualUnitTestObject<Employee> employee = test.CreateDual<Employee>();

            company.Arrange(() => new Company());
            employee.Arrange(() => new Employee("Allan Walker") { MonthlySalary = 30000M, Seniority = 4 });
            company.WithParameters(employee).Act((c, e) => c.Hire(e));
            company.Assert.EqualToDual(c => c.CalculateYearlySalaryCosts());

            test.Execute();
        }

    [TestMethod("c. Company.CalculateYearlySalaryCosts() returns expected output for company with 2 Employees"), TestCategory("Exercise 2F")]
        public void CompanyCalculateYearlySalaryCostsReturnsExpectedOutputForCompanyWithTwoEmployee() 
        {
            UnitTest test = factory.CreateTest();
            DualUnitTestObject<Company> company = test.CreateDual<Company>();
            DualUnitTestObject<Employee> employee1 = test.CreateDual<Employee>();
            DualUnitTestObject<Employee> employee2 = test.CreateDual<Employee>();

            company.Arrange(() => new Company());
            employee1.Arrange(() => new Employee("Allan Walker") { MonthlySalary = 30000M, Seniority = 4 });
            employee2.Arrange(() => new Employee("Amy Walker") { MonthlySalary = 30000M, Seniority = 4 });
            company.WithParameters(employee1).Act((c, e) => c.Hire(e));
            company.WithParameters(employee2).Act((c, e) => c.Hire(e));
            company.Assert.EqualToDual(c => c.CalculateYearlySalaryCosts());

            test.Execute();
        }
    }
}
