with HotBooks as
(
SELECT   newid() as NID,  Books.*, ModuleClass.className
FROM         Books LEFT OUTER JOIN
                      ModuleClass ON Books.classID = ModuleClass.id
WHERE     (homePageUse like '%B02%')

/*--where begin --*/

/*--where End--*/
)

select top 4 * from HotBooks order by NID