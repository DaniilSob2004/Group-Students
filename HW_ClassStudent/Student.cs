using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_Address;
using CorrectInput;


namespace HW_ClassStudent
{
    public class Student
    {
        private int id;
        private string name;
        private string surname;
        private DateTime birthDate;
        private Address address;
        private string phoneNumber;
        private List<int> gradeCW;
        private List<int> gradeHW;
        private List<int> gradeExam;

        private static int minYearStud = 14;
        private static int ID = 0;
        
        public Student() :
            this("Name", "Surname") { }

        public Student(string name, string surname) : 
            this(name, surname, DateTime.Now, new Address()) { }

        public Student(string name, string surname, DateTime birthDate, Address address, string phoneNumber = "empty")
        {
            SetName(name);
            SetSurname(surname);
            SetBirthDate(birthDate);
            SetAddress(address);

            gradeCW = new List<int>();
            gradeHW = new List<int>();
            gradeExam = new List<int>();

            id += ++ID;  // id студента
        }

        public int GetID()
        {
            return id;
        }

        public string GetName()
        {
            return name;
        }

        public string GetSurname()
        {
            return surname;
        }

        public DateTime GetBirthDate()
        {
            return birthDate;
        }

        public Address GetAddress()
        {
            return address;
        }

        public string GetPhoneNumber()
        {
            return phoneNumber;
        }
    
        public void SetName(string name)
        {
            if (!CheckCorrect.CheckString(name, 2))
            {
                throw new Exception("Name student must be >= 2 symbols!");
            }
            this.name = name;
        }

        public void SetSurname(string surname)
        {
            if (!CheckCorrect.CheckString(surname, 2))
            {
                throw new Exception("Surname student must be >= 3 symbols!");
            }
            this.surname = surname;
        }

        public void SetBirthDate(DateTime birthDate)
        {
            if (birthDate == null)
            {
                throw new NullReferenceException("Reference DateTime must be not null!");
            }

            // DateTime.Now.Year - значение по умолчанию (если вызывается конструктор по умолчанию)
            else if (birthDate.Year != DateTime.Now.Year)
            {
                if ((DateTime.Now.Year - birthDate.Year) < minYearStud)
                {
                    throw new Exception($"The student must be over {minYearStud} years of age!");
                }
            }
            this.birthDate = birthDate;
        }

        public void SetAddress(Address address)
        {
            if (address == null)
            {
                throw new NullReferenceException("Reference Address must be not null!");
            }
            this.address = address;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            // empty - значение по умолчанию (если вызывается конструктор по умолчанию)
            if (phoneNumber != "empty")
            {
                if (!CheckCorrect.CheckPhoneNumber(phoneNumber))
                {
                    throw new Exception("Incorrect phone number!");
                }
            }
            this.phoneNumber = phoneNumber;
        }

        public void AddGradeCW(int grade)
        {
            if (!CheckCorrect.CheckDigit(grade, 1, 12))
            {
                throw new Exception("Grade for CW must be from 1 to 12!");
            }
            gradeCW.Add(grade);
        }

        public void AddGradeHW(int grade)
        {
            if (!CheckCorrect.CheckDigit(grade, 1, 12))
            {
                throw new Exception("Grade for HW must be from 1 to 12!");
            }
            gradeHW.Add(grade);
        }

        public void AddGradeExam(int grade)
        {
            if (!CheckCorrect.CheckDigit(grade, 1, 100))
            {
                throw new Exception("Grade for exam must be from 1 to 100!");
            }
            gradeExam.Add(grade);
        }

        public float AverageGradeCW()
        {
            float result = 0;
            foreach (int i in gradeCW)
            {
                result += i;
            }
            return result / gradeCW.Count;
        }

        public float AverageGradeHW()
        {
            float result = 0;
            foreach (int i in gradeHW)
            {
                result += i;
            }
            return result / gradeHW.Count;
        }

        public float AverageGradeExam()
        {
            float result = 0;
            foreach (int i in gradeExam)
            {
                result += i;
            }
            return result / gradeExam.Count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("---------- Student Info ---------\n");
            sb.Append($"ID: {id}\n");
            sb.Append($"Name: {name}\nSurname: {surname}\n");
            sb.Append($"Birthdate: {birthDate.Day}.{birthDate.Month}.{birthDate.Year}\n");
            sb.Append($"Address: {address}\n");
            sb.Append($"phoneNumber: {phoneNumber}\n");

            sb.Append("Grade class work: ");
            foreach (int grade in gradeCW) sb.Append($"{grade} - ");
            sb.Append("\n");

            sb.Append("Grade home work: ");
            foreach (int grade in gradeHW) sb.Append($"{grade} - ");
            sb.Append("\n");

            sb.Append("Grade exam: ");
            foreach (int grade in gradeExam) sb.Append($"{grade} - ");

            return sb.ToString();
        }
    }
}
