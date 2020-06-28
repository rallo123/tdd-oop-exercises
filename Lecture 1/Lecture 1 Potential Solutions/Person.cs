using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_1_Potential_Solutions
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private Person mother;
        private Person father;
        private static int nextID;

        public Person()
        {
            ID = nextID;
            nextID++;
        }

        public Person(Person mother, Person father) : this()
        {
            Mother = mother;
            Father = father;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (IsValidName(value))
                    firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (IsValidName(value))
                    lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value >= 0)
                    age = value;
            }
        }

        public int ID { get; }

        public Person Mother
        {
            get
            {
                return mother;
            }
            set
            {
                if (IsValidParent(value))
                    mother = value;
            }
        }

        public Person Father
        {
            get
            {
                return father;
            }
            set
            {
                if (IsValidParent(value))
                    father = value;
            }
        }

        private bool IsValidName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            if (name.Length > 100)
                return false;

            foreach (char c in name.ToLower())
            {
                if (c < 'a' || c > 'z')
                    return false;
            }
            return true;
        }

        private bool IsValidParent(Person parent)
        {
            if (parent == null)
                return false;

            if (parent.Age < Age)
                return false;

            return true;
        }
    }
}
