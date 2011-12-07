SELECT     id, CAST(currentYear AS NCHAR(1)) + '年' + name + '班' AS gradeName, currentYear, enrollYear, name, school_id
FROM         Grade
