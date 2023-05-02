namespace HajurKoCarRental.Models.APIModels.CreateNotification
{
    public class CreateNotificationRequest
    {
        public string UserID { get; set; }
        public string ApproverID { get; set; }
        public string Message { get; set; }
    }
}
