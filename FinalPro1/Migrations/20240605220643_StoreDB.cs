using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalPro1.Migrations
{
    /// <inheritdoc />
    public partial class StoreDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TableCOUNTYANDCITYs1111757",
                columns: table => new
                {
                    COU_CODE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    COU_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableCOUNTYANDCITYs1111757", x => x.COU_CODE);
                });

            migrationBuilder.CreateTable(
                name: "TableDISCOUNTs1111757",
                columns: table => new
                {
                    DIS_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DIS_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DIS_START = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DIS_END = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableDISCOUNTs1111757", x => x.DIS_ID);
                });

            migrationBuilder.CreateTable(
                name: "TableMEMBERSs1111757",
                columns: table => new
                {
                    MEM_ACCOUNT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MEM_PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MEM_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MEM_NICKNAME = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableMEMBERSs1111757", x => x.MEM_ACCOUNT);
                });

            migrationBuilder.CreateTable(
                name: "TableSTOREs1111757",
                columns: table => new
                {
                    STORE_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STORE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STORE_ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COU_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableSTOREs1111757", x => x.STORE_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableCOUNTYANDCITYs1111757");

            migrationBuilder.DropTable(
                name: "TableDISCOUNTs1111757");

            migrationBuilder.DropTable(
                name: "TableMEMBERSs1111757");

            migrationBuilder.DropTable(
                name: "TableSTOREs1111757");
        }
    }
}
