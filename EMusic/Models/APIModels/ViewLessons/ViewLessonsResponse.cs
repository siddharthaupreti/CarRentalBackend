namespace EMusic.Models.APIModels.ViewLessons
{
    public class ViewLessonsResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string LessonName { get; set; }
        public string LessonDescription { get; set;}
        public byte[] LessonVideo { get; set;}
    }
}
