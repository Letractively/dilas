SELECT     BookCase.id, BookCase.role, BookCase.file_id, BookCaseGrade.tab_id, BookCase.type, BookCase.publicLevel, BookCase.initDate, BookCase.poster, 
                      BookCase.updater, BookCase.lastUpdateDate, AttachmentFile.subject, AttachmentFile.fileName, AttachmentFile.coverPicName, AttachmentFile.people_id, 
                      AttachmentFile.school_id
FROM         BookCase INNER JOIN
                      AttachmentFile ON BookCase.file_id = AttachmentFile.id INNER JOIN
                      BookCaseGrade ON BookCase.id = BookCaseGrade.bookCase_id
where 1=1
/*--where begin 1--*/

/*--where End--*/

union all

SELECT     BookCase.id, BookCase.role, BookCase.file_id, BookCase.tab_id, BookCase.type, BookCase.publicLevel, BookCase.initDate, BookCase.poster, BookCase.updater, 
                      BookCase.lastUpdateDate, AttachmentFile.subject, AttachmentFile.fileName, AttachmentFile.coverPicName, AttachmentFile.people_id, AttachmentFile.school_id
FROM         BookCase INNER JOIN
                      AttachmentFile ON BookCase.file_id = AttachmentFile.id

where 1=1

/*--where begin 2--*/

/*--where End--*/