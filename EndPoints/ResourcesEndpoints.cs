using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ResourceManagementSystem.Data;
using ResourceManagementSystem.Dtos;
using ResourceManagementSystem.Entities;

namespace ResourceManagementSystem.EndPoints
{
    public static class ResourcesEndpoints
    {
        const string GetResourceEndpointName = "GetResource";
        private static readonly List<ResourceDto> resources = [
        new(
            1,
            "Multimedia",
            3,1
            ),
        new(
            2,
            "Gowns",
            100,3),
        new(
            3,
            "Laptops",
            5,2),
    ];

        public static WebApplication MapResourcesEndpoints(this WebApplication app)
        {
            // GET /resources
            app.MapGet("resources", (ResourceManagementContext dbContext) =>
            dbContext.Resources.Include(r => r.Location).ToListAsync()
                     );

            // GET /resources/1
            app.MapGet("resources/{id}", (int id, ResourceManagementContext dbContext) =>
            {
                Resource? resource = dbContext.Resources.Find(id);

                return resource is null ? Results.NotFound() : Results.Ok(resource);
            }).WithName(GetResourceEndpointName);

            // POST /resources
            app.MapPost("resources", (CreateResourceDto newResource, ResourceManagementContext dbContext) =>
            {
                Resource resource = new()
                {
                    Name = newResource.Name,
                    Quantity = newResource.Quantity,
                    Location = dbContext.Locations.Find(newResource.LocationId),
                    LocationID = newResource.LocationId,
                };

                dbContext.Resources.Add(resource);
                dbContext.SaveChanges();

                return Results.CreatedAtRoute(GetResourceEndpointName, new
                {
                    id = resource.Id
                }, resource);
            });

            // PUT /resources/1
            app.MapPut("resources/{id}", async (int id, UpdateResourceDto updatedResource, ResourceManagementContext dbContext) =>
            {
                var existingResource = await dbContext.Resources.FindAsync(id);

                if (existingResource == null)
                {
                    return Results.NotFound();
                }

                // Update properties of the existing resource
                existingResource.Name = updatedResource.Name;
                existingResource.Quantity = updatedResource.Quantity;
                existingResource.LocationID = updatedResource.LocationId;

                try
                {
                    await dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResourceExists(id, dbContext))
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

            // Helper method to check if the resource exists
            bool ResourceExists(int id, ResourceManagementContext dbContext)
            {
                return dbContext.Resources.Any(e => e.Id == id);
            }


            // DELETE /resource/1
            app.MapDelete("resources/{id}",async (int id, ResourceManagementContext dbContext) =>
            {
                var resource = await dbContext.Resources.FindAsync(id);
                
                if(resource == null)
                {
                    return Results.NotFound();
                }

                dbContext.Resources.Remove(resource);
                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            });

            return app;
        }
    }
}
