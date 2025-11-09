namespace SistemaGestionClientes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteID = c.Int(nullable: false, identity: true),
                        NombreCompleto = c.String(nullable: false, maxLength: 100),
                        Telefono = c.String(nullable: false, maxLength: 15),
                        Correo = c.String(nullable: false),
                        Vehiculo = c.String(nullable: false, maxLength: 50),
                        FechaRegistro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clientes");
        }
    }
}
