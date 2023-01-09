using Experience_wtih_Dapper.Migrations;
using FluentMigrator.Runner;
using System.Runtime.CompilerServices;

namespace Experience_wtih_Dapper.Extensions
{
    public static class MigrationManager
    {

        public static IHost MigrateDatabase(this IHost host)
        {
            using(var scope=host.Services.CreateScope())
            {
                var databaseService = scope.ServiceProvider.GetRequiredService<Database>();
                var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();



                try
                {
                   // databaseService.CreateDatabase("DapperMigrationExample");

                   migrationService.ListMigrations();
                   migrationService.MigrateUp();



                }
                catch
                {
                    throw;
                }



            }
            return host;
        }
    }
}
