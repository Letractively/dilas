with ClassSession as (
SELECT     PrepareLesson.prepareDate, TimeTable.grade_id, PrepareLesson.courseSubjectName, People.name, PrepareLesson.description, 
                      PrepareLesson.importantDescription, PrepareLesson.sectionIndex_id % 8 AS ClassIndex, PrepareLesson.id
FROM         TimeTable INNER JOIN
                      PrepareLesson ON TimeTable.id = PrepareLesson.timetable_id INNER JOIN
                      People ON PrepareLesson.people_id = People.id
WHERE     (PrepareLesson.prepareDate = @prepareDate) AND (TimeTable.grade_id = @gradeId)
)

SELECT     ClassSession.id,ClassSession.prepareDate, ClassSession.grade_id, ClassSession.courseSubjectName, ClassSession.name, ClassSession.description, ClassSession.importantDescription, SectionIndex.id as SectionIndex_id
FROM         ClassSession RIGHT OUTER JOIN
                      SectionIndex ON ClassSession.ClassIndex = SectionIndex.id
                      where SectionIndex.id<=8
order by SectionIndex.id