namespace EMusic.Models.APIModels.CourseEnrollmentApplication
{
    public class CourseEnrollmentApplicationResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string StudentName { get; set; }
        public string TeacherName { get; set; }
        public string CourseTitle { get; set; }
        public string StudentEmail { get; set; }
        public string StudentPhoneNumber { get; set; }
    }
}
