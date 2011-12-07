with HotBooks as
(
SELECT   newid() as NID,  Books.*, ModuleClass.className
FROM         Books LEFT OUTER JOIN
                      ModuleClass ON Books.classID = ModuleClass.id
WHERE     (homePageUse like '%B04%')

/*--where begin --*/

/*--where End--*/
)

select top 8 * from HotBooks order by NID