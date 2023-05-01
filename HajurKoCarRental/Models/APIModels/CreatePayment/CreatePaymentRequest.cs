namespace HajurKoCarRental.Models.APIModels.CreatePayment
{
    public class CreatePaymentRequest
    {
        public string CarID { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentMethod { get; set; }
        public int Discount { get; set; }
        public string RentID { get; set; }
    }
}
