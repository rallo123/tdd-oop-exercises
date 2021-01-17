using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_6_Potential_Solutions
{
    public class Car
    {
        string _make;
        string _model;
        decimal _price;
        
        static int _lastID;
        
        public int ID { get; } = _lastID++;
        
        public string Make {
            get { return _make; }
            private set {
                if (value == null)
                    throw new ArgumentNullException();
                _make = value;
            }
        }

        public string Model {
            get { return _model; }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException();
                _model = value;
            }
        }

        public decimal Price {
            get { return _price; }
            private set {
                if (value < 0)
                    throw new ArgumentException();
                _price = value;
            }
        }

        public Car(string make, string model, decimal price)
        {
            Make = make;
            Model = model;
            Price = price;
        }
    }
}
