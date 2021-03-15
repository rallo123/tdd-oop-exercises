﻿using System;
using System.Collections.Generic;
using System.Text;
using TestTools.Syntax;

namespace Lecture_3_Solutions
{
    public class Manager : Employee
    {
        private decimal _bonus;

        public Manager(string name) : base(name)
        {
        }

        public decimal Bonus
        {
            get { return _bonus; }
            set
            {
                if (value > 0)
                    _bonus = value;
            }
        }

        public override decimal CalculateYearlySalary()
        {
            return Bonus + base.CalculateYearlySalary();
        }

        public override string ToString()
        {
            return $"Manager {Name} ({Title})";
        }

        // TestTools Code
        [PropertySet("Bonus")]
        public void SetBonus(decimal value) => Bonus = value; 
    }
}
