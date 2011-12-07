WITH TeacherData AS
(
/*--order by 請在程式覆蓋 ORDER BY ModulePublish.initDate --*/

SELECT     ROW_NUMBER() OVER(ORDER BY People.initDate desc) AS RowNumber,
People.id, People.name, People.birthday, People.description, People.gender, People.telephone_id, People.address_id, People.initDate, People.poster, People.role, 
                      People.enable, School.name AS schoolName, Parent.occupation
FROM         People INNER JOIN
                      People_School ON People.id = People_School.people_id INNER JOIN
                      School ON People_School.school_id = School.id INNER JOIN
                      Parent ON People.id = Parent.id

where 1=1

/*--where begin --*/

/*--where End--*/
)
select * from TeacherData WHERE RowNumber >=@start  and RowNumber <=@end