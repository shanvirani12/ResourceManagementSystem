namespace ResourceManagementSystem.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public string? personName { get; set; }
        public double contactNumber { get; set; }
        public DateOnly collectionDate { get; set; }
        public DateOnly returnDate { get; set; }
        public string? class_dept {  get; set; }
    }
}
