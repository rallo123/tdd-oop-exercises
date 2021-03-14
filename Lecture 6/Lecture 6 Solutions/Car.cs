using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_6_Solutions
{
    public class Car : IComparable
    {
        string _make;
        string _model;
        decimal _price;

        public int ID { get; set; }
        
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

        public int CompareTo(object obj)
        {
            Car other = obj as Car;
            return other == null ? 1 : this.ID - other.ID;
        }
    }
}
