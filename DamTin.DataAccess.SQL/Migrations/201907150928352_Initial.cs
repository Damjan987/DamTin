namespace DamTin.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tourists",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 30),
                        Lastname = c.String(maxLength: 30),
                        Email = c.String(maxLength: 50),
                        PhoneNumber = c.String(),
                        NumberOfDays = c.Int(nullable: false),
                        DateOfComming = c.DateTime(nullable: false),
                        DateOfLeaving = c.DateTime(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tourists");
        }
    }
}
