namespace HajurKoCarRental.Models.APIModels.GetAllRentHistory
{
    public class GetAllRentHistoryResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Guid RentID { get; set; }
        public string CarModel { get; set; }
        public string UserName { get; set; }
        public string RequestDate { get; set; }
        public string Approver { get; set; }
        public string ApprovedDate { get; set; }
        public string ReturnedDate { get; set; }
        public string ReturnStatusName { get; set; }
        public string Payment { get; set; }
        public Guid CarID { get; set; }
        public Guid UserID { get; set; }
    }
}
