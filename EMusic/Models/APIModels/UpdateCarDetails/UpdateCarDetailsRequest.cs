namespace EMusic.Models.APIModels.UpdateCarDetails
{
    public class UpdateCarDetailsRequest
    {
        public string Car_ID { get; set; }
        public string Car_Model { get; set; }
        public string Car_Year { get; set; }
        public string Car_Company { get; set; }
        public string Description { get; set; }
        public decimal Price_PerDay { get; set; }
    }
}
