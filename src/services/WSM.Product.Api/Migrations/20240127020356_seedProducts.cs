using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WSM.Catalog.Api.Migrations
{
    /// <inheritdoc />
    public partial class seedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Products(Name,Price,description,stock,ImagenUrl,CategoryId) values('Caderno',7.55,'Caderno',10,'caderno.jpg',1)");
            migrationBuilder.Sql("Insert into Products(Name,Price,description,stock,ImagenUrl,CategoryId) values('Lápis',3.45,'Lápis preto',20,'lapis1.jpg',1)");
            migrationBuilder.Sql("Insert into Products(Name,Price,description,stock,ImagenUrl,CategoryId) values('Clips',5.23,'Clips para papel',50,'clips.jpg',2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Products");
        }
    }
}
