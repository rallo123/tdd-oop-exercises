using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_2_Solutions
{
    public class PersonPrinter
    {
        public void PrintPerson(Person p)
        {
            Console.WriteLine(p.FirstName + " " + p.LastName + " (" + p.Age + ")");
        }

        public void PrintFamily(Person p, int generation = 0)
        {
            for (int i = 0; i < generation; i++)
                Console.Write("  ");

            PrintPerson(p);

            if(p.Father != null)
                PrintFamily(p.Father, generation + 1);
            if(p.Mother != null)
                PrintFamily(p.Mother, generation + 1);
        }
    }
}
