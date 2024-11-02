namespace Security.Bikes.Domain.Model.Aggregates
{
    public class Bike
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
    }
}