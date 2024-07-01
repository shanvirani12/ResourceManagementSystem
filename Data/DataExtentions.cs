﻿using Microsoft.EntityFrameworkCore;

namespace ResourceManagementSystem.Data
{
    public static class DataExtentions
    {
        public static void MigrateDb(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ResourceManagementContext>();
            dbContext.Database.Migrate();
        }
    }
}
