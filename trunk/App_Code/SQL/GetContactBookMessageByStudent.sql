SELECT     People.name, StudentContactBookMessage.initDate, StudentContactBookMessage.article, StudentContactBookMessage.Role
FROM         StudentContactBookMessage INNER JOIN
                      People ON StudentContactBookMessage.people_id = People.id
where 1=1

/*--where begin --*/

/*--where End--*/

order by initDate desc