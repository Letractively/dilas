WITH SchoolData AS
(
/*--order by 請在程式覆蓋 ORDER BY ModulePublish.initDate --*/

SELECT ROW_NUMBER() OVER(ORDER BY School.initDate desc) AS RowNumber,     
School.id, School.name,Address.division, School.enable,(select count(*) from dbo.Grade where Grade.school_id=School.id) as GradeCount,School.initDate
FROM         School LEFT OUTER JOIN
                      Address ON School.address_id = Address.id
where 1=1

/*--where begin --*/

/*--where End--*/
)
select * from SchoolData WHERE RowNumber >=@start  and RowNumber <=@end