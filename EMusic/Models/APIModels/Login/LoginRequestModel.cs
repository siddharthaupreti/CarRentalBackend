namespace EMusic.Models.APIModels.Login
{
    public class LoginRequestModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserType { get; set; }
        public string? UserToken { get; set; }

    }
}
