using Microsoft.AspNetCore.Routing.Constraints;

namespace ResourceManagementSystem.Dtos
{
    public record class CreateBookingResourceDto
    (
        int BookingId,
        int ResourceId
    );
}
