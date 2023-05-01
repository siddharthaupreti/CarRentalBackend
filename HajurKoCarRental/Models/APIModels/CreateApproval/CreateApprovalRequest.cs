namespace HajurKoCarRental.Models.APIModels.CreateApproval
{
    public class CreateApprovalRequest
    {
        public string CarID { get; set; }
        public string UserID { get; set; }
        public string RequestedDate { get; set; }
    }
}
