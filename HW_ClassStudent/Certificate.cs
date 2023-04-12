using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_ClassStudent
{
    public static class Certificate
    {
        enum TypeGrade { Bad, Satisfactory = 7, Good = 10, Excellent = 12 };

        public static void PrintCertificate(Student stud)
        {
            // средняя оценка по Классной работе, ДЗ и Экзаменам
            float averageGrade = stud.AverageAllGrades();

            Console.WriteLine($"\n\t\tCertificate");
            Console.WriteLine($"Name: {stud.Name}");
            Console.WriteLine($"Surname: {stud.Surname}");

            if (averageGrade == (int)TypeGrade.Excellent)
            {
                Console.WriteLine($"Graduated kurs with: {TypeGrade.Excellent}");
            }
            else if (averageGrade >= (int)TypeGrade.Good)
            {
                Console.WriteLine($"Graduated kurs with: {TypeGrade.Good}");
            }
            else if (averageGrade >= (int)TypeGrade.Satisfactory)
            {
                Console.WriteLine($"Graduated kurs with: {TypeGrade.Satisfactory}");
            }
            else
            {
                Console.WriteLine("No certificate, the student did not study well!");
            }
        }
    }
}
