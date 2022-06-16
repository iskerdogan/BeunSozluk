namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_admin_name_surname_ımage_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminName", c => c.String(maxLength: 50));
            AddColumn("dbo.Admins", "AdminSurname", c => c.String(maxLength: 50));
            AddColumn("dbo.Admins", "AdminImage", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "AdminImage");
            DropColumn("dbo.Admins", "AdminSurname");
            DropColumn("dbo.Admins", "AdminName");
        }
    }
}
