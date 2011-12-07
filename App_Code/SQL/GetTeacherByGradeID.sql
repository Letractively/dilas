SELECT     GradeTeacher.id, GradeTeacher.classify, GradeTeacher.grade_id, GradeTeacher.teacher_id, People.name, People.gender, Teacher.rank
FROM         People INNER JOIN
                      Teacher ON People.id = Teacher.id INNER JOIN
                      GradeTeacher ON Teacher.id = GradeTeacher.teacher_id
where 1=1

/*--where begin --*/

/*--where End--*/