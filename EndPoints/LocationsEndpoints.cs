using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ResourceManagementSystem.Data;
using ResourceManagementSystem.Dtos;
using ResourceManagementSystem.Entities;

namespace ResourceManagementSystem.EndPoints
{
    public static class LocationsEndpoints
    {
        const string GetLocationsEndpointName = "GetLocation";

        public static WebApplication MapLocationsEndpoints(this WebApplication app)
        {
            // GET /locations
            app.MapGet("locations", (ResourceManagementContext dbContext) =>
            dbContext.Locations);

            // GET /locations/id
            app.MapGet("locations/{id}", (int id, ResourceManagementContext dbContext) =>
            {
                Location? location = dbContext.Locations.Find(id);

                return location is null ? Results.NotFound() : Results.Ok(location);
            }).WithName(GetLocationsEndpointName);

            app.MapPost("locations", (CreateLocationDto newLocation, ResourceManagementContext dbContext) =>
            {
                Location location = new()
                {
                    Name = newLocation.Name,
                };
                dbContext.Locations.Add(location);
                dbContext.SaveChanges();

                return Results.CreatedAtRoute(GetLocationsEndpointName, new
                {
                    id = location.Id
                }, location);
            });

            bool LocationsExists(int id, ResourceManagementContext dbContext)
            {
                return dbContext.Locations.Any(e => e.Id == id);
            }

            // PUT /locations/1
            app.MapPut("locations/{id}", async (int id, UpdateLocationDto updatedLocation, ResourceManagementContext dbContext) =>
            {
                var existinglocation = await dbContext.Locations.FindAsync(id);

                if (existinglocation == null)
                {
                    return Results.NotFound();
                }

                // Update properties of the existing resource
                existinglocation.Name = updatedLocation.Name;
                

                try
                {
                    await dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationsExists(id, dbContext))
                    {
                        return Results.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return Results.NoContent();
            });

            // DELETE /locationa/1
            app.MapDelete("locations/{id}", async (int id, ResourceManagementContext dbContext) =>
            {
                var location = await dbContext.Locations.FindAsync(id);

                if (location == null)
                {
                    return Results.NotFound();
                }

                dbContext.Locations.Remove(location);
                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            });

            return app;
        }


    }
}
