using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ResourceManagementSystem.Data;
using ResourceManagementSystem.Dtos;
using ResourceManagementSystem.Entities;

namespace ResourceManagementSystem.EndPoints
{
    public static class LocationsEndpoints
    {
        const string GetResourceEndpointName = "GetResource";

        public static WebApplication MapLocationsEndpoints(this WebApplication app)
        {
            // GET /locations
            app.MapGet("locations", (ResourceManagementContext dbContext) =>
            dbContext.Locations);

            

            return app;
        }
    }
}
