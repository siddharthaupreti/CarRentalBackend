namespace EMusic.Models.APIModels.CreateCar
{
    public class CreateCarRequest
    {
        public string Car_Model { get; set; }
        public string Car_Year { get; set; }
        public string Car_Company { get; set; }
        public string Description { get; set; }
        public byte[] Car_Image { get; set; }
        public decimal Price_PerDay { get; set; } 
    }
}
