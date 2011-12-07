with TimeTableData AS
(
SELECT     CAST(CourseSubject.fitGradeYear AS NCHAR(1)) + '(' + (CASE CourseSubject.semesterTerm WHEN 0 THEN '上' WHEN 1 THEN '下' END) 
                      + ')' + CourseSubject.name AS CourseSubjectName, TimeTable.grade_id, People.name AS teacherName, TimeTable.sectionIndex_id, 
                      GradeCourseSubject.id AS GradeCourseSubjectID,People.id as people_id,TimeTable.id As timetable_id
FROM         TimeTable INNER JOIN
                      GradeCourseSubject ON TimeTable.gradeCourseSubject_id = GradeCourseSubject.id INNER JOIN
                      CourseSubject ON GradeCourseSubject.courseSubject_id = CourseSubject.id INNER JOIN
                      People ON GradeCourseSubject.teacher_id = People.id
where 1=1

/*--where begin --*/

/*--where End--*/
)

SELECT     SectionIndex.id, TimeTableData_1.CourseSubjectName, TimeTableData_1.grade_id, TimeTableData_1.teacherName, TimeTableData_1.sectionIndex_id,TimeTableData_1.GradeCourseSubjectID,TimeTableData_1.people_id,TimeTableData_1.timetable_id
FROM         TimeTableData AS TimeTableData_1 RIGHT OUTER JOIN
                      SectionIndex ON TimeTableData_1.sectionIndex_id = SectionIndex.id
ORDER BY SectionIndex.id