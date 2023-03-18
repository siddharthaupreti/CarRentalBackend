namespace EMusic.Models.APIModels.ViewInstitutesStudent
{
    public class ViewInstitutesStudentResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string InstituteName { get; set; }
        public byte[] InstituteImage { get; set; }
        public string Description { get; set; }
    }
}
