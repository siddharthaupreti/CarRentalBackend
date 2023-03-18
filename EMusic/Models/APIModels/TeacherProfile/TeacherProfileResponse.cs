namespace EMusic.Models.APIModels.TeacherProfile
{
    public class TeacherProfileResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string TeacherName {get; set;}
        public byte[] TeacherPhoto {get; set;}
        public string PhoneNumber {get; set;}
    }
}
