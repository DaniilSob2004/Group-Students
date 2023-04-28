using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using HW_Address;


namespace HW_ClassStudent
{
    public class Program
    {
        public static void GenStudentsGrades(List<Student> students)
        {
            Random r = new Random();

            // заполняем студентов оценками за дз, классную работу и экзамен
            foreach (Student student in students)
            {
                for (int i = 0; i < 5; i++) student.AddGradeHW(r.Next(1, 12));
                for (int i = 0; i < 5; i++) student.AddGradeCW(r.Next(3, 12));
                for (int i = 0; i < 5; i++) student.AddGradeExam(r.Next(5, 12));
            }
        }

        static void Main()
        {
            // создаём массив из 5 студентов
            List<Student> students = new List<Student>();
            students.Add(new Student("Daniil", "Soboliev", new DateTime(2004, 3, 25)));
            students.Add(new Student("Andrey", "Soboliev", new DateTime(2006, 5, 4)));
            students.Add(new Student("Alex", "Zahoruiko", new DateTime(2007, 10, 27)));
            students.Add(new Student("Anna", "Maliarova", new DateTime(2003, 7, 15)));
            students.Add(new Student("Bob", "Tompson", new DateTime(2007, 9, 1)));
            students.Add(new Student("Tom", "Anderson", new DateTime(2008, 11, 3)));

            // создаём группу и в конструктор передаём список студентов
            Group P12 = new Group(students);

            // заполняем студентов оценками
            GenStudentsGrades(students);


            // ------------------- ЗАПИСЬ СТУДЕНТОВ В ФАЙЛ -------------------
            MyFile.WriteFile<List<Student>>(@"E:\!!!Даня - папка\ListStudents.txt", students);

            // считыаваем из файла
            List<Student> studentsFromFile = MyFile.ReadFile<List<Student>>(@"E:\!!!Даня - папка\ListStudents.txt");

            // выводим каждого студента
            foreach (Student stud in studentsFromFile) Console.WriteLine(stud);



            #region Тестирование
            Console.WriteLine("==============================\n\n");
            // -------------------------------------
            // использование foreach для перебора группы студентов
            /*foreach (Student stud in P12) Console.WriteLine(stud);

            Console.WriteLine("\n\n------------- AFTER SORT GROUP STUDENTS BY AVERAGE ALL GRADES -------------");
            Sort.BubbleSort(P12.Students, StudentsComparer.StudentAverageAllGradesComparer);
            foreach (Student stud in P12) Console.WriteLine(stud);

            Console.WriteLine("\n\n------------- AFTER SORT GROUP STUDENTS BY SURNAME -------------");
            Sort.SelectionSort(P12.Students, StudentsComparer.StudentSurnameComparer);
            foreach (Student stud in P12) Console.WriteLine(stud);

            Console.WriteLine("\n\n------------- AFTER SORT GROUP STUDENTS BY AGE -------------");
            Sort.InsertionSort(P12.Students, StudentsComparer.StudentAgeComparer);
            foreach (Student stud in P12) Console.WriteLine(stud);*/


            // печатаем сиртификаты студентов
            //Console.WriteLine("\n--------------- Certificates ---------------");
            //foreach (Student stud in P12) Certificate.PrintCertificate(stud);

            // сортируем студентов группы по имени
            /*Console.WriteLine("\n\n------------- AFTER SORT STUDENT BY NAME -------------");
            P12.Students.Sort(new NameStudentComparer());  // используем класс 'сравнитель'

            // использование foreach для перебора группы студентов
            foreach (Student stud in P12) Console.WriteLine(stud);*/

            // сортируем студентов группы по средней оценки за ДЗ
            /*Console.WriteLine("\n\n------------- AFTER SORT STUDENT BY AVERAGE GRADE HW -------------");
            P12.Students.Sort(new GradeHWStudentComparer());  // используем класс 'сравнитель'

            // использование foreach для перебора группы студентов
            foreach (Student stud in P12) Console.WriteLine(stud);*/



            /*Console.WriteLine("\n==============================\n\n");
            // -------------------------------------
            // использование студентов и группы


            List<Student> arrStud = new List<Student>();

            // 4 студента
            Student stud = new Student();
            Student stud2 = new Student("Andrey", "Soboliev");
            Student stud3;

            try
            {
                stud3 = new Student("Daniil", "Soboliev",
                                        new DateTime(2020, 5, 14),  // ошибка в dateTime, при попытке передачи не правильного возраста(даты)
                                        new Address(),
                                        "+380688936454");
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message + "\n");
            }
            finally
            {
                stud3 = new Student("Daniil", "Soboliev",
                                        new DateTime(2004, 3, 25),  // исправили ошибку
                                        new Address(),
                                        "+380688936454");
            }

            // создаём аспиранта
            Aspirant stud4 = new Aspirant("Anna", "Solovey", "master's");

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
            Console.WriteLine("\nAdd student:");
            Student testStud = null;
            try
            {
                group.AddStudent(testStud);  // ошибка, передаём null
            }
            catch (NullReferenceException er)
            {
                Console.WriteLine(er.Message + "\n");
            }
            finally
            {
                group.AddStudent(stud4);
            }
            group.ShowSortStudents();


            // редактирование данных о студенте
            Console.WriteLine("\nEdit name student:");
            try
            {
                group[2].Name = "HELLO";
            }
            catch (Exception)  // если студент не найден (вернуло null)
            {
                Console.WriteLine("No such student!\n");
            } 
            group.ShowSortStudents();


            // создание второй группы
            Console.WriteLine("\nCreate new group:");
            Group group2 = new Group("P-24", "Designer", 3);
            group2.ShowSortStudents();


            // перевод студента из одной группы в другую
            Console.WriteLine("\nStudent transfer to another group:");
            try
            {
                group.StudentTransferToAnotherGroup(3, group2);
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message + "\n");
            }
            group.ShowSortStudents();
            group2.ShowSortStudents();


            // вывод всей информации о каждом студенте
            Console.WriteLine("\nShow all student info(group1):");
            group.ShowAllStudInfo();

            Console.WriteLine("Show all student info(group2):");
            group2.ShowAllStudInfo();


            // отчисление всех студентов не сдавших экзамены
            //Console.WriteLine("Expulsion of all students who did not pass the exams:");
            //group.DelStudentsFromExam();
            //group.ShowSortStudents();


            // отчисление одного самого неуспевающего студента
            //Console.WriteLine("Expulsion of one of the most underachieving students:");
            //group.DelBadStudent();
            //group.ShowSortStudents();


            // проерка на равенство студентов
            Console.WriteLine("Student equality test:");
            try
            {
                if (group[2] == group[1])
                {
                    Console.WriteLine("student with id 2 == student with id 1");
                }
                else
                {
                    Console.WriteLine("student with id 2 != student with id 1");
                }
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }


            // проерка на равенство групп
            Console.WriteLine("\nGroup equality test:");
            if (group == group2)
            {
                Console.WriteLine($"{group.Title} == {group2.Title}");
            }
            else
            {
                Console.WriteLine($"{group.Title} != {group2.Title}");
            }


            // использование индексатора (по id студента, возвращается студент)
            Console.WriteLine("\nIndexer usage(id):");
            try
            {
                Console.WriteLine(group[2]);
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }


            // использование индексатора (по имени, возвращается список студентов)
            Console.WriteLine("\nIndexer usage(name):");
            try
            {
                // перебираем список и выводим инфу
                foreach (var s in group["Daniil"])
                {
                    Console.WriteLine(s);
                }
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }
            Console.WriteLine();*/
            #endregion
        }
    }
}
