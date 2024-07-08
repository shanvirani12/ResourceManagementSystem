namespace ResourceManagementSystem.Dtos
{
    public class CreateBookingDto
    {
        public string PersonName { get; set; }
        public double ContactNumber { get; set; }
        public DateOnly CollectionDate { get; set; }
        public DateOnly ReturnDate { get; set; }
        public string ClassDept { get; set; }
    }

}
