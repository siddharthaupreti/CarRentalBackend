namespace EMusic.Models.APIModels.TeachersApplication
{
    public class TeachersApplicationRequest
    {
        public string InstituteName { get; set; }
        public Guid UserId { get; set; }
        public byte[] Video { get; set; }   
    }
}
