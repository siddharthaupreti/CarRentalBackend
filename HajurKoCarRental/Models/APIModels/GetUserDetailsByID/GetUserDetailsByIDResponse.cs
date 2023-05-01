namespace EMusic.Models.APIModels.GetUserDetailsByID
{
    public class GetUserDetailsByIDResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public Guid UserID { get; set; }
        public string Email { get; set; }
    }
}
