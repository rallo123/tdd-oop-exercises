using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_3_Solutions
{
    public class Company
    {
        private string _name;
        

        public Company()
        {
            Employees = new List<Employee>();
        }

        public List<Employee> Employees { get; }

        public void Hire(Employee employee)
        {
            Employees.Add(employee);
        }

        public void Fire(Employee employee)
        {
            Employees.Remove(employee);
        }

        public decimal CalculateYearlySalaryCosts()
        {
            decimal total = 0;

            foreach (Employee employee in Employees)
                total += employee.CalculateYearlySalary();

            return total;
        }
    }
}
