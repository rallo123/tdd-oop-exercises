using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Lecture_1_Potential_Solutions
{
    public class Employee
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public decimal MonthlySalary { get; set; }

        public int Seneority { get; set; }//may not be higher than 10 

        private decimal CalculateSeniorityBonus()
        {
            if (Seneority >= 7)
                return 0.7M;
            if (Seneority >= 4)
                return 0.4M;

            return 0.1;
        }

        public virtual decimal CalculateYearlySalary()
        {
            decimal seniorityBonus;

            
            

            return 12 * MonthlySalary * CalculateSeniorityBonus();
        }
    }
}
