using FluentMigrator;

namespace SampleFluentMigrator.Migrations
{
    [Migration(1,"Table Creation")]
    public class CreateTables : Migration
    {
        public override void Down()
        {
            Delete.Table("Auther");
            Delete.Table("Book");
        }

        public override void Up()
        {
            Create.Table("Auther")
                .WithColumn("AutherId").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("DOB").AsDateTime2().NotNullable();
            
            Create.Table("Book")
                .WithColumn("BookId").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("BookName").AsString(50).NotNullable()
                .WithColumn("AutherId").AsGuid().ForeignKey("Auther","AutherId");
        }
    }
}