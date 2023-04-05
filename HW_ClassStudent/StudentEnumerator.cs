using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW_ClassStudent
{
    public class StudentEnumerator : IEnumerator  // реализация интерфейса
    {
        private List<Student> collections;
        private int position;

        public StudentEnumerator(List<Student> students)
        {
            if (students == null) throw new ArgumentException("Argument List<Student> must be not null!");

            collections = students;
            position = -1;
        }

        public object Current
        {
            get
            {
                if (position == -1 || position >= collections.Count) throw new Exception("Failed position!");
                return collections[position];
            }
            private set { }
        }

        public bool MoveNext()
        {
            if (position >= collections.Count - 1)
            {
                return false;
            }
            position++;
            return true;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
