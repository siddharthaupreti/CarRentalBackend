namespace HajurKoCarRental.Models.APIModels.GetNotificationByID
{
    public class GetNotificationByIDResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Guid NotificationID { get; set; }
        public string ApproverName { get; set; }
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string NotificationMessage { get; set; }
    }
}
