namespace HajurKoCarRental.Models.APIModels.GetDamageLogByUserID
{
    public class GetDamageLogByUserIDResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Guid DamageLogID { get; set; }
        public string CarName { get; set; }
        public decimal PaymentFees { get; set; }
        public string Payed { get; set; }
        public string UserName { get; set; }
        
    }
}
