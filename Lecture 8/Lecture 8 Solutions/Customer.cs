﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TestTools.Syntax;

namespace Lecture_8_Solutions
{
    public class Customer : INotifyPropertyChanged
    {
        int _id;
        string _firstName;
        string _lastName;

        public event PropertyChangedEventHandler PropertyChanged;

        public int ID
        {
            get { return _id; }
            set
            {
                int previousValue = _id;
                
                _id = value;

                if (value != previousValue)
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ID"));
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                string previousValue = _firstName;

                _firstName = value;

                if (value != previousValue)
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FirstName"));
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                string previousValue = _lastName;

                _lastName = value;

                if(value != previousValue)
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastName"));
            }
        }

        // TestTools Code
        [PropertySet("ID")]
        public void SetID(int value) => ID = value;

        [PropertySet("FirstName")]
        public void SetFirstName(string value) => FirstName = value;

        [PropertySet("LastName")]
        public void SetLastName(string value) => LastName = value;

        [EventAdd("PropertyChanged")]
        public void AddPropertyChanged(PropertyChangedEventHandler handler) => PropertyChanged += handler;
    }
}
