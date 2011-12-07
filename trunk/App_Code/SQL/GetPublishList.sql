WITH ModulePublishData AS
(
/*--order by 請在程式覆蓋 ORDER BY ModulePublish.initDate --*/

SELECT     ROW_NUMBER() OVER(ORDER BY ModulePublish.initDate desc) AS RowNumber
,ModulePublish.*,ModuleClass.className,
					  (SELECT     count(*)
                            FROM          ModuleContents
                            WHERE      (publishID = ModulePublish.id)
                            ) AS articleCount, People.name, People.myPhoto, People.gender, People.role

FROM         People INNER JOIN
                      ModulePublish ON People.id = ModulePublish.poster LEFT OUTER JOIN
                      ModuleClass ON ModulePublish.classID = ModuleClass.id
where 1=1

/*--where begin --*/

/*--where End--*/
)
select * from ModulePublishData WHERE RowNumber >=@start  and RowNumber <=@end
