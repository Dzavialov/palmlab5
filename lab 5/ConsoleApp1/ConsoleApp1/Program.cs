using System;
using System.IO;
using System.Runtime.Remoting;
using struct_lab_student;

namespace Lab5
{
    class Program
    {
        static Student[] ReadData(string fileName)
        {
            // TODO   implement this method.
            // It should read the file whose fileName has been passed and fill 

            string path = "C:\\Users\\dimaz\\Desktop\\";
            string newPath = path.Insert(path.Length, fileName);
            int count = System.IO.File.ReadAllLines(newPath).Length;
            Student[] students = new Student[count];
            var stream = File.Open(newPath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(stream, System.Text.Encoding.Default);
            for (int i = 0; i < count; i++)
            {
                var str = sr.ReadLine();
                Student student = new Student(str);
                students[i] = student;
            }

            return students;

        }

        static void runMenu(Student[] studs)
        {
            for (int i = 0; i < studs.Length; i++)
            {
                string physicsMark = Convert.ToString(studs[i].physicsMark);
                int number = Convert.ToInt32(physicsMark);

                if(studs[i].physicsMark == '-')
                {
                    studs[i].physicsMark = '2';

                }
                if (studs[i].informaticsMark == '-')
                {
                    studs[i].informaticsMark = '2';

                }
                if (studs[i].mathematicsMark == '-')
                {
                    studs[i].mathematicsMark = '2';
                }

                string avarageStrMath = Convert.ToString(studs[i].mathematicsMark);
                string avarageStrInf = Convert.ToString(studs[i].informaticsMark);
                string avarageStrPhys = Convert.ToString(studs[i].physicsMark);

                double avarage = (Convert.ToDouble(avarageStrMath) + Convert.ToDouble(avarageStrInf) + Convert.ToDouble(avarageStrPhys))/3;

                if (number == 5)
                {
                    Console.WriteLine(studs[i].surName + " " + studs[i].firstName + " " + studs[i].patronymic + " " + studs[i].scholarship);
                    Console.WriteLine("Avarage score = " + Math.Round(avarage, 1));
                    Console.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            Student[] studs = ReadData("input.txt");
            runMenu(studs);
        }

    }
}
