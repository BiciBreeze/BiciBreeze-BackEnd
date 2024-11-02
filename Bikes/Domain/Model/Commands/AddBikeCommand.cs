namespace Security.Bikes.Domain.Model.Commands
{
    public class AddBikeCommand
    {
        public string Type { get; set; }
        public bool IsAvailable { get; set; }
    }
}