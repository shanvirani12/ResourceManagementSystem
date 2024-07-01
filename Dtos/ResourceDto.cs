namespace ResourceManagementSystem.Dtos
{
    public record class ResourceDto(
        int Id, 
        string Name, 
        int Quantity,
        int LocationId
        );
    
}
