namespace Delivery.Domain
{
    public class Rider
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int RideCount { get; set; }
        public required string  NumberPlate { get; set; }

    }
}
