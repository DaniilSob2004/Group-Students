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
            Student stud = new Student();
            Console.WriteLine(stud + "\n\n");

            Student stud2 = new Student("Andrey", "Soboliev");
            Console.WriteLine(stud2 + "\n\n");


            Random r = new Random();
            Student stud3 = new Student("Daniil", "Soboliev",
                                        new DateTime(2004, 3, 25),
                                        new Address("Ukraine", "Odessa", "Dalnya", 24),
                                        "+380688936454");

            for (int i = 0; i < 3; i++) stud3.AddGradeCW(r.Next(1, 12));
            for (int i = 0; i < 5; i++) stud3.AddGradeHW(r.Next(1, 12));
            for (int i = 0; i < 2; i++) stud3.AddGradeExam(r.Next(1, 100));

            Console.WriteLine(stud3 + "\n");
            Console.WriteLine($"NAME: {stud3.GetName()}\n");
        }
    }
}
