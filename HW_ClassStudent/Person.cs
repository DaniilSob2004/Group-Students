using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_Address;
using CorrectInput;


namespace HW_ClassStudent
{
    [Serializable]
    public class Person
    {
        private string name;
        private string surname;
        private DateTime birthDate;
        private Address address;
        private string phoneNumber;

        public Person() :
            this("", "") { }

        public Person(string name, string surname) :
            this(name, surname, new DateTime(), new Address()) { }

        public Person(string name, string surname, DateTime birthDate, Address address, string phoneNumber = "")
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (!CheckCorrect.CheckString(value, 2))
                {
                    throw new Exception("Name must be >= 2 symbols!");
                }
                name = value;
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                if (!CheckCorrect.CheckString(value, 2))
                {
                    throw new Exception("Surname must be >= 3 symbols!");
                }
                surname = value;
            }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Reference DateTime must be not null!");
                }

                if (value > DateTime.Now)
                {
                    throw new Exception("A person cannot have such a date!");
                }

                birthDate = value;
            }
        }

        public Address Address
        {
            get { return address; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Reference Address must be not null!");
                }
                address = value;
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                // empty - значение по умолчанию (если вызывается конструктор по умолчанию)
                if (value != "")
                {
                    // проверка на корректность ввода
                    if (!CheckCorrect.CheckPhoneNumber(value))
                    {
                        throw new Exception("Incorrect phone number!");
                    }
                }
                phoneNumber = value;
            }
        }

        public override string ToString()
        {
            return $"Name: {name}\n" +
                   $"Surname: {surname}\n" +
                   $"Birthdate: {birthDate.Day}.{birthDate.Month}.{birthDate.Year}\n" + 
                   $"Address: {address}\n" + 
                   $"phoneNumber: {phoneNumber}\n";
        }
    }
}
