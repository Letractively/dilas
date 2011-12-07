SELECT     ModuleContents.id, ModuleContents.publishID, ModuleContents.articleTitle, ModuleContents.listNum, ModuleContents.eable, ModuleContents.article, 
                      ModuleContents.picUrl, ModuleContents.type, ModuleContents.initDate, ModuleContents.poster, People.name, People.myPhoto
FROM         ModuleContents INNER JOIN
                      People ON ModuleContents.poster = People.id
where publishID=@publishID