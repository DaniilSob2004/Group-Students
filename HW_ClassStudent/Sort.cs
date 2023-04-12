using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW_ClassStudent
{
    public static class Sort
    {
        public delegate bool DelComparer(object obj1, object obj2);

        private static void Swap(List<Student> students, int i1, int i2)
        {
            Student stud = students[i1];
            students[i1] = students[i2];
            students[i2] = stud;
        }

        // Сортировка пузырьком
        public static void BubbleSort(List<Student> students, DelComparer comparer)
        {
            for (int i = 1; i < students.Count; i++)
            {
                for (int j = 0; j < students.Count - i; j++)
                {
                    // вызов метода через декоратор
                    if (comparer(students[j], students[j + 1]))
                    {
                        // меняет местами элементы
                        Swap(students, j, j + 1);
                    }
                }
            }
        }

        // Сортировка выбором
        public static void SelectionSort(List<Student> students, DelComparer comparer)
        {
            int indMin;

            for (int i = 0; i < students.Count - 1; i++)
            {
                indMin = i;
                for (int j = i + 1; j < students.Count; j++)
                {
                    // вызов метода через декоратор
                    if (comparer(students[indMin], students[j]))
                    {
                        indMin = j;
                    }
                }
                if (indMin != i)
                {
                    // меняет местами элементы
                    Swap(students, indMin, i);
                }
            }
        }

        // Сортировка вставками
        public static void InsertionSort(List<Student> students, DelComparer comparer)
        {
            for (int i = 1; i < students.Count; i++)
            {
                // вызов метода через декоратор
                for (int j = i; j > 0 && comparer(students[j - 1], students[j]); j--)
                {
                    // меняет местами элементы
                    Swap(students, j - 1, j);
                }
            }
        }
    }
}
