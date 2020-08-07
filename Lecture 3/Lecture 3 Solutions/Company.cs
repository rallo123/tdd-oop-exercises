using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_1_Potential_Solutions
{
    public class Company
    {
        public List<Employee> Employees { get; };

        public Company()
        {
            Employees = new List<Employee>();
        }

        public decimal CalculateYearlyExpenses()
        {
            decimal total = 0;

            foreach (Employee employee in Employees)
                total += employee.CalculateYearlySalary();

            return total;
        }
    }
}
