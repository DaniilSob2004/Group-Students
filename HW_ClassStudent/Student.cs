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
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            Address = address;
            PhoneNumber = phoneNumber;

            gradeCW = new List<int>();
            gradeHW = new List<int>();
            gradeExam = new List<int>();

            id += ++ID;  // id студента
        }


        // Свойства
        public int Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (!CheckCorrect.CheckString(value, 2))
                {
                    throw new Exception("Name student must be >= 2 symbols!");
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
                    throw new Exception("Surname student must be >= 3 symbols!");
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
                    throw new NullReferenceException("Reference DateTime must be not null!");
                }

                // DateTime.Now.Year - значение по умолчанию (если вызывается конструктор по умолчанию)
                else if (value.Year != DateTime.Now.Year)
                {
                    if ((DateTime.Now.Year - value.Year) < minYearStud)
                    {
                        throw new Exception($"The student must be over {minYearStud} years of age!");
                    }
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
                if (value != "empty")
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

        public override bool Equals(object obj)
        {
            // проверяем что за тип
            Student stud = obj as Student;

            if (stud == null)
            {
                return false;
            }

            // сравнивает по средней оценки по экзаменам
            return (AverageGradeExam() == stud.AverageGradeExam());
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Student stud, Student stud2)
        {
            // если stud и stud2 its null reference
            if (ReferenceEquals(stud, stud2))
            {
                return true;
            }

            if ((object)stud != null)
            {
                return stud.Equals(stud2);
            }

            if ((object)stud2 != null)
            {
                return stud2.Equals(stud);
            }

            return false;
        }

        public static bool operator!=(Student stud, Student stud2)
        {
            return !(stud == stud2);
        }
    }
}
