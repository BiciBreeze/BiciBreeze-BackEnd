using System;

namespace Security.Rental.Domain.Enums
{
    public enum BikeType
    {
        [BikeTypeInfo("Bicicleta de ciudad", 10.0)]
        City = 1,

        [BikeTypeInfo("Bicicleta de montaña", 15.0)]
        Mountain = 2,

        [BikeTypeInfo("Bicicleta de carretera", 12.0)]
        Road = 3,

        [BikeTypeInfo("Bicicleta eléctrica", 20.0)]
        Electric = 4
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    sealed class BikeTypeInfoAttribute(string description, double baseRate) : Attribute
    {
        public string Description { get; } = description;
        public double BaseRate { get; } = baseRate;
    }
}