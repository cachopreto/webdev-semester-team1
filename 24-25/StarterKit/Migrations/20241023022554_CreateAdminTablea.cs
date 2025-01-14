using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarterKit.Migrations
{
    /// <inheritdoc />
    public partial class CreateAdminTablea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$U7XRf/wdUK2IrJ5lmAIXAujPoc0BuQqPWbswLzR4GLxrf4SW5vBDW");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$76dA2gsZIOmjYMJqIq2uBOrfZI2HCeDeGmu1VMCISJEqu3dOaoNJK");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$T.mcgsd0LEduDubllCOA/uBINWw1lByFH6xDAheyD2Ac6skhF0Jci");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$BEsDSG/zH3e.zpYglIO0uuBQNL1N5sWKFI7r2D1S2AfQAjqse7bfq");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$L7zYwlzBPMdTo2Ypww9ZMuRbLHxVdIaNPwZ9xEEjQ1UM6E0oZMhLu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$NVqwpQPVcm6VDKz4WkzxreSvPKAam3O/6jmLZO258MCiqV4FEVlVO");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$FkX2WlIEUQW0DbhkqXn3NOLpoZfSOBVGJ/2mvyOf7I03.SYRPqMSm");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$28D5ZHAnM8gdT.9eooX4sevYzN49xPsUJNY13jEyVTXg1nmwgYkfa");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$uJLac8FUmKVbEenIO.hye.Boy3nGqT0qc1U3T1/zm.neOPgOdXuDS");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$BmKy5wrHuWFRxWr0YgcvuuM96o6UNan1gxg/ZBZqUvPmLSbR52QIq");
        }
    }
}
