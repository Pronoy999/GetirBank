using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace GetirBank.Migrations
{
    public partial class AddCredentialsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Transaction",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 21, 15, 22, 48, 757, DateTimeKind.Local).AddTicks(5270),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 1, 21, 13, 11, 57, 378, DateTimeKind.Local).AddTicks(9590));

            migrationBuilder.AlterColumn<string>(
                name: "EmailId",
                table: "Customer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Customer",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 21, 15, 22, 48, 458, DateTimeKind.Local).AddTicks(3130),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 1, 21, 13, 11, 57, 175, DateTimeKind.Local).AddTicks(7360));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Account",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 21, 15, 22, 48, 756, DateTimeKind.Local).AddTicks(5360),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 1, 21, 13, 11, 57, 377, DateTimeKind.Local).AddTicks(9570));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Customer_EmailId",
                table: "Customer",
                column: "EmailId");

            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2022, 1, 21, 15, 22, 48, 769, DateTimeKind.Local).AddTicks(5290))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credentials_Customer_Email",
                        column: x => x.Email,
                        principalTable: "Customer",
                        principalColumn: "EmailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_Email",
                table: "Credentials",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credentials");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Customer_EmailId",
                table: "Customer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Transaction",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 21, 13, 11, 57, 378, DateTimeKind.Local).AddTicks(9590),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 1, 21, 15, 22, 48, 757, DateTimeKind.Local).AddTicks(5270));

            migrationBuilder.AlterColumn<string>(
                name: "EmailId",
                table: "Customer",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Customer",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 21, 13, 11, 57, 175, DateTimeKind.Local).AddTicks(7360),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 1, 21, 15, 22, 48, 458, DateTimeKind.Local).AddTicks(3130));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Account",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 21, 13, 11, 57, 377, DateTimeKind.Local).AddTicks(9570),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 1, 21, 15, 22, 48, 756, DateTimeKind.Local).AddTicks(5360));
        }
    }
}
