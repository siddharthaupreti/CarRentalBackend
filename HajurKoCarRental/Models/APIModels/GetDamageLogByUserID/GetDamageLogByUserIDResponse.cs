namespace HajurKoCarRental.Models.APIModels.GetDamageLogByUserID
{
    public class GetDamageLogByUserIDResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Guid DamageLogID { get; set; }
        public Guid CarID { get; set; }
        public decimal PaymentFees { get; set; }
        public string Payed { get; set; }
        public Guid UserID { get; set; }
        
    }
}
