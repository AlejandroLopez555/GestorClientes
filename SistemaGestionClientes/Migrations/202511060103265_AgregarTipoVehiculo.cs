namespace SistemaGestionClientes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarTipoVehiculo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "TipoVehiculo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "TipoVehiculo");
        }
    }
}
