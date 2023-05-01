namespace HajurKoCarRental.Models.APIModels.GetAllApproval
{
    public class GetAllApprovalResponse
    {
        public Guid RequestID { get; set; }
        public string FullName { get; set; }
        public string CarModel { get; set; }
        public string RequestedDate { get; set; }
    }
}
