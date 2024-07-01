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
            app.MapGet("resources", () => resources);

            // GET /resources/1
            app.MapGet("resources/{id}", (int id) =>
            {
                ResourceDto? resource = resources.Find(resource => resource.Id == id);

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
            app.MapPut("resources/{id}", (int id, UpdateResourceDto updatedResource) =>
            {
                var index = resources.FindIndex(resource => resource.Id == id);

                if (index == -1)
                {
                    Results.NotFound();
                }

                resources[index] = new ResourceDto(
                    id,
                    updatedResource.Name,
                    updatedResource.Quantity,
                    updatedResource.LocationId
                    
                );

                return Results.NoContent();
            });

            // DELETE /resource/1
            app.MapDelete("resources/{id}", (int id) =>
            {
                resources.RemoveAll(resource => resource.Id == id);

                return Results.NoContent();
            });

            return app;
        }
    }
}
