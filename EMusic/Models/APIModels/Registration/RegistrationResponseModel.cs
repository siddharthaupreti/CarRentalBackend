
namespace EMusic.Models.APIModels.Registration
{
    public class RegistrationResponseModel
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string EstablishedYear { get; set; }
        public string Description { get; set; }
    }
}
