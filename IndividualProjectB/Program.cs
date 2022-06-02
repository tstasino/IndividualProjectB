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
                Console.WriteLine("Press 6 to add Assignments per Course Per Student");
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
                else if (choice == 0)
                {
                    int epilogh = 0;

                    do
                    {
                        Course course = new Course();
                        try
                        {
                           
                            Console.WriteLine("Give the Course Title");
                            course.Title = Console.ReadLine();
                            Console.WriteLine("Give the Course Stream");
                            course.Stream = Console.ReadLine();
                            Console.WriteLine("Give the Course Type");
                            course.Type = Console.ReadLine();
                            Console.WriteLine("Give the Start Date (yyyy-mm-dd)");
                            course.Start_Date = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Give the End Date (yyyy-mm-dd)");
                            course.End_Date = DateTime.Parse(Console.ReadLine());
                        } catch(Exception ex)
                        {
                            Console.WriteLine($"Input Exception: {ex.Message}");
                        }

                        //add to database
                        DBService db = new DBService();
                        db.CreateCourse(course);

                        Console.WriteLine("Add another Course? Press 1  for yes or 0 for no");
                        epilogh = int.Parse(Console.ReadLine());
                    } while (epilogh != 0);
                }
                else if (choice == 1)
                {
                    int epilogh = 0;

                    do
                    {
                        Student student = new Student();
                        try 
                        { 
                            Console.WriteLine("Give the Student First Name");
                            student.FirstName = Console.ReadLine();
                            Console.WriteLine("Give the Student Last Name");
                            student.LastName = Console.ReadLine();
                            Console.WriteLine("Give the Date Of Birth (yyyy-mm-dd)");
                            student.DateOfBirth = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Give the Tuition Fees");
                            student.TuitionFees = double.Parse(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Input Exception: {ex.Message}");
                        }

                        //insert into the database
                        DBService db = new DBService();
                        db.CreateStudent(student);
    
                        Console.WriteLine("Add another Student? Press 1  for yes or 0 for no");
                        epilogh = int.Parse(Console.ReadLine());
                    } while (epilogh != 0);
                }
                else if (choice == 2)
                {
                    int epilogh = 0;

                    do
                    {
                        Trainer trainer = new Trainer();
                        try 
                        { 
                            Console.WriteLine("Give the Trainer First Name");
                            trainer.FirstName = Console.ReadLine();
                            Console.WriteLine("Give the Trainer Last Name");
                            trainer.LastName = Console.ReadLine();
                            Console.WriteLine("Give the Trainer's subject");
                            trainer.Subject = Console.ReadLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Input Exception: {ex.Message}");
                        }

                        //add to database
                        DBService dB = new DBService();
                        dB.CreateTrainer(trainer);
                        
                        Console.WriteLine("Add another Trainer? Press 1  for yes or 0 for no");
                        epilogh = int.Parse(Console.ReadLine());
                    } while (epilogh != 0);
                }
                else if (choice == 3)
                {
                    int epilogh = 0;

                    do
                    {
                        Assignment assignment = new Assignment();

                        try
                        {
                            //Console.WriteLine("Give the Assignment Title");
                            //assignment.Title = Console.ReadLine();
                            Console.WriteLine("Give the Assignment Description");
                            assignment.Description = Console.ReadLine();
                            Console.WriteLine("Give the Submission Date (yyyy-mm-dd)");
                            assignment.SubDateTime = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Give the Oral Mark");
                            assignment.OralMark = int.Parse(Console.ReadLine());
                            Console.WriteLine("Give the Total Mark");
                            assignment.TotalMark = int.Parse(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Input Exception: {ex.Message}");
                        }

                        //add to database
                        DBService db = new DBService();
                        db.CreateAssignment(assignment);

                        Console.WriteLine("Add another Assignment? Press 1  for yes or 0 for no");
                        epilogh = int.Parse(Console.ReadLine());
                    } while (epilogh != 0);
                }
                else if (choice == 4)
                {
                    int epilogh = 0;

                    do
                    {
                        StudentPerCourse studentPerCourse = new StudentPerCourse();
                        try
                        { 
                            Console.WriteLine("Connect an existing Student with an existing Course");
                            Console.WriteLine("Give the Student First Name");
                            studentPerCourse.FirstName = Console.ReadLine();
                            Console.WriteLine("Give the Student Last Name");
                            studentPerCourse.LastName = Console.ReadLine();
                            Console.WriteLine("Give the Course Title");
                            studentPerCourse.Title = Console.ReadLine();
                            Console.WriteLine("Give the Course Type (Part Time or Full Time)");
                            studentPerCourse.Type = Console.ReadLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Input Exception: {ex.Message}");
                        }

                        //add to database
                        DBService db = new DBService();
                        db.StudentsPerCourseConnection(studentPerCourse);

                        Console.WriteLine("Add another connection between Course and Student? Press 1  for yes or 0 for no");
                        epilogh = int.Parse(Console.ReadLine());
                    } while (epilogh != 0);
                }
                else if (choice == 5)
                {
                    int epilogh = 0;

                    do
                    {
                        TrainerPerCourse trainersPerCourse = new TrainerPerCourse();
                        try
                        { 
                            Console.WriteLine("Connect an existing Trainer with an existing Course");
                            Console.WriteLine("Give the Trainer First Name");
                            trainersPerCourse.FirstName = Console.ReadLine();
                            Console.WriteLine("Give the Trainer Last Name");
                            trainersPerCourse.LastName = Console.ReadLine();
                            Console.WriteLine("Give the Course Title");
                            trainersPerCourse.Title = Console.ReadLine();
                            Console.WriteLine("Give the Course Type (Part Time or Full Time)");
                            trainersPerCourse.Type = Console.ReadLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Input Exception: {ex.Message}");
                        }

                        // add to database
                        DBService db = new DBService();
                        db.TrainersPerCourseConnection(trainersPerCourse);     
    
                        Console.WriteLine("Add another connection between Course and Trainer? Press 1  for yes or 0 for no");
                        epilogh = int.Parse(Console.ReadLine());
                    } while (epilogh != 0);
                }
                else if (choice == 6)
                {
                    int epilogh = 0;

                    do
                    {
                        AssignmentPerCoursePerStudent assignmentsPerCoursePerStudent = new AssignmentPerCoursePerStudent();
                        try
                        { 
                            Console.WriteLine("Connect an existing Assignment with an existing Course and a Student");
                            Console.WriteLine("Give the Course Title");
                            assignmentsPerCoursePerStudent.Title = Console.ReadLine();                      
                            Console.WriteLine("Give the Course Type (Part Time / Full Time)");
                            assignmentsPerCoursePerStudent.Type = Console.ReadLine();
                            Console.WriteLine("Give the Assignment ID");
                            assignmentsPerCoursePerStudent.AssignmentId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Give the Student First Name");
                            assignmentsPerCoursePerStudent.FirstName = Console.ReadLine();
                            Console.WriteLine("Give the Student Last Name");
                            assignmentsPerCoursePerStudent.LastName = Console.ReadLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Input Exception: {ex.Message}");
                        }

                        DBService db = new DBService();
                        db.AssignmentPerCoursePerStudentConnection(assignmentsPerCoursePerStudent);
                        
                        Console.WriteLine("Add another connection between Assignment, Course and Student? Press 1  for yes or 0 for no");
                        epilogh = int.Parse(Console.ReadLine());
                    } while (epilogh != 0);
                }

            } while (choice != 8);

        }
    }
}
