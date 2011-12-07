SELECT    count(*)
FROM         BookCase INNER JOIN
                      AttachmentFile ON BookCase.file_id = AttachmentFile.id INNER JOIN
                      BookCaseGrade ON BookCase.id = BookCaseGrade.bookCase_id

where 1=1

/*--where begin --*/

/*--where End--*/