using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_3_Solutions
{
    public abstract class Vehicle
    {
        private static int _lastID;

        protected Vehicle()
        {
            ID = _lastID++;
        }

        public int ID { get; }
        public double FuelLevel { get; protected set; }
        public abstract void Refill(double amount);
    }
}
