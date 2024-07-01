namespace ResourceManagementSystem.Entities
{
    public class Resource
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Quantity { get; set; }
        public int LocationID { get; set; }
        public Location? Location { get; set; }
    }
}
