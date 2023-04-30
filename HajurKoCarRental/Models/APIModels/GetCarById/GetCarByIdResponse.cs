namespace EMusic.Models.APIModels.GetCarById
{
    public class GetCarByIdResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string CarCompany { get; set; }
        public string CarModel { get; set; }
        public string CarYear { get; set; }
        public string Description { get; set; }
        public decimal PricePerDay { get; set; }
    }
}
