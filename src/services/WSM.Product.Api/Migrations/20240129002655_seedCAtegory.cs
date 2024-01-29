using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

#nullable disable

namespace WSM.Catalog.Api.Migrations
{
    /// <inheritdoc />
    public partial class seedCAtegory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO categories(name) VALUES ('Categoria 1'),('Categoria 2'),('Categoria 3'), ('Categoria 4'),('Categoria 5'),('Categoria 6'), ('Categoria 7'), ('Categoria 8'),('Categoria 9'),('Categoria 10'), ('Categoria 11'), ('Categoria 12'),  ('Categoria 13'),('Categoria 14')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
