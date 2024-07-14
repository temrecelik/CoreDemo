using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Natifications",
                columns: table => new
                {
                    NatificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NatificationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NatificationTpeSymbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NatificationDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NatificationStatus = table.Column<bool>(type: "bit", nullable: false),
                    NatificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Natifications", x => x.NatificationId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Natifications");
        }
    }
}
