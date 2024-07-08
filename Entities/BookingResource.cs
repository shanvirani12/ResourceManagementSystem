namespace ResourceManagementSystem.Entities
{
    public class BookingResource
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public Booking? booking { get; set; }
        public int ResourceId { get; set; }
        public Resource? resource { get; set; }
    }
}
