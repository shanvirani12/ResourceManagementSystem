using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResourceManagementSystem.Data;
using ResourceManagementSystem.Dtos;
using ResourceManagementSystem.Entities;

namespace ResourceManagementSystem.EndPoints
{
    public static class BookingsEndpoints
    {
        const string GetBookingsEndpointName = "GetBookings";

        public static WebApplication MapBookingsEndpoints(this WebApplication app)
        {
            app.MapGet("Bookings", (ResourceManagementContext dbContext) =>
            {
                dbContext.BookingResources
                         .Include(br => br.booking)
                         .Include(br => br.resource)
                         .ToList();
            });

            app.MapPost("Bookings", async (BookingRequestDto request, ResourceManagementContext dbContext) =>
            {
                if (request.NewBooking == null || request.Resource == null)
                {
                    return Results.BadRequest("Invalid booking or resource data.");
                }

                Booking booking = new()
                {
                    personName = request.NewBooking.PersonName,
                    contactNumber = request.NewBooking.ContactNumber,
                    collectionDate = request.NewBooking.CollectionDate,
                    returnDate = request.NewBooking.ReturnDate,
                    class_dept = request.NewBooking.ClassDept,
                };

                dbContext.Bookings.Add(booking);
                await dbContext.SaveChangesAsync();

                BookingResource bookingResource = new()
                {
                    BookingId = booking.Id,
                    ResourceId = request.Resource.Id
                };

                dbContext.BookingResources.Add(bookingResource);
                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute("GetBookingsEndpointName", new { id = booking.Id }, booking);
            });





            return app;
        }


    }
}
