WITH BookCasesData AS
(
/*--order by 請在程式覆蓋 ORDER BY ModulePublish.initDate --*/

SELECT     ROW_NUMBER() OVER(ORDER BY BookCase.initDate desc) AS RowNumber
, BookCase.id, BookCase.people_id, BookCase.school_id, BookCaseGrade.grade_id, BookCase.role, BookCase.file_id, BookCase.tab_id, BookCase.type, 
                      BookCase.publicLevel, BookCase.initDate, BookCase.poster, BookCase.updater, BookCase.lastUpdateDate, AttachmentFile.subject, AttachmentFile.fileName, 
                      AttachmentFile.coverPicName

FROM         BookCase INNER JOIN
                      AttachmentFile ON BookCase.file_id = AttachmentFile.id INNER JOIN
                      BookCaseGrade ON BookCase.id = BookCaseGrade.bookCase_id
where 1=1

/*--where begin --*/

/*--where End--*/
)
select * from BookCasesData WHERE RowNumber >=@start  and RowNumber <=@end