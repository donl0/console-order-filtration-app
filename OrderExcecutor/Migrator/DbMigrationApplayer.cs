using Infrastructure.Db.Interface;
using Infrastructure.Db;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace OrderExcecutor.Migrator
{
    public static class DbMigrationApplayer
    {
        public async static Task MakeMigrationsAsync(this IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                OrderDbContext dbContext = (OrderDbContext)scope.ServiceProvider.GetRequiredService<IDbContext>();
                var migrator = dbContext.Database.GetService<IMigrator>();
                await migrator.MigrateAsync();
            }
        }
    }
}
