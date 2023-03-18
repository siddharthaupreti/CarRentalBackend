namespace EMusic.Models.APIModels.TeachersInstitute
{
    public class TeachersInstituteResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string InstituteName { get; set; } 
        public byte[] InstituteImage { get; set; }  
        public string Description { get; set; }
    }
}
