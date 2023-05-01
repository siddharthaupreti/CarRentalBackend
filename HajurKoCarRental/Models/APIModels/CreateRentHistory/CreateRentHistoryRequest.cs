namespace HajurKoCarRental.Models.APIModels.CreateRentHistory
{
    public class CreateRentHistoryRequest
    {
        public string CarID { get; set; }
        public string UserID { get; set; }
        public string RequestDate { get; set; }
        public string ApproverID { get; set; }
        public string ApprovedDate { get; set; }
        public string ReturnedDate { get; set; }
    }
}
