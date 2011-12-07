
SELECT     count(*)
FROM         ParentChildren RIGHT OUTER JOIN
                      Student INNER JOIN
                      People ON Student.id = People.id INNER JOIN
                      People_School ON People.id = People_School.people_id INNER JOIN
                      School ON People_School.school_id = School.id ON ParentChildren.student_id = Student.id LEFT OUTER JOIN
                      Grade INNER JOIN
                      GradeStudent ON Grade.id = GradeStudent.grade_id ON People.id = GradeStudent.student_id

--where 1=1 and  
where 1=1

/*--where begin --*/

/*--where End--*/