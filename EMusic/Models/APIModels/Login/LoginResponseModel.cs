namespace EMusic.Models.APIModels.Login
{
    public class LoginResponseModel
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Guid UserID { get; set; }

        public Guid UserTypeID { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public string UserToken { get; set; }
        public string UserRole { get; set; }   
    }
}
