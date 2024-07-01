namespace ResourceManagementSystem.Dtos
{
    public record class UpdateResourceDto
    (
        string Name,
        int Quantity,
        int LocationId
    );
}
