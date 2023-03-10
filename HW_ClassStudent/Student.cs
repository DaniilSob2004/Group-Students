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
            this("", "") { }

        public Student(string name, string surname) : 
            this(name, surname, DateTime.Now, new Address(), "") { }

        public Student(string name, string surname, DateTime birthDate, Address address, string phoneNumber)
        {
            SetName(name);
            SetSurname(surname);
            SetBirthDate(birthDate);
            SetAddress(address);
            SetPhoneNumber(phoneNumber);

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
            this.name = (CheckCorrect.CheckString(name, 2)) ? name : "Student";
        }

        public void SetSurname(string surname)
        {
            this.surname = (CheckCorrect.CheckString(surname, 3)) ? surname : "(empty)";
        }

        public void SetBirthDate(DateTime birthDate)
        {
            if (birthDate != null && ((DateTime.Now.Year - birthDate.Year) >= minYearStud))
            {
                this.birthDate = birthDate;
            }
            else
            {
                this.birthDate = new DateTime(DateTime.Now.Year - minYearStud, 1, 1);
            }
        }

        public void SetAddress(Address address)
        {
            this.address = (address != null) ? address : new Address();
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = (CheckCorrect.CheckPhoneNumber(phoneNumber)) ? phoneNumber : "(empty)";
        }

        public void AddGradeCW(int grade)
        {
            if (CheckCorrect.CheckDigit(grade, 1, 12))
            {
                gradeCW.Add(grade);
            }
        }

        public void AddGradeHW(int grade)
        {
            if (CheckCorrect.CheckDigit(grade, 1, 12))
            {
                gradeHW.Add(grade);
            }
        }

        public void AddGradeExam(int grade)
        {
            if (CheckCorrect.CheckDigit(grade, 1, 100))
            {
                gradeExam.Add(grade);
            }
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
