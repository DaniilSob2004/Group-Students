using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_Address;
using CorrectInput;


namespace HW_ClassStudent
{
    public class Student : Person, IComparable
    {
        private int id;
        private List<int> gradeCW;
        private List<int> gradeHW;
        private List<int> gradeExam;

        private static int minYearStud = 14;
        private static int ID = 0;
        
        public Student() :
            this("Name", "Surname") { }

        public Student(string name, string surname) : 
            this(name, surname, new DateTime(), new Address()) { }

        public Student(string name, string surname, DateTime birthDate, Address address, string phoneNumber = "") :
            base(name, surname, birthDate, address, phoneNumber)
        {
            BirthDate = birthDate;  // для повторной проверки

            gradeCW = new List<int>();
            gradeHW = new List<int>();
            gradeExam = new List<int>();

            id += ++ID;  // id студента
        }


        // Свойство
        public int Id
        {
            get { return id; }
        }

        public DateTime BirthDate
        {
            get { return base.BirthDate; }
            set
            {
                // если НЕ пустая дата(new DateTime()), то значит это НЕ значение по умолчанию
                if (value != new DateTime())
                {
                    if (!CheckCorrect.CheckBirthYear(value.Year))
                    {
                        throw new Exception($"The student must be over {minYearStud} years of age!");
                    }
                }

                // если это пустая дата, то значит это значение по умолчанию, и отнимаем от нашего года - 14(минимальный возраст)
                else
                {
                    base.BirthDate = new DateTime(DateTime.Now.Year - minYearStud, DateTime.Now.Month, DateTime.Now.Day);
                }

                // если дата доп. проверку прошла, то ничего не делаем, т.к. в базавом классе это значение уже установилось
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


        public int CompareTo(object obj)  // реализация интерфейса
        {
            // проверяем тип объекта который передали в параметр
            Student stud = obj as Student;
            if (stud == null) throw new Exception("Reference obj is not a Student!");

            // сравниваем студентов по средней оценки за ДЗ
            if (AverageGradeHW() < stud.AverageGradeHW()) return -1;
            if (AverageGradeHW() > stud.AverageGradeHW()) return 1;
            return 0;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\n---------- Student Info ---------\n");
            sb.Append($"ID: {id}\n");

            sb.Append(base.ToString());

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
