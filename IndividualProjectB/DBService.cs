using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace IndividualProjectB
{
    class DBService
    {
        private readonly static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        private void Template()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Sql exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Students", conn);
                    SqlDataReader studentReader = cmd.ExecuteReader();
                    while (studentReader.Read())
                    {
                        Student student = new Student()
                        {
                            FirstName = (string)studentReader["FirstName"],
                            LastName = (string)studentReader["LastName"],
                            DateOfBirth = (DateTime)studentReader["dateOfBirth"],
                            TuitionFees = (int)studentReader["tuitionFees"]
                        };
                        students.Add(student);
                    }
                    studentReader.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Sql exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }
            return students;
        }

        public List<Trainer> GetAllTrainers()
        {
            List<Trainer> trainers = new List<Trainer>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Trainers", conn);
                    SqlDataReader trainerReader = cmd.ExecuteReader();
                    while (trainerReader.Read())
                    {
                        Trainer trainer = new Trainer()
                        {
                            FirstName = (string)trainerReader["FirstName"],
                            LastName = (string)trainerReader["LastName"],
                            Subject = (string) trainerReader["subject"]
                          
                        };
                        trainers.Add(trainer);
                    }
                    trainerReader.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Sql exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }
            return trainers;
        }

        public List<Assignment> GetAllAssignments()
        {
            List<Assignment> assignments = new List<Assignment>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Assignments", conn);
                    SqlDataReader assignmentReader = cmd.ExecuteReader();
                    while (assignmentReader.Read())
                    {
                        Assignment assignment = new Assignment();

                        assignment.Description = (string)assignmentReader["description"];
                        assignment.SubDateTime = (DateTime)assignmentReader["subDateTime"];
                        assignment.OralMark = (int)assignmentReader["oralMark"];
                        assignment.TotalMark = (int)assignmentReader["totalMark"];

                        
                        assignments.Add(assignment);
                    }
                    assignmentReader.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Sql exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }
            return assignments;
        }

        public List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Courses", conn);
                    SqlDataReader coursesReader = cmd.ExecuteReader();
                    while (coursesReader.Read())
                    {
                        Course course = new Course();

                        course.Title = (string)coursesReader["title"];
                        course.Stream = (string)coursesReader["stream"];
                        course.Type = (string)coursesReader["type"];
                        course.Start_Date = (DateTime)coursesReader["startDate"];
                        course.End_Date = (DateTime)coursesReader["endDate"];


                        courses.Add(course);
                    }
                    coursesReader.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Sql exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }
            return courses;
        }

        public List<StudentPerCourse> GetAllStudentsPerCourse()
        {
            List<StudentPerCourse> studentPerCourses = new List<StudentPerCourse>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();

                    string queryString = "select s.firstName, s.lastName, c.title, c.type from Students s " +
                                        "inner join studentsPerCourse " +
                                        "on studentsPerCourse.studentId = s.studentId " +
                                        "inner join Courses c " +
                                        "on c.courseId = studentsPerCourse.courseId";

                    SqlCommand cmd = new SqlCommand(queryString, conn);
                    SqlDataReader studentPerCoursesReader = cmd.ExecuteReader();
                    while (studentPerCoursesReader.Read())
                    {
                        StudentPerCourse studentPerCourse = new StudentPerCourse();

                        studentPerCourse.FirstName = (string)studentPerCoursesReader["firstName"];
                        studentPerCourse.LastName = (string)studentPerCoursesReader["lastName"];
                        studentPerCourse.Title = (string)studentPerCoursesReader["title"];
                        studentPerCourse.Type = (string)studentPerCoursesReader["type"];

                        studentPerCourses.Add(studentPerCourse);
                    }
                    studentPerCoursesReader.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Sql exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }
            return studentPerCourses;
        }

        public List<TrainerPerCourse> GetAllTrainersPerCourse()
        {
            List<TrainerPerCourse> trainerPerCourses = new List<TrainerPerCourse>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();

                    string queryString = "select t.firstName, t.lastName, c.title, c.type from Trainers t " +
                                        "inner join trainersPerCourse " +
                                        "on trainersPerCourse.trainerId = t.trainerId " +
                                        "inner join Courses c " +
                                        "on c.courseId = trainersPerCourse.courseId";

                    SqlCommand cmd = new SqlCommand(queryString, conn);
                    SqlDataReader trainerPerCoursesReader = cmd.ExecuteReader();
                    while (trainerPerCoursesReader.Read())
                    {
                        TrainerPerCourse trainerPerCourse = new TrainerPerCourse();

                        trainerPerCourse.FirstName = (string)trainerPerCoursesReader["firstName"];
                        trainerPerCourse.LastName = (string)trainerPerCoursesReader["lastName"];
                        trainerPerCourse.Title = (string)trainerPerCoursesReader["title"];
                        trainerPerCourse.Type = (string)trainerPerCoursesReader["type"];

                        trainerPerCourses.Add(trainerPerCourse);
                    }
                    trainerPerCoursesReader.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Sql exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }
            return trainerPerCourses;
        }

        public List<AssignmentPerCourse> GetAllAssignmentsPerCourse()
        {
            List<AssignmentPerCourse> assignmentPerCourses = new List<AssignmentPerCourse>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();

                    string queryString = "select a.description, c.title, c.type  from Assignments a " +
                                        "inner join assignmentsPerCourse " +
                                        "on assignmentsPerCourse.assignmentId = a.assignmentId " +
                                        "inner join Courses c " +
                                        "on c.courseId = assignmentsPerCourse.courseId";

                    SqlCommand cmd = new SqlCommand(queryString, conn);
                    SqlDataReader assignmentPerCoursesReader = cmd.ExecuteReader();
                    while (assignmentPerCoursesReader.Read())
                    {
                        AssignmentPerCourse assignmentPerCourse = new AssignmentPerCourse();

                        assignmentPerCourse.Description = (string)assignmentPerCoursesReader["description"];
                        assignmentPerCourse.Title = (string)assignmentPerCoursesReader["title"];
                        assignmentPerCourse.Type = (string)assignmentPerCoursesReader["type"];

                        assignmentPerCourses.Add(assignmentPerCourse);
                    }
                    assignmentPerCoursesReader.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Sql exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }
            return assignmentPerCourses;
        }

        public List<AssignmentPerCoursePerStudent> GetAllAssignmentsPerCoursePerStudent()
        {
            List<AssignmentPerCoursePerStudent> assignmentPerCoursePerStudent = new List<AssignmentPerCoursePerStudent>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();

                    string queryString = "select s.firstName, s.lastName, a.description, c.title,c.stream,c.type from Assignments a " +
                                        "inner join assignmentsPerStudentPerCourse " +
                                        "on assignmentsPerStudentPerCourse.assignmentId = a.assignmentId " +
                                        "inner join Courses c " +
                                        "on c.courseId = assignmentsPerStudentPerCourse.courseId " +
                                        "inner join Students s " +
                                        "on s.studentId = assignmentsPerStudentPerCourse.studentId";

                    SqlCommand cmd = new SqlCommand(queryString, conn);
                    SqlDataReader assignmentPerCoursePerStudentReader = cmd.ExecuteReader();
                    while (assignmentPerCoursePerStudentReader.Read())
                    {
                        AssignmentPerCoursePerStudent assignmentPerCoursesPerStudent = new AssignmentPerCoursePerStudent();

                        assignmentPerCoursesPerStudent.FirstName = (string)assignmentPerCoursePerStudentReader["firstName"];
                        assignmentPerCoursesPerStudent.LastName = (string)assignmentPerCoursePerStudentReader["lastName"];
                        assignmentPerCoursesPerStudent.Description = (string)assignmentPerCoursePerStudentReader["description"];
                        assignmentPerCoursesPerStudent.Title = (string)assignmentPerCoursePerStudentReader["title"];
                        assignmentPerCoursesPerStudent.Stream = (string)assignmentPerCoursePerStudentReader["stream"];
                        assignmentPerCoursesPerStudent.Type = (string)assignmentPerCoursePerStudentReader["type"];

                        assignmentPerCoursePerStudent.Add(assignmentPerCoursesPerStudent);
                    }
                    assignmentPerCoursePerStudentReader.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Sql exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }
            return assignmentPerCoursePerStudent;
        }

        public List<Student> GetAllStudentsThatBelongToMoreThanOneCourses()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    string queryString = "select s.firstName, s.lastName, s.dateOfBirth,s.tuitionFees from Students s " +
                                        "inner join studentsPerCourse " +
                                        "on studentsPerCourse.studentId = s.studentId " +
                                        "inner join Courses c " +
                                        "on c.courseId = studentsPerCourse.courseId " +
                                        "group by s.firstName,s.lastName,s.dateOfBirth,s.tuitionFees " +
                                        "having COUNT(s.studentId) > 1";

                    SqlCommand cmd = new SqlCommand(queryString, conn);
                    SqlDataReader studentReader = cmd.ExecuteReader();
                    while (studentReader.Read())
                    {
                        Student student = new Student()
                        {
                            FirstName = (string)studentReader["FirstName"],
                            LastName = (string)studentReader["LastName"],
                            DateOfBirth = (DateTime)studentReader["dateOfBirth"],
                            TuitionFees = (int)studentReader["tuitionFees"]
                        };
                        students.Add(student);
                    }
                    studentReader.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Sql exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }
            return students;
        }
    }
}
