WITH BooksData AS
(
/*--order by 請在程式覆蓋 ORDER BY ModulePublish.initDate --*/

SELECT     ROW_NUMBER() OVER(ORDER BY Books.initDate desc) AS RowNumber
,Books.id, Books.title, Books.classID, Books.author, Books.pressID, Books.publishDate, Books.pageCount, Books.article, Books.type, 
                      Books.homePageUse, Books.insideUse, Books.poster, Books.updater, Books.initDate, Books.modifyDate, Books.enable, ModuleClass.className, 
                      BooksParm.parmName,Books.bookCover

FROM         Books INNER JOIN
                      ModuleClass ON Books.classID = ModuleClass.id INNER JOIN
                      BooksParm ON Books.type = BooksParm.code
where 1=1

/*--where begin --*/

/*--where End--*/
)
select * from BooksData WHERE RowNumber >=@start  and RowNumber <=@end
