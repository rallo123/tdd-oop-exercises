using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_1_Potential_Solutions
{
    public class PersonGenerator
    {
        public Person GeneratePerson()
        {
            return new Person()
            {
                FirstName = "Adam",
                LastName = "Smith",
                Age = 36
            };
        }

        public Person GenerateFamily()
        {
            //Grandparents 
            Person gustav = new Person()
            {
                FirstName = "Gustav",
                LastName = "Rich",
                Age = 66
            };
            Person elsa = new Person()
            {
                FirstName = "Elsa",
                LastName = "Johnson",
                Age = 65
            };

            //Parents 
            Person warren = new Person(elsa, gustav)
            {
                FirstName = "Warren",
                LastName = "Rich",
                Age = 36,
            };
            Person anna = new Person()
            {
                FirstName = "Anna",
                LastName = "Smith",
                Age = 38
            };

            //Child
            return new Person(anna, warren)
            {
                FirstName = "Robin",
                LastName = "Rich",
                Age = 10
            };
        }
    }
}
