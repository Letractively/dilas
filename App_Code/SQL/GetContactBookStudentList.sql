SELECT     People.id,People.name, GradeStudent.seatNumber, GradeStudent.grade_id
into #GradeStudentData
FROM         GradeStudent INNER JOIN
                      People ON GradeStudent.student_id = People.id
WHERE     (GradeStudent.grade_id = @grade_id)

select * into #StudentContactBookData
from StudentContactBook where contactBook_id=@contactBook_id

                      
                      
SELECT     #GradeStudentData.id AS people_id, #GradeStudentData.name, #GradeStudentData.seatNumber, #StudentContactBookData.checkDownload, 
                      #StudentContactBookData.checkUpload, #GradeStudentData.grade_id, #StudentContactBookData.signPic, #StudentContactBookData.isSign
                      ,(select count(*) from dbo.StudentContactBookMessage where Role>=1 and contactBookDate<@contactBookDate and student_id=#GradeStudentData.id) as  lastReply
					  ,(select count(*) from dbo.StudentContactBookMessage where Role>=1 and contactBookDate=@contactBookDate and student_id=#GradeStudentData.id) as  toDayReply
FROM         #GradeStudentData LEFT OUTER JOIN
                      #StudentContactBookData ON #GradeStudentData.id = #StudentContactBookData.people_id