using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week6_3
{
    internal class Program
    {
        class Student
        {
            public string Name { get; set; }
            public int Grades { get; set; }

            public Student(string name, int grades)
            {
                Name = name;
                Grades = grades;
            }
        }
        //Sorry that if doing this that it's not exactly per instructions, as in for JSON and CSV, I have them capitalized as such. It just makes more sense to me for externsions like those.
        static List<Student> ReadCSV(string fileName)
        {
            List<Student> students = new List<Student>();
            //https://www.c-sharpcorner.com/article/working-with-c-sharp-streamreader/
            /* I don't know how to put it into words, but I struggled a lot with this one. The way my brain works, it loves if else, then, etc kinds of statements.
             * If the code can logically work into a sentence, I understand. But the whole StreamReader stuff, plus the use of all the lists (which were my weakest part, if you remember)
             * led to a lot of confusion and trial and error. I'm glad I did it, as it showed me a bit of how testing code over and over works, but if we have a quiz over this stuff,
             * I will fold. I can understand this and it's logic, but not write my own version of it in anything less than an hour. It's the truth. But hey, I used a try/catch!*/
            try
            {
                //StreamReader reads the CSV file
                using (StreamReader reader = new StreamReader(fileName))
                {
                    //makes the info a string
                    string line;

                    bool isHeader = true;

                    //I set up the boolean because I kept getting errors that the int of grade was a string, which meant it was reading the header instead of the info, so I included it.
                    //I included the header because the instructions only say Name,Grade, and so I included it. Probably would've been easier to remove the header, but too late now.
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (isHeader)
                        {
                            isHeader = false;
                            continue;
                            //moves past header
                        }
                        //separates name stirng and grade int
                        string[] parts = line.Split(',');
                        //sets name stringf and grade int
                        string name = parts[0];
                        int grades = int.Parse(parts[1]);
                        //adds them to new student obj in list
                        students.Add(new Student(name, grades));

                    }
                    return students;
                }
            }
            catch
            {
                //didn't know what to put in the catch, tbh, so VS autocorrected to this.
                return students;
            }
        }
        public static void Main(string[] args)
        {
            //makes a list, calls ReadCSV to read off of students.csv.
            //Maybe I'm mistaken, but it took me a while to also figure out that I had to make the students.csv file in the folder.
            //I could've done it in the code, I think, but that would've been a lot more to do.
            List<Student> studentsList = ReadCSV("students.csv");

            //reads out each student pbject, using the $ sign that I still only sort of get what it does.
            foreach (Student student in studentsList)
            {
                Console.WriteLine($"Name: {student.Name}, Grade: {student.Grades}");
            }
            Console.ReadLine();

            //Overall, I get the topic. I can make something like this, with some time and allowance of research or at least looking at prior code.
            //Without that, I would need more in-depth lessons on the topic to truly understand it at the roots, which won't happen because we're moving through java.
            //Point being, much of this I get logically, but programming it is a different beast, especially with the feeble instructions given.
            //If you need me to explain more, I can TRY. And I'll try my best. If that isn't enough, well...
        }
    }
}
