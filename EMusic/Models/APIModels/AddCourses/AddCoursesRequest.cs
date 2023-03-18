namespace EMusic.Models.APIModels.AddCourses
{
    public class AddCoursesRequest
    {
        public string InstituteName { get; set; }
        public Guid UserId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
    }
}
