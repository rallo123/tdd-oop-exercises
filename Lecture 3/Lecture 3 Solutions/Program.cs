using System;

namespace Lecture_3_Solutions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Car car = new Car(35.00);
            Console.Write($"Refueling car with ID {car.ID} from fuel level {car.FuelLevel}");
            car.Refill(50);
            Console.WriteLine($" to fuel level {car.FuelLevel}");
        }
    }
}
