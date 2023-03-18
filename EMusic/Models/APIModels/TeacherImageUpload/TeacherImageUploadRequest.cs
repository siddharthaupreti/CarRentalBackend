namespace EMusic.Models.APIModels.TeacherImageUpload
{
    public class TeacherImageUploadRequest
    {
        public string UserID { get; set; }
        public byte[] TeacherImage { get; set; }
    }
}
