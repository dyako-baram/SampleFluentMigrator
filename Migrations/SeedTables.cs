using System;
using FluentMigrator;

namespace SampleFluentMigrator.Migrations
{
    [Migration(2, "Seeding tables")]
    public class SeedTables : Migration
    {
        public override void Down()
        {
            Delete.FromTable("Auther");
            Delete.FromTable("Book");
        }

        public override void Up()
        {
            var guidId=Guid.NewGuid();

            Insert.IntoTable("Auther").Row(new {
                    AutherId= guidId,
                    Name="john",
                    DOB=new DateTime(1977,5,12)
                });

            Insert.IntoTable("Book").Row(new {
                    BookId= Guid.NewGuid(),
                    BookName="pinokio",
                    AutherId=guidId
                });
            Insert.IntoTable("Book").Row(new {
                    BookId= Guid.NewGuid(),
                    BookName="snow white",
                    AutherId=guidId
                });
        }
    }
}