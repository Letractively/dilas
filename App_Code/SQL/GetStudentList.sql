WITH StudentData AS
(
/*--order by 請在程式覆蓋 ORDER BY ModulePublish.initDate --*/

SELECT     ROW_NUMBER() OVER(ORDER BY People.initDate desc) AS RowNumber,    
People.id, People.name, People.birthday, People.description, People.gender, People.telephone_id, People.address_id, People.initDate, People.poster, People.role, 
                      People.Enable, Student.studentNumber, School.name AS schoolName, GradeStudent.seatNumber, CAST(Grade.currentYear AS NCHAR(1)) 
                      + '年' + Grade.name + '班' AS gradeName, ParentChildren.relationship,ParentChildren.id as ParentChildrenID,People.myPhoto,School.id as school_id
FROM         ParentChildren RIGHT OUTER JOIN
                      Student INNER JOIN
                      People ON Student.id = People.id INNER JOIN
                      People_School ON People.id = People_School.people_id INNER JOIN
                      School ON People_School.school_id = School.id ON ParentChildren.student_id = Student.id LEFT OUTER JOIN
                      Grade INNER JOIN
                      GradeStudent ON Grade.id = GradeStudent.grade_id ON People.id = GradeStudent.student_id

where 1=1

/*--where begin --*/

/*--where End--*/
)
select * from StudentData WHERE RowNumber >=@start  and RowNumber <=@end