namespace HajurKoCarRental.Models.APIModels.ChangeReturnStatusRentHistory
{
    public class ChangeReturnStatusRentHistoryRequest
    {
        public string UserID { get; set; }
        public string NewStatus { get; set; }
    }
}
