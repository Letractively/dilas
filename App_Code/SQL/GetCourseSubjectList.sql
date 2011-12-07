WITH CourseSubjectData AS
(
/*--order by 請在程式覆蓋 ORDER BY ModulePublish.initDate --*/

SELECT ROW_NUMBER() OVER(ORDER BY CourseSubject.initDate desc) AS RowNumber,CourseSubject.id, CourseSubject.fitGradeYear, CourseSubject.semesterTerm, CourseSubject.name, CourseSubject.enable ,School.name AS schoolName
FROM         CourseSubject INNER JOIN School ON CourseSubject.school_id = School.id
where 1=1

/*--where begin --*/

/*--where End--*/
)
select * from CourseSubjectData WHERE RowNumber >=@start  and RowNumber <=@end





  