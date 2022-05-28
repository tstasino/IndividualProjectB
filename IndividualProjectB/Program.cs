using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectB
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 7;
            do
            {
                Console.WriteLine("-------------------Individual Part B--------------------");
                Console.WriteLine("Press 0 to add Courses");
                Console.WriteLine("Press 1 to add Students");
                Console.WriteLine("Press 2 to add Trainers");
                Console.WriteLine("Press 3 to add Assignments");
                Console.WriteLine("Press 4 to add Students per Course");
                Console.WriteLine("Press 5 to add Trainers per Course");
                Console.WriteLine("Press 6 to add Assignments per Student per Course");
                Console.WriteLine("Press 7 to produce various standard queries (subject 6.a.) ");
                Console.WriteLine("Press 8 to exit the program");
                Console.WriteLine("-------------------Individual Part B--------------------");

                choice = int.Parse(Console.ReadLine());

                if (choice == 7)
                {
                    
                    DBService db = new DBService();

                    //print All the Students
                    Console.WriteLine("=====================List of All Students=====================");
                    foreach(var student in db.GetAllStudents())
                    {
                        Console.WriteLine(student);
                    }
                    Console.WriteLine("==============================================================");

                    //print All Trainers
                    Console.WriteLine("=====================List of All Trainers=====================");
                    foreach (var trainer in db.GetAllTrainers())
                    {
                        Console.WriteLine(trainer);
                    }
                    Console.WriteLine("==============================================================");

                    //print All Assignments
                    Console.WriteLine("=====================List of All Assignments=====================");
                    foreach (var assignment in db.GetAllAssignments())
                    {
                        Console.WriteLine(assignment);
                    }
                    Console.WriteLine("==============================================================");

                    //print All Courses
                    Console.WriteLine("=====================List of All Courses======================");
                    foreach (var course in db.GetAllCourses())
                    {
                        Console.WriteLine(course);
                    }
                    Console.WriteLine("==============================================================");

                    //print All Student Per Courses
                    Console.WriteLine("=====================List of All Students Per Courses======================");
                    foreach (var studentPerCourse in db.GetAllStudentsPerCourse())
                    {
                        Console.WriteLine(studentPerCourse);
                    }
                    Console.WriteLine("============================================================================");
                    
                    //print All Trainer Per Courses
                    Console.WriteLine("=====================List of All Trainers Per Courses======================");
                    foreach (var trainerPerCourse in db.GetAllTrainersPerCourse())
                    {
                        Console.WriteLine(trainerPerCourse);
                    }
                    Console.WriteLine("============================================================================");

                    //print All Assignment Per Courses
                    Console.WriteLine("=====================List of All Assingments Per Courses======================");
                    foreach (var assignmentPerCourse in db.GetAllAssignmentsPerCourse())
                    {
                        Console.WriteLine(assignmentPerCourse);
                    }
                    Console.WriteLine("==============================================================================");

                    //print All Assignemtn per Courses Per Student
                    Console.WriteLine("=====================List of All Assingments Per Courses Per Student ======================");
                    foreach (var assignmentPerCoursePerStudent in db.GetAllAssignmentsPerCoursePerStudent())
                    {
                        Console.WriteLine(assignmentPerCoursePerStudent);
                    }
                    Console.WriteLine("============================================================================================");

                    //print All the Students that belong to more than one Courses
                    Console.WriteLine("=====================List of All Students have taken more than One Course=====================");
                    foreach (var student in db.GetAllStudentsThatBelongToMoreThanOneCourses())
                    {
                        Console.WriteLine(student);
                    }
                    Console.WriteLine("===============================================================================================");
                }

            } while (choice != 8);

        }
    }
}
