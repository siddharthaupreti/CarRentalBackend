namespace EMusic.Models.APIModels.AddLessons
{
    public class AddLessonsResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string LessonName { get; set; }
        public string LessonDescription { get; set; }
        public byte[] LessonVideo { get; set; }
    }
}
