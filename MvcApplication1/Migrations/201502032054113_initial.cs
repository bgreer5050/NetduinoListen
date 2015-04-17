namespace MvcApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MachineEvents", "assetID", c => c.String());
            AddColumn("dbo.MachineEvents", "state", c => c.String());
            AddColumn("dbo.MachineEvents", "ticks", c => c.String());
            DropColumn("dbo.MachineEvents", "MachineID");
            DropColumn("dbo.MachineEvents", "timeOfEvent");
            DropColumn("dbo.MachineEvents", "timeOfLastStateChange");
            DropColumn("dbo.MachineEvents", "numberOfBeatsSinceLastChange");
            DropColumn("dbo.MachineEvents", "systemState");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MachineEvents", "systemState", c => c.Int(nullable: false));
            AddColumn("dbo.MachineEvents", "numberOfBeatsSinceLastChange", c => c.Long(nullable: false));
            AddColumn("dbo.MachineEvents", "timeOfLastStateChange", c => c.DateTime(nullable: false));
            AddColumn("dbo.MachineEvents", "timeOfEvent", c => c.DateTime(nullable: false));
            AddColumn("dbo.MachineEvents", "MachineID", c => c.String());
            DropColumn("dbo.MachineEvents", "ticks");
            DropColumn("dbo.MachineEvents", "state");
            DropColumn("dbo.MachineEvents", "assetID");
        }
    }
}
