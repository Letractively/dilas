/* 登入用，輸入帳號密碼回傳 使用者單位 個人資料與權限等資料 */
SELECT     Account.username, Account.password, Account.emailAddress, People.name, People.role, People_School.school_id, People.id as people_id
FROM         Account INNER JOIN
                      People ON Account.people_id = People.id INNER JOIN
                      People_School ON People.id = People_School.people_id
WHERE     (username = @username) AND (password = @password)

/*--where begin --*/

/*--where End--*/

/*--order by begin--*/

/*--order by begin--*/