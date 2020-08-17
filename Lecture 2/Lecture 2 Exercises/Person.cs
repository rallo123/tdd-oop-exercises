using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Lecture_2
{
    public class Person
    {
        string _firstName;
        string _lastName;
        int _age;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (Regex.IsMatch(value, @"^[a-zA-Z]+$") && value.Length < 100) _firstName = value;
            }
        }
        public string LastName
        {
            get {return _lastName;}
            set
            {
                if (Regex.IsMatch(value, @"^[a-zA-Z]+$") && value.Length < 100) _lastName = value; 
            }
        }
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value > 0) _age = value;
            }
        }
    }
}
