SELECT      BookCaseGrade.id,CAST(Grade.currentYear AS NCHAR(1)) + '年' + Grade.name + '班' AS gradeName, BookCaseGrade.bookCase_id, BookCaseGrade.tab_id, 
                      BookTab.subject
FROM         BookCaseGrade INNER JOIN
                      Grade ON BookCaseGrade.grade_id = Grade.id INNER JOIN
                      BookTab ON BookCaseGrade.tab_id = BookTab.id
where 1=1

/*--where begin --*/

/*--where End--*/





