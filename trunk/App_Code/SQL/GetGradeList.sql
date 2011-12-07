WITH GradeData AS
(
/*--order by 請在程式覆蓋 ORDER BY ModulePublish.initDate --*/

SELECT ROW_NUMBER() OVER(ORDER BY Grade.initDate desc) AS RowNumber, Grade.id, School.name as schoolName, Grade.name AS GradeName, Grade.currentYear, Grade.enrollYear, Grade.enable, Grade.initDate,(select count(*) from dbo.GradeStudent where GradeStudent.grade_id=Grade.id) as GradeStudentCount
FROM         Grade INNER JOIN
                      School ON Grade.school_id = School.id
where 1=1

/*--where begin --*/

/*--where End--*/
)
select * from GradeData WHERE RowNumber >=@start  and RowNumber <=@end