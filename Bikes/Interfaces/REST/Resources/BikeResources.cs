namespace Security.Bikes.Interfaces.REST.Resources
{
    public record BikeResource
    {
        public BikeResource(int id, string model, string brand, decimal price)
        {
            Id = id;
            Model = model;
            Brand = brand;
            Price = price;
        }

        public BikeResource()
        {
            throw new NotImplementedException();
        }


        public int Id { get; init; }
        public string Model { get; init; }
        public string Brand { get; init; }
        public decimal Price { get; init; }
    }
}