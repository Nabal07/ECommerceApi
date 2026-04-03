using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingProdutoEUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Descricao", "Nome", "Preco" },
                values: new object[,]
                {
                    { new Guid("71ca286f-f19b-4be1-b67c-01345d96763b"), "16gb", "Memoria RAM", 789m },
                    { new Guid("788a47aa-e189-4620-9e03-538502aa8814"), "RX580", "Placa de Video", 700m }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("1ba005be-e8f9-42dc-96c5-5bca0b5e1712"), "Joao" },
                    { new Guid("c74fd54f-cd3b-49d1-929f-98e7eedddda4"), "Maria" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("71ca286f-f19b-4be1-b67c-01345d96763b"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("788a47aa-e189-4620-9e03-538502aa8814"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("1ba005be-e8f9-42dc-96c5-5bca0b5e1712"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("c74fd54f-cd3b-49d1-929f-98e7eedddda4"));
        }
    }
}
