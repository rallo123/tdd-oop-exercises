using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_3_Solutions
{
    public class Car : Vehicle
    {
        private double _maxFuelLevel;

        public Car(double maxFuelLevel) : base()
        {
            _maxFuelLevel = maxFuelLevel;
        }

        public override void Refill(double amount)
        {
            if (FuelLevel + amount <= _maxFuelLevel)
                FuelLevel += amount;
            else FuelLevel = _maxFuelLevel;
        }
    }
}
