using Security.Bikes.Domain.Model.Aggregates;
using Security.Bikes.Interfaces.REST.Resources;

namespace Security.Bikes.Interfaces.REST.Transform
{
    public static class BikeTransform
    {
        public static BikeResource ToResource(Bike entity)
        {
            return new BikeResource
            {
                Id = entity.Id,
                Model = entity.Model,
                Brand = entity.Brand,
                Price = entity.Price
            };
        }
        public static Bike ToEntity(BikeResource resource)
        {
            return new Bike
            {
                Id = resource.Id,
                Model = resource.Model,
                Brand = resource.Brand,
                Price = resource.Price
            };
        }
    }
}