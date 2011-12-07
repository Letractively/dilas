SELECT     id, (CAST(fitGradeYear as NCHAR(1)) +'('+ (CASE semesterTerm  WHEN 0 THEN '上' when 1 then '下'  END) + ')'+ name) as fullName
FROM         CourseSubject

where 1=1

/*--where begin --*/

/*--where End--*/