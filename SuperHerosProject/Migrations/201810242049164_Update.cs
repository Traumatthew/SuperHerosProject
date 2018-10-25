namespace SuperHerosProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Superheroes", newName: "Superheros");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Superheros", newName: "Superheroes");
        }
    }
}
