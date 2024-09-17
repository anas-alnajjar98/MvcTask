namespace CodeFirstTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addimgTousertable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "img", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "img");
        }
    }
}
