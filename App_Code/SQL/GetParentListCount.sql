
SELECT     count(*)
FROM         People INNER JOIN
                      People_School ON People.id = People_School.people_id INNER JOIN
                      School ON People_School.school_id = School.id INNER JOIN
                      Parent ON People.id = Parent.id

--where 1=1 and  
where 1=1

/*--where begin --*/

/*--where End--*/