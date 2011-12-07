SELECT     CAST(CourseSubject.fitGradeYear AS NCHAR(1)) + '(' + (CASE CourseSubject.semesterTerm WHEN 0 THEN '上' WHEN 1 THEN '下' END) 
                      + ')' + CourseSubject.name AS CourseSubjectName, GradeCourseSubject.id
FROM         CourseSubject INNER JOIN
                      GradeCourseSubject ON CourseSubject.id = GradeCourseSubject.courseSubject_id
Where 1=1 

/*--where begin --*/

/*--where End--*/