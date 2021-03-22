using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_Student
{
    class Program
    {
        static void Main(string[] args)
        {
            //Student
            Student s0 = new Student("Dip", "111", 3.0F);
            Student s1 = new Student("Dip Roy", "112", 3.41F);
            Student s2 = new Student("Dip Roy", "113", 3.23F);
            Student s3 = new Student("Dip Roy", "114", 3.55F);
            Student s4 = new Student("Dip Roy", "115", 3.45F);
            Student s5 = new Student("Dip Roy", "116", 3.22F);
            Student s6 = new Student("Dip Roy", "117", 3.67F);


            //Course

            Course c1 = new Course("CSC101", "CADD");
            Course c2 = new Course("CSC102", "TOC");
            Course c3 = new Course("CSC103", "OS");


            //method calling
            c1.AddStudent(s1, s3, s4, s5, s6);

            c1.PrintStudent();

            c1.RemoveStudent(s5);

            Console.WriteLine("\nAfter Remove Student..................\n");

            s5.PrintCourse();
            c1.PrintStudent();

            Console.WriteLine("\n.............................\n");

            s2.AddCourse(c1, c2, c3);
            s2.PrintCourse();

            s2.RemoveCourse(c2);
            Console.WriteLine("\nAfter Remove Course..................\n");
            s2.PrintCourse();
            c2.PrintStudent();
        }
    }
}
