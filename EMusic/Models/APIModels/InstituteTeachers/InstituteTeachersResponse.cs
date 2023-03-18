namespace EMusic.Models.APIModels.InstituteTeachers
{
    public class InstituteTeachersResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string TeacherName { get; set; }
        public byte[] TeacherPhoto { get; set; }
    }
}
