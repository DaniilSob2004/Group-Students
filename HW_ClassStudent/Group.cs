using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_Address;


namespace HW_ClassStudent
{
    public class Group
    {
        public const int GEN_STUDENTS = 5;
        public const int MIN_GRADE_EXAM = 40;

        private List<Student> students = new List<Student>();
        private string title;
        private string specialization;
        private int numKurs;

        // случайная генерация студентов с помощью библиотеки 'Faker'
        private void GenStudents()
        {
            for (int i = 0; i < GEN_STUDENTS; i++)
            {
                Address address = new Address();
                students.Add(new Student(Faker.NameFaker.Name(),
                                         Faker.NameFaker.LastName(),
                                         new DateTime(),
                                         address,
                                         Faker.PhoneFaker.Phone()));
            }
        }

        // копия студентов из другого списка в наш список
        private void CopyStudents(List<Student> students)
        {
            if (students != null)
            {
                foreach (Student stud in students)
                {
                    this.students.Add(stud);
                }
            }
        }

        // принимает массив string и заполняет его (имя+фамилия+ID) каждого студента
        private void GetStudentNames(string[] arrNames)
        {
            for (int i = 0; i < students.Count; i++)
            {
                arrNames[i] = students[i].Name + " " + students[i].Surname + ", ID(" + students[i].Id + ")";
            }
        }

        // удаление студента
        private void DelStudent(Student stud)
        {
            if (stud != null)
            {
                students.Remove(stud);
            }
        }

        private List<Student> GetStudentsByName(string name)
        {
            List<Student> listStud = new List<Student>();

            foreach (var stud in students)
            {
                if (stud.Name == name)
                {
                    listStud.Add(stud);
                }
            }

            return listStud;
        }

        // -----

        // конструктор ддл параметров группы
        public Group(string title, string specialization, int numKurs)
        {
            Title = title;
            Specialization = specialization;
            NumKurs = numKurs;
        }

        // конструктор по умолчаниюи генерация студентов
        public Group() : this("TitleGroup", "Specialization", 1)
        {
            GenStudents();
        }

        // конструктор для существующего списка студентов
        public Group(List<Student> students) : this("TitleGroup", "Specialization", 1, students) {}

        // конструктор для существующей группы
        public Group(Group group) :
            this(group.Title, group.Specialization, group.NumKurs, group.Students) {}

        // конструктор для существующего списка студентов и доп параметров для группы
        public Group(string title, string specialization, int numKurs, List<Student> students):
            this(title, specialization, numKurs)
        {
            CopyStudents(students);
        }


        public string Title
        {
            get { return title; }
            set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Group title must be >= 2 symbols!");
                }
                title = value;
            }
        }

        public string Specialization
        {
            get { return specialization; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Group specialization must be >= 3 symbols!");
                }
                specialization = value;
            }
        }

        public int NumKurs
        {
            get { return numKurs; }
            set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException("Group numKurs must be from 1 to 10 value!");
                }
                numKurs = value;
            }
        }

        public List<Student> Students
        {
            get { return students; }
        }


        public void ShowGroupInfo()
        {
            Console.WriteLine($"Title group: {title}");
            Console.WriteLine($"Specialization group: {specialization}");
            Console.WriteLine($"Kurs number: {numKurs}");
        }

        public void ShowSortStudents()
        {
            string[] arrNames = new string[students.Count];
            GetStudentNames(arrNames);
            Array.Sort(arrNames);

            ShowGroupInfo();
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {arrNames[i]}");
            }
            Console.WriteLine();
        }

        public void ShowAllStudInfo()
        {
            foreach (Student stud in students)
            {
                Console.WriteLine(stud);
            }
            Console.WriteLine();
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new NullReferenceException("Student reference must be not null!");
            }

            // если студент которого добавляем есть в списке студентов, то не добавляем (узнаём по ID)
            foreach (Student stud in students)
            {
                if (stud.Id == student.Id)
                {
                    return;
                }
            }
            students.Add(student);
        }

        public Student GetStudentByID(int id)
        {
            foreach (Student stud in students)
            {
                if (stud.Id == id)
                {
                    return stud;
                }
            }
            throw new Exception($"Student with this id - {id} was not found!");
        }

        public void StudentTransferToAnotherGroup(int id, Group newGroup)
        {
            if (newGroup == null)
            {
                throw new NullReferenceException("Group reference must be not null!");
            }
            try
            {
                Student stud = GetStudentByID(id);
                newGroup.AddStudent(stud);
                DelStudent(stud);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DelStudentsFromExam()
        {
            List<Student> delStudents = new List<Student>();
            foreach (Student stud in students)
            {
                // находим студентов которые провалили экзамены и добавляем в список для дальнейшего удаления
                if (stud.AverageGradeExam() < MIN_GRADE_EXAM)
                {
                    delStudents.Add(stud);
                }
            }
            foreach (Student stud in delStudents)
            {
                DelStudent(stud);
            }
        }

        public void DelBadStudent()
        {
            if (students.Count > 0)
            {
                Student badStud = students[0];
                float result = (badStud.AverageGradeCW() + badStud.AverageGradeHW() + badStud.AverageGradeExam()) / 3;
                float result2 = 0;
                for (int i = 1; i < students.Count; i++)
                {
                    result2 = (students[i].AverageGradeCW() + students[i].AverageGradeHW() + students[i].AverageGradeExam()) / 3;
                    if (result2 < result)
                    {
                        result = result2;
                        badStud = students[i];
                    }
                }
                DelStudent(badStud);
            }
        }


        public override bool Equals(object obj)
        {
            // проверяем что за тип
            Group group = obj as Group;

            if (group == null)
            {
                return false;
            }

            // сравнивает по кол-ву студентов
            return students.Count == group.Students.Count;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Group group, Group group2)
        {
            // если group и group2 its null reference
            if (ReferenceEquals(group, group2))
            {
                return true;
            }

            if ((object)group != null)
            {
                return group.Equals(group2);
            }

            if ((object)group2 != null)
            {
                return group2.Equals(group);
            }

            return false;
        }

        public static bool operator !=(Group group, Group group2)
        {
            return !(group == group2);
        }

        public Student this[int id]
        {
            get
            {
                return GetStudentByID(id);
            }
        }

        public List<Student> this[string name]
        {
            get
            {
                List<Student> listStud = GetStudentsByName(name);

                if (listStud.Count == 0) throw new Exception("Error, no students by this name!");
                return listStud;
            }
        }
    } 
}
