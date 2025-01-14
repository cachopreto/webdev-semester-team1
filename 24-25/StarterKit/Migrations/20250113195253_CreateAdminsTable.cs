using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarterKit.Migrations
{
    /// <inheritdoc />
    public partial class CreateAdminsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$cGkaBlMnjNaXYnd3JpDeTOZqDdDdh8eB1lpo9IbCctrbzqr1mLBzm");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$NDMuJnu3IUu/I8dE2tRMaOtj9stQZWL6IDSwcVaU2gN6AIJ5mhwb.");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$EaCSGGXJa5WK6Aknd5Fzg.86R0F2ZJbqzeLl7zJ0yFi1F1fmxbk7m");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$zXwrdOLP/eda9MZaa4fhz.ztO7rxaR4.OW4WzB7B83qMJscASlota");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$A6bW83oatCFcoNbt4pGrgOQd6k4IgOlaAq8I09KJWV2IFYq9ugh2G");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$8h59.HYIuCkmlD4Ht2jgCOLIarsAtd8DPE5aPBKMlE7mCcp/QAal6");

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminId", "Email", "Password", "UserName" },
                values: new object[] { 7, "admin7@example.com", "$2a$11$1NaSczNvByy7izJ7xw/zWu.ajJIAmCW8Q.2ZpiRmatV0HeChqFrem", "admin7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 7);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$L8H/yU73QthlhL0ARB1Z/es7/gDJxyHywFDLAKvOT7vQ7gZca1sKW");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$4.96j9ZqKEWFgOQkDJOzeuKlVN2eGGzTTt8W6RTIDwhZm2yKeZ2LK");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$cjDh6/TUTQhZC7ZQQtGA8uV/4rqiRiHvyJa0imNQZN57934RRIp8e");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$uv2u80WLS8IG9.oRfCqxGODDI1ZX/rC6VJaQn9.xDbkNnwLFbZLCC");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$7iuN80EODYLd5LAK6ywaM.jD67/uxhkRLe554h3p4rSlqGUsz/kQe");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$NqofbYOxHyakWsmkBHEfEuDh73MYtZ2jCawqfj1sM/CK3C0Xtgt/i");
        }
    }
}
