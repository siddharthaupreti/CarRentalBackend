namespace EMusic.Models.APIModels.StudentTeachers
{
    public class StudentTeachersResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string TeacherName { get; set; }
        public byte[] TeacherPhoto { get; set; }
        public string InstituteName { get; set; }
    }
}
