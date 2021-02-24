using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TestTools.Syntax;

namespace Lecture_3_Solutions
{
    public class Employee
    {
        private string _name;
        private string _jobTitle;
        private decimal _monthlySalary;
        private int _seniority;

        public Employee(string name) {
            Name = name;
        }

        public int ID { get; }

        public string Name {
            get { return _name; }
            private set 
            {
                if (!string.IsNullOrEmpty(value))
                    _name = value;
            }
        }

        public string Title {
            get { return _jobTitle; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    _jobTitle = value;
            }
        }

        public decimal MonthlySalary {
            get { return _monthlySalary; } 
            set
            {
                if (value >= 0)
                    _monthlySalary = value;
            }
        }

        public int Seniority {
            get { return _seniority; }
            set {
                if (1 <= value && value <= 10)
                    _seniority = value;
            }
        }

        public virtual decimal CalculateYearlySalary()
        {
            decimal seneorityBonus;

            if (Seniority >= 7)
                seneorityBonus = 0.7M;
            else if (Seniority >= 4)
                seneorityBonus = 0.4M;
            else seneorityBonus = 0.1M;

            return 12 * MonthlySalary * seneorityBonus;
        }

        public override string ToString()
        {
            return $"Employee {Name} ({Title})";
        }

        // TestTools Code
        [PropertySet("Title")]
        public void SetTitle(string value) => Title = value;

        [PropertySet("MonthlySalary")]
        public void SetMonthlySalary(decimal value) => MonthlySalary = value;

        [PropertySet("Seniority")]
        public void SetSeniority(int value) => Seniority = value;
    }
}
