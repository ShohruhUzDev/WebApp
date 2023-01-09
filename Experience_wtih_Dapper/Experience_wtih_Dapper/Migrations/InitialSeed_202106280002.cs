using Experience_wtih_Dapper.Entities;
using FluentMigrator;
using System.Collections.Generic;

namespace Experience_wtih_Dapper.Migrations
{
    [Migration(202106280002)]
    public class InitialSeed_202106280002 : Migration
    {
        public override void Down()
        {
            Delete.FromTable("Employees")
                .Row(new Employee
                {
                    Id = 1,
                    Age = 34,
                    Name = "Test Employee",
                    Position = "Test Position",
                    CompanyId = 1
                });

            Delete.FromTable("Companies")
                .Row(new Company
                {
                    Id = 1,
                    Address = "Test Address",
                    Country = "USA",
                    Name = "Test Name"
                });
        }

        public override void Up()
        {
            Insert.IntoTable("Companies")
                .Row(new Company
                {
                    Id = 1,
                    Address = "Test Address",
                    Country = "USA",
                    Name = "Test Name"
                });

            Insert.IntoTable("Employees")
                .Row(new Employee
                {
                    Id = 2,
                    Age = 34,
                    Name = "Test Employee",
                    Position = "Test Position",
                    CompanyId = 1
                });
        }
    }
}
