namespace HajurKoCarRental.Models.APIModels.GetAllRentHistory
{
    public class GetAllRentHistoryResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Guid RentID { get; set; }
        public Guid CarID { get; set; }
        public Guid UserID { get; set; }
        public string RequestDate { get; set; }
        public Guid Approver { get; set; }
        public string ApprovedDate { get; set; }
        public string ReturnedDate { get; set; }
        public string ReturnStatusName { get; set; }
    }
}
