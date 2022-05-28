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
                            Subject = (string)trainerReader["subject"]

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

        public void CreateCourse(Course course)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    string queryString = "insert into Courses (title,stream,type,startDate,endDate) " +
                                        "values (@title,@stream,@type,@startDate,@endDate)";

                    SqlCommand cmd = new SqlCommand(queryString, conn);

                    cmd.Parameters.Add(new SqlParameter("@title", course.Title));
                    cmd.Parameters.Add(new SqlParameter("@stream", course.Stream));
                    cmd.Parameters.Add(new SqlParameter("@type", course.Type));
                    cmd.Parameters.Add(new SqlParameter("@startDate", course.Start_Date));
                    cmd.Parameters.Add(new SqlParameter("@endDate", course.End_Date));

                    int rowsInserted = cmd.ExecuteNonQuery();
                    if (rowsInserted > 0)
                    {
                        Console.WriteLine($"Course: {course.Title} inserted successfully in the database ");
                    }
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

        public void CreateStudent(Student student)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    string queryString = "insert into Students (firstName,lastName,dateOfBirth,tuitionFees) " +
                                         "values (@firstName,@lastName,@dateOfBirth,@tuitionFees)";

                    SqlCommand cmd = new SqlCommand(queryString, conn);

                    cmd.Parameters.Add(new SqlParameter("@firstName", student.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@lastName", student.LastName));
                    cmd.Parameters.Add(new SqlParameter("@dateOfBirth", student.DateOfBirth));
                    cmd.Parameters.Add(new SqlParameter("@tuitionFees", student.TuitionFees));

                    int rowsInserted = cmd.ExecuteNonQuery();
                    if (rowsInserted > 0)
                    {
                        Console.WriteLine($"Student {student.FirstName} {student.LastName} inserted successfully in the database ");
                    }
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

        public void CreateTrainer(Trainer trainer)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    string queryString = "insert into Trainers (firstName,lastName,subject) " +
                                         "values (@firstName,@lastName,@subject)";

                    SqlCommand cmd = new SqlCommand(queryString, conn);

                    cmd.Parameters.Add(new SqlParameter("@firstName", trainer.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@lastName", trainer.LastName));
                    cmd.Parameters.Add(new SqlParameter("@subject", trainer.Subject));

                    int rowsInserted = cmd.ExecuteNonQuery();
                    if (rowsInserted > 0)
                    {
                        Console.WriteLine($"Trainer {trainer.FirstName} {trainer.LastName} inserted successfully in the database ");
                    }
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

        public void CreateAssignment(Assignment assignment)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    string queryString = "insert into Assignments (description,subDateTime,oralMark,totalMark) " +
                                        "values (@description,@subDateTime,@oralMark,@totalMark)";

                    SqlCommand cmd = new SqlCommand(queryString, conn);

                    cmd.Parameters.Add(new SqlParameter("@description", assignment.Description));
                    cmd.Parameters.Add(new SqlParameter("@subDateTime", assignment.SubDateTime));
                    cmd.Parameters.Add(new SqlParameter("@oralMark", assignment.OralMark));
                    cmd.Parameters.Add(new SqlParameter("@totalMark", assignment.TotalMark));

                    int rowsInserted = cmd.ExecuteNonQuery();
                    if (rowsInserted > 0)
                    {
                        Console.WriteLine($"Assignment: {assignment.Description} inserted successfully in the database ");
                    }
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

        public void StudentsPerCourseConnection(StudentPerCourse studentPerCourse)
        {
            int courseId = 0;
            int studentId = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                //getting the student id
                try
                {
                    conn.Open();
                    string queryString = "select studentId from Students " +
                                        "where firstName like @firstName " +
                                        "and lastName like @lastName ";

                    SqlCommand cmd = new SqlCommand(queryString, conn);
                    cmd.Parameters.Add(new SqlParameter("@firstName", studentPerCourse.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@lastName", studentPerCourse.LastName));
                    SqlDataReader studentReader = cmd.ExecuteReader();
                    int count = 0;
                    
                    while (studentReader.Read())
                    {
                        studentId = (int)studentReader["studentId"];
                        count++;
                    }
                    studentReader.Close();
                    if (count == 0)
                    {
                        throw new Exception("There is no Student with that FirstName and LastName");
                    }
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
                // getting the course id
                try
                {
                    conn.Open();
                    string queryString = @"select courseId from Courses " +
                                        "where title like @title " +
                                        "and type like @type";
                    SqlCommand cmd = new SqlCommand(queryString, conn);
                    cmd.Parameters.Add(new SqlParameter("@title", studentPerCourse.Title));
                    cmd.Parameters.Add(new SqlParameter("@type", studentPerCourse.Type));
                    SqlDataReader courseReader = cmd.ExecuteReader();
                    int count = 0;
              
                    while (courseReader.Read())
                    {
                        courseId = (int)courseReader["courseId"];
                        count++;
                    }
                    courseReader.Close();
                    if (count == 0)
                    {
                        throw new Exception("There is no Course with that Title and Type");
                    }

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

                // inserting the Students Per Course record in database
                try
                {
                    conn.Open();
                    string queryString = "insert into studentsPerCourse (courseId,studentId) " +
                                        "values (@courseId,@studentId)";

                    SqlCommand cmd = new SqlCommand(queryString, conn);

                    cmd.Parameters.Add(new SqlParameter("@courseId", courseId));
                    cmd.Parameters.Add(new SqlParameter("@studentId", studentId));                    

                    int rowsInserted = cmd.ExecuteNonQuery();
                    if (rowsInserted > 0)
                    {
                        Console.WriteLine($"Course  {studentPerCourse.Title} and Student {studentPerCourse.FirstName} {studentPerCourse.LastName} connected successfully in the database ");
                    }
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

        public void TrainersPerCourseConnection(TrainerPerCourse trainerPerCourse)
        {
            int courseId = 0;
            int trainerId = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                //getting the trainer id
                try
                {
                    conn.Open();
                    string queryString = "select trainerId from Trainers " +
                                        "where firstName like @firstName " +
                                        "and lastName like @lastName ";

                    SqlCommand cmd = new SqlCommand(queryString, conn);
                    cmd.Parameters.Add(new SqlParameter("@firstName", trainerPerCourse.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@lastName", trainerPerCourse.LastName));
                    SqlDataReader trainerReader = cmd.ExecuteReader();
                    int count = 0;

                    while (trainerReader.Read())
                    {
                        trainerId = (int)trainerReader["trainerId"];
                        count++;
                    }
                    trainerReader.Close();
                    if (count == 0)
                    {
                        throw new Exception("There is no Trainer with that FirstName and LastName");
                    }
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
                // getting the course id
                try
                {
                    conn.Open();
                    string queryString = @"select courseId from Courses " +
                                        "where title like @title " +
                                        "and type like @type";
                    SqlCommand cmd = new SqlCommand(queryString, conn);
                    cmd.Parameters.Add(new SqlParameter("@title", trainerPerCourse.Title));
                    cmd.Parameters.Add(new SqlParameter("@type", trainerPerCourse.Type));
                    SqlDataReader courseReader = cmd.ExecuteReader();
                    int count = 0;

                    while (courseReader.Read())
                    {
                        courseId = (int)courseReader["courseId"];
                        count++;
                    }
                    courseReader.Close();
                    if (count == 0)
                    {
                        throw new Exception("There is no Course with that Title and Type");
                    }

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

                // inserting the Trainer Per Course record in database
                try
                {
                    conn.Open();
                    string queryString = "insert into trainersPerCourse (trainerId,courseId) " +
                                        "values (@trainerId,@courseId)";

                    SqlCommand cmd = new SqlCommand(queryString, conn);

                    cmd.Parameters.Add(new SqlParameter("@courseId", courseId));
                    cmd.Parameters.Add(new SqlParameter("@trainerId", trainerId));

                    int rowsInserted = cmd.ExecuteNonQuery();
                    if (rowsInserted > 0)
                    {
                        Console.WriteLine($"Course  {trainerPerCourse.Title} and Trainer {trainerPerCourse.FirstName} {trainerPerCourse.LastName} connected successfully in the database ");
                    }
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
    }
}
