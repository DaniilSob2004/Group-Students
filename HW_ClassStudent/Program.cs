using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using HW_Address;


namespace HW_ClassStudent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> arrStud = new List<Student>();
            Random r = new Random();

            // 4 студента
            Student stud = new Student();
            Student stud2 = new Student("Andrey", "Soboliev");
            Student stud3 = new Student("Daniil", "Soboliev",
                                        new DateTime(2004, 3, 25),
                                        new Address("Ukraine", "Odessa", "Dalnya", 24),
                                        "+380688936454");
            Student stud4 = new Student("Anna", "Solovey");

            // добавляем в список 3 студентов
            arrStud.Add(stud);
            arrStud.Add(stud2);
            arrStud.Add(stud3);

            // запоняем рандомно оценками 4 студентов
            for (int i = 0; i < 3; i++) stud.AddGradeCW(r.Next(1, 12));
            for (int i = 0; i < 5; i++) stud.AddGradeHW(r.Next(1, 12));
            for (int i = 0; i < 2; i++) stud.AddGradeExam(r.Next(1, 100));

            for (int i = 0; i < 3; i++) stud2.AddGradeCW(r.Next(1, 12));
            for (int i = 0; i < 4; i++) stud2.AddGradeHW(r.Next(1, 12));
            for (int i = 0; i < 5; i++) stud2.AddGradeExam(r.Next(1, 100));

            for (int i = 0; i < 5; i++) stud3.AddGradeCW(r.Next(1, 12));
            for (int i = 0; i < 5; i++) stud3.AddGradeHW(r.Next(1, 12));
            for (int i = 0; i < 4; i++) stud3.AddGradeExam(r.Next(1, 100));

            for (int i = 0; i < 2; i++) stud4.AddGradeCW(r.Next(1, 12));
            for (int i = 0; i < 5; i++) stud4.AddGradeHW(r.Next(1, 12));
            for (int i = 0; i < 2; i++) stud4.AddGradeExam(r.Next(1, 100));

            // создание группы
            Group group = new Group("P-12", "Programmer", 2, arrStud);

            // вывод сортированных по имени студентов и инфа о группе
            group.ShowSortStudents();

            // добавление студента
            group.AddStudent(stud4);
            group.ShowSortStudents();

            // редактирование данных о студенте
            Student editStud = group.GetStudentByID(2);
            if (editStud != null)
            {
                editStud.SetName("HELLO");
            }
            else
            {
                Console.WriteLine("No such student!");
            }
            group.ShowSortStudents();
            Console.WriteLine("---------------------\n");

            // создание второй группы
            Group group2 = new Group("P-24", "Designer", 3);
            group2.ShowSortStudents();

            // перевод студента из одной группы в другую
            group.StudentTransferToAnotherGroup(3, group2);
            group.ShowSortStudents();
            group2.ShowSortStudents();

            // вывод всей информации о каждом студенте
            group.ShowAllStudInfo();

            // отчисление всех студентов не сдавших экзамены
            group.DelStudentsFromExam();
            group.ShowSortStudents();

            // отчисление одного самого неуспевающего студента
            group.DelBadStudent();
            group.ShowSortStudents();
        }
    }
}
