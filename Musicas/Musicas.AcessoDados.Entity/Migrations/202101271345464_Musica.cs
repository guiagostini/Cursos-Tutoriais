namespace Musicas.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Musica : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.MUS_MUSICAS");
            AlterColumn("dbo.MUS_MUSICAS", "MUS_ID", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.MUS_MUSICAS", "MUS_ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.MUS_MUSICAS");
            AlterColumn("dbo.MUS_MUSICAS", "MUS_ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.MUS_MUSICAS", "MUS_ID");
        }
    }
}
