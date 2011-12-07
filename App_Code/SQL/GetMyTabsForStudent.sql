with Tabs AS(
select * from dbo.BookTab where status=0 
union all
select * from dbo.BookTab where status=1 


/*--where begin --*/

/*--where End--*/
union all
select * from dbo.BookTab where status=2 
)
select * from Tabs order by status,listnum