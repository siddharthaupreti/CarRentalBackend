namespace EMusic.Models.APIModels.TeacherEnorllmentApplication
{
    public class TeacherEnrollmentApplicationResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string TeacherName { get; set; }
        public string TeacherEmail { get; set; }
        public string TeacherPhoneNumber { get; set; }
        public byte[] ApplicationVideo { get; set; }
    }
}
