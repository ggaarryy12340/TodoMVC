namespace TodoMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Todoes", "CreateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Todoes", "CreateTime");
        }
    }
}
