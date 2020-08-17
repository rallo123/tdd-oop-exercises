using Lecture_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TestTools.Operation;
using TestTools.Structure;
using TestTools.Structure.Generic;

namespace Lecture_3_Tests
{
    [TestClass]
    public class Exercise_2_Tests
    {
#pragma warning disable IDE1006 // Naming Stylesw
        private ClassElement<Employee> employee => new ClassElement<Employee>();

        private PropertyElement<Employee, string> employeeName => employee.Property<string>("Name", get: new AccessorOptions() { AccessLevel = AccessLevel.Public });
        private PropertyElement<Employee, string> employeeTitle => employee.Property<string>("Title", get: new AccessorOptions() { AccessLevel = AccessLevel.Public }, set: new AccessorOptions() { AccessLevel = AccessLevel.Public });
        private PropertyElement<Employee, decimal> employeeMonthlySalary => employee.Property<decimal>("MonthlySalary", get: new AccessorOptions() { AccessLevel = AccessLevel.Public }, set: new AccessorOptions() { AccessLevel = AccessLevel.Public });
        private PropertyElement<Employee, int> employeeSeniority => employee.Property<int>("Seniority", get: new AccessorOptions() { AccessLevel = AccessLevel.Public }, set: new AccessorOptions() { AccessLevel = AccessLevel.Public });
        private FuncMethodElement<Employee, decimal> employeeCalculateYearlySalary => employee.FuncMethod<decimal>("CalculateYearlySalary", new MethodOptions() { AccessLevel = AccessLevel.Public });

        private Employee CreateEmployee(string name = "Allan", string title = null, decimal? monthlySalary = null, int? seniority = null)
        {
            Employee instance = employee.Constructor<string>().Invoke(name);

            if (title != null)
                employeeTitle.Set(instance, title);
            if (monthlySalary != null)
                employeeMonthlySalary.Set(instance, monthlySalary);
            if (seniority != null)
                employeeSeniority.Set(instance, seniority);

            return instance;
        }

        private void TestEmployeeCalculateYearlySalary(decimal monthlySalary, int seniority)
        {
            Employee employee = CreateEmployee(monthlySalary: monthlySalary, seniority: seniority);
            decimal actualYearlySalary = employeeCalculateYearlySalary.Invoke(employee);
            decimal expectedYearlySalary = 12 * monthlySalary * (1M + GetSeniorityBonus(seniority));

            if (actualYearlySalary == expectedYearlySalary)
            {
                string message = string.Format(
                    "Employee.CalculateYearlySalary() returns {0} instead of {1} for MonthlySalary = {2} & Seniority = {3}",
                    actualYearlySalary,
                    expectedYearlySalary,
                    monthlySalary,
                    seniority
                );
                throw new AssertFailedException(message);
            }
        }
        private decimal GetSeniorityBonus(int seniority)
        {
            switch (seniority)
            {
                case 1:
                case 2:
                    return 0.1M;
                case 3:
                case 4:
                case 5:
                case 6:
                    return 0.3M;
                case 7:
                case 8:
                case 9:
                case 10:
                    return 0.7M;
                default: throw new ArgumentException();
            }
        }

        private ClassElement<Manager> manager => new ClassElement<Manager>(new ClassOptions() { BaseType = typeof(Employee) });

        private PropertyElement<Manager, string> managerName => manager.Property<string>("Name", get: new AccessorOptions() { AccessLevel = AccessLevel.Public });
        private PropertyElement<Manager, string> managerTitle => manager.Property<string>("Title", get: new AccessorOptions() { AccessLevel = AccessLevel.Public }, set: new AccessorOptions() { AccessLevel = AccessLevel.Public });
        private PropertyElement<Manager, decimal> managerMonthlySalary => manager.Property<decimal>("MonthlySalary", get: new AccessorOptions() { AccessLevel = AccessLevel.Public }, set: new AccessorOptions() { AccessLevel = AccessLevel.Public });
        private PropertyElement<Manager, int> managerSeniority => manager.Property<int>("Seniority", get: new AccessorOptions() { AccessLevel = AccessLevel.Public }, set: new AccessorOptions() { AccessLevel = AccessLevel.Public });
        private PropertyElement<Manager, decimal> managerBonus => manager.Property<decimal>("Bonus", get: new AccessorOptions() { AccessLevel = AccessLevel.Public }, set: new AccessorOptions() { AccessLevel = AccessLevel.Public });
        private FuncMethodElement<Manager, decimal> managerCalculateYearlySalary => manager.FuncMethod<decimal>("CalculateYearlySalary", new MethodOptions() { AccessLevel = AccessLevel.Public });

        private Manager CreateManager(string name = "abc", string title = null, decimal? monthlySalary = null, int? seniority = null, decimal? bonus = null)
        {
            Manager instance = manager.Constructor<string>().Invoke(name);

            if (title != null)
                managerTitle.Set(instance, title);
            if (monthlySalary != null)
                managerMonthlySalary.Set(instance, monthlySalary);
            if (seniority != null)
                managerSeniority.Set(instance, seniority);
            if (bonus != null)
                managerBonus.Set(instance, bonus);
            
            return instance;
        }

        private void TestManagerCalculateYearlySalary(decimal monthlySalary, decimal bonus, int seniority)
        {
            Manager manager = CreateManager(monthlySalary: monthlySalary, seniority: seniority, bonus: bonus);
            decimal actualYearlySalary = managerCalculateYearlySalary.Invoke(manager);
            decimal expectedYearlySalary = 12 * monthlySalary * (1M + GetSeniorityBonus(seniority));

            if (actualYearlySalary == expectedYearlySalary)
            {
                string message = string.Format(
                    "Manager.CalculateYearlySalary() returns {0} instead of {1} for MonthlySalary = {2}, Bonus = {3} & Seniority = {4}",
                    actualYearlySalary,
                    expectedYearlySalary,
                    monthlySalary,
                    bonus,
                    seniority
                );
                throw new AssertFailedException(message);
            }
        }

        private ClassElement<Company> company => new ClassElement<Company>();

        private PropertyElement<Company, List<Employee>> companyEmployees => company.Property<List<Employee>>("Employees", get: new AccessorOptions() { AccessLevel = AccessLevel.Public });
        private ActionMethodElement<Company, Employee> companyHire => company.ActionMethod<Employee>("Hire", new MethodOptions() { AccessLevel = AccessLevel.Public });
        private ActionMethodElement<Company, Employee> companyFire => company.ActionMethod<Employee>("Fire", new MethodOptions() { AccessLevel = AccessLevel.Public });
        private FuncMethodElement<Company, decimal> companyCalculateYearlySalaryCosts => company.FuncMethod<decimal>("CalculateYearlySalaryCosts", new MethodOptions() { AccessLevel = AccessLevel.Public });

        private Company CreateCompany()
        {
            return company.Constructor().Invoke();
        }

        private void TestCompanyCalculateYearlySalaryCosts(params Employee[] employees)
        {
            Company company = CreateCompany();
            List<Employee> staff = companyEmployees.Get(company);

            decimal expectedCosts = 0;
            foreach (Employee employee in employees)
            {
                staff.Add(employee);

                if (employee.GetType() == typeof(Manager))
                {
                    expectedCosts += managerCalculateYearlySalary.Invoke((Manager)(object)employee);
                }
                else expectedCosts += employeeCalculateYearlySalary.Invoke(employee);
            }
            decimal actualCosts = companyCalculateYearlySalaryCosts.Invoke(company);


            if (actualCosts != expectedCosts)
            {
                string message = string.Format(
                   "Company.CalculateYearlySalaryCosts() returns {0} instead of {1} for Company.Employees.Count = {2}",
                   actualCosts,
                   expectedCosts,
                   companyEmployees.Get(company).Count()
                );
                throw new AssertFailedException(message);
            }
        }

        private void DoNothing(object par) { }
#pragma warning restore IDE1006 // Naming Styles
        
        public Exercise_2_Tests()
        {
        }


        /* Exercise 2A */
        [TestMethod("a. Name is public string property"), TestCategory("Exercise 2A")]
        public void NameIsPublicStringProperty() => DoNothing(employeeName);

        [TestMethod("b. Title is public string property"), TestCategory("Exercise 2A")]
        public void TitleIsPublicStringProperty() => DoNothing(employeeTitle);

        [TestMethod("c. MonthlySalary is public decimal property"), TestCategory("Exercise 2A")]
        public void MonthlySalaryIsPublicDecimalProperty() => DoNothing(employeeMonthlySalary);

        [TestMethod("d. Seniority is public int property"), TestCategory("Exercise 2A")]
        public void SeniorityIsPublicIntProperty() => DoNothing(employeeSeniority);

        [TestMethod("e. Employee constructor takes string as argument"), TestCategory("Exercise 2A")]
        public void EmployeeConstructorTakesStringAsArgument() => DoNothing(employee.Constructor<string>());

        [TestMethod("e. Employee constructor(string name) sets name property"), TestCategory("Exercise 2A")]
        public void EmployeeConstructorNameSetsNameProperty()
        {
            Employee employee = CreateEmployee("abc");

            if (employeeName.Get(employee) != "abc")
                throw new AssertFailedException("Employee constructor Employee(string name) do not set Name");
        }

        [TestMethod("f. Title ignores assignment of null"), TestCategory("Exercise 2A")]
        public void TitleIgnoresAssignmentOfNull() => Assignment.Ignored(CreateEmployee(), employeeTitle, null);

        [TestMethod("g. Title ignores assignment of empty string"), TestCategory("Exercise 2A")]
        public void TitleIgnoresAssignmentOfEmptyString() => Assignment.Ignored(CreateEmployee(), employeeTitle, null);

        [TestMethod("h. MonthlySalary ignores assignment of -1M"), TestCategory("Exercise 2A")]
        public void MonthlySalaryIgnoresAssignmentOfMinusOne() => Assignment.Ignored(CreateEmployee(), employeeMonthlySalary, -1M);

        [TestMethod("i. Seniority ignores assignment of 0"), TestCategory("Exercise 2A")]
        public void SeniorityIgnoresAssignmentOfZero() => Assignment.Ignored(CreateEmployee(), employeeSeniority, 0);

        [TestMethod("j. Seniority ignores assigment of 11"), TestCategory("Exercise 2A")]
        public void SeniorityIgnoresAssignmentOfEleven() => Assignment.Ignored(CreateEmployee(), employeeSeniority, 11);

        /* Exercise 2B */
        [TestMethod("a. Employee.CalculateYearlySalary() returns expected output for seniority 1"), TestCategory("Exercise 2B")]
        public void EmployeeCalculateYearlySalaryAddsTenProcentForSeniorityLevelOne() => TestEmployeeCalculateYearlySalary(34000, 1);

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
            if (!typeof(Manager).IsSubclassOf(typeof(Employee)))
                throw new AssertFailedException("Manager does not inherit from Employee");
        }

        [TestMethod("b. Bonus is public decimal property"), TestCategory("Exercise 2C")]
        public void BonusIsPublicDecimalProperty() => DoNothing(managerBonus);

        [TestMethod("c. Bonus ignores assignment of -1M"), TestCategory("Exercise 2C")]
        public void BonusIgnoresAssignmentOfMinusOne() => Assignment.Ignored(CreateManager(), managerBonus, -1M);

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
        [TestMethod("a. Employees is a public List<Employee> property"), TestCategory("Exercise 2E")]
        public void EmployeesIsPublicListEmployeeProperty() => DoNothing(companyEmployees);

        [TestMethod("b. Company.Hire(Employee e) adds employee to Employees"), TestCategory("Exercise 2E")]
        public void CompanyHireAddsEmployeeToEmployees()
        {
            Employee employee = CreateEmployee("Ellen Stevens", "Programmer");
            Company company = CreateCompany();
            List<Employee> employees = companyEmployees.Get(company);

            companyHire.Invoke(company, employee);

            if (!employees.Any(e => e == employee))
                throw new AssertFailedException($"Company.Hire(Employee e) does not add Employee {employeeName.Get(employee)} ({employeeTitle.Get(employee)}) to Employees");
        }

        [TestMethod("c. Company.Fire(Employee e) removes employee to Employees"), TestCategory("Exercise 2E")]
        public void CompanyFireAddsEmployeeToEmployees()
        {
            Employee employee = CreateEmployee("Ellen Stevens", "Programmer");
            Company company = CreateCompany();
            List<Employee> employees = companyEmployees.Get(company);
            employees.Add(employee);

            companyFire.Invoke(company, employee);

            if (employees.Any(e => e == employee))
                throw new AssertFailedException($"Company.Hire(Employee e) does not remove Employee {employeeName.Get(employee)} ({employeeTitle.Get(employee)} from Employees");
        }


        [TestMethod("d. Company.Hire(Employee e) adds manager to Employees"), TestCategory("Exercise 2E")]
        public void CompanyHireAddsManagerToEmployees()
        {
            Employee manager = (Employee)(object)CreateManager("Katja Holmes", "Programmer Manager");
            Company company = CreateCompany();
            List<Employee> employees = companyEmployees.Get(company);

            companyHire.Invoke(company, manager);

            if (!employees.Any(e => e == manager))
                throw new AssertFailedException($"Company.Hire(Employee e) does not add Manager {employeeName.Get(employee)} ({employeeTitle.Get(employee)}) to Employees");
        }

        [TestMethod("e. Company.Fire(Employee e) removes manager to Employees"), TestCategory("Exercise 2E")]
        public void CompanyFireAddsManagerToEmployees()
        {
            Employee manager = (Employee)(object)CreateManager("Katja Holmes", "Programmer Manager");
            Company company = CreateCompany();
            List<Employee> employees = companyEmployees.Get(company);
            employees.Add(manager);

            companyFire.Invoke(company, manager);

            if (employees.Any(e => e == manager))
                throw new AssertFailedException($"Company.Hire(Employee e) does not remove Manager {employeeName.Get(manager)} ({employeeTitle.Get(manager)}) from Employees");
        }

        /* Exercise 2F */
        [TestMethod("a. Company.CalculateYearlySalaryCosts() returns 0 for company without employees"), TestCategory("Exercise 2F")]
        public void CompanyCalculateYearlySalaryCostsReturnsZeroForCompanyWithoutEmployees() => TestCompanyCalculateYearlySalaryCosts();

        [TestMethod("b. Company.CalculateYearlySalaryCosts() returns expected output for company with 1 Employee"), TestCategory("Exercise 2F")]
        public void CompanyCalculateYearlySalaryCostsReturnsExpectedOutputForCompanyWithOneEmployee() => TestCompanyCalculateYearlySalaryCosts(CreateEmployee("Allan Walker", "IT Support", 30000, 4));

        [TestMethod("c. Company.CalculateYearlySalaryCosts() returns expected output for company with 2 Employees"), TestCategory("Exercise 2F")]
        public void CompanyCalculateYearlySalaryCostsReturnsExpectedOutputForCompanyWithTwoEmployee() => TestCompanyCalculateYearlySalaryCosts(CreateEmployee("Allan Walker", "IT Support", 30000, 4), CreateEmployee("Amy Walker", "IT Support", 30000, 7));
    }
}
