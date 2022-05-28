use IndividualProjectB;
-- 5. Produce sql queries that output the folowing
-- A list of all the students
select * from students;

-- A list of all the trainers
select * from trainers;

-- A list of all the assignments
select * from Assignments;

-- A list of all the courses
select * from Courses;

-- All the students per course
select s.firstName, s.lastName, c.title, c.Type from Students s
inner join studentsPerCourse 
on studentsPerCourse.studentId = s.studentId
inner join Courses c
on c.courseId = studentsPerCourse.courseId;

-- All the trainers per course
select t.firstName, t.lastName, c.title, c.type from Trainers t
inner join trainersPerCourse 
on trainersPerCourse.trainerId = t.trainerId
inner join Courses c
on c.courseId = trainersPerCourse.courseId;

-- All the assignments per course
select a.description, c.title, c.type  from Assignments a
inner join assignmentsPerCourse 
on assignmentsPerCourse.assignmentId = a.assignmentId
inner join Courses c
on c.courseId = assignmentsPerCourse.courseId;

--All the assignments per students per course
select s.firstName, s.lastName, a.description, c.title,c.stream,c.type from Assignments a
inner join assignmentsPerStudentPerCourse 
on assignmentsPerStudentPerCourse.assignmentId = a.assignmentId
inner join Courses c
on c.courseId = assignmentsPerStudentPerCourse.courseId
inner join Students s
on s.studentId = assignmentsPerStudentPerCourse.studentId;

-- A list of students that belong to more than one courses
select s.firstName, s.lastName, s.dateOfBirth,s.tuitionFees from Students s
inner join studentsPerCourse 
on studentsPerCourse.studentId = s.studentId
inner join Courses c
on c.courseId = studentsPerCourse.courseId
group by s.firstName,s.lastName,s.dateOfBirth,s.tuitionFees
having COUNT(s.studentId) > 1;
