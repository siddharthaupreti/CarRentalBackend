namespace HajurKoCarRental.Models.APIModels.CreateDamageLog
{
    public class CreateDamageLogRequest
    {
        public string CarID { get; set; }
        public string UserID { get; set; }
        public string Description { get; set; }
        public decimal PaymentFees { get; set; }
    }
}
