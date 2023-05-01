namespace HajurKoCarRental.Models.APIModels.GetPaymentByID
{
    public class GetPaymentByIDResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public int Discount { get; set; }
        public Guid PaymentID { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentMethod { get; set; }
        public Guid RentID { get; set; }
    }
}
