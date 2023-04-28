using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW_ClassStudent
{
    // класс, для сравнения объектов студентов
    public static class StudentsComparer
    {
        private static void CheckStudentObj(object objLeft, object objRight)
        {
            Student left = objLeft as Student;
            Student right = objRight as Student;

            if (left == null || right == null) throw new ArgumentException("Method parameter must be Student type!");
        }

        public static bool StudentAverageAllGradesComparer(object objLeft, object objRight)
        {
            CheckStudentObj(objLeft, objRight);

            return ((Student)objLeft).AverageAllGrades() > ((Student)objRight).AverageAllGrades();
        }

        public static bool StudentSurnameComparer(object objLeft, object objRight)
        {
            CheckStudentObj(objLeft, objRight);

            if (String.Compare(((Student)objLeft).Surname, ((Student)objRight).Surname) == 1) return true;
            return false;
        }

        public static bool StudentAgeComparer(object objLeft, object objRight)
        {
            CheckStudentObj(objLeft, objRight);

            return ((Student)objLeft).BirthDate > ((Student)objRight).BirthDate;
        }
    }
}
