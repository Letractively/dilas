SELECT     Member.id, Member.account, Member.name, Member.email, UnitName.title AS Organization, 0 AS type
FROM         Member LEFT OUTER JOIN
                      UnitName ON Member.OrganizationID = UnitName.id
union all                    
Select convert(nvarchar(10),id),'角色',roleName,'',description,1
FROM Role