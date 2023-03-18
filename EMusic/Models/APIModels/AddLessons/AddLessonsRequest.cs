namespace EMusic.Models.APIModels.AddLessons
{
    public class AddLessonsRequest
    {
        public string CourseTitle { get; set; }
        public string LessonName { get; set; }
        public string LessonDescription { get; set;}
        public byte[] LessonVideo { get; set;}
    }
}
