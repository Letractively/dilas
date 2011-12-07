SELECT     GradeCourseSubject.id, People.name, People.gender, Teacher.rank, CourseSubject.fitGradeYear, CourseSubject.name AS CourseName, CourseSubject.semesterTerm,(CAST(CourseSubject.fitGradeYear as NCHAR(1)) +'('+ (CASE CourseSubject.semesterTerm  WHEN 0 THEN '上' when 1 then '下'  END) + ')'+ CourseSubject.name) as CourseSubjectName,
                          (SELECT     classify
                            FROM          GradeTeacher
                            WHERE      (teacher_id = GradeCourseSubject.teacher_id) AND (grade_id = GradeCourseSubject.grade_id)) AS classify
FROM         CourseSubject INNER JOIN
                      GradeCourseSubject ON CourseSubject.id = GradeCourseSubject.courseSubject_id INNER JOIN
                      People INNER JOIN
                      Teacher ON People.id = Teacher.id ON GradeCourseSubject.teacher_id = Teacher.id
WHERE     (1 = 1)

/*--where begin --*/

/*--where End--*/