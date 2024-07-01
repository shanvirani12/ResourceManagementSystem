namespace ResourceManagementSystem.Dtos
{
    public record class CreateResourceDto
    (
        string Name,
        int Quantity,
        int LocationId
    );
}
