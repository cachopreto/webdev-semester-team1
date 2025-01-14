using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarterKit.Migrations
{
    /// <inheritdoc />
    public partial class CreateAdminTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin",
                table: "Admin");

            migrationBuilder.RenameTable(
                name: "Admin",
                newName: "Admins");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_UserName",
                table: "Admins",
                newName: "IX_Admins_UserName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "AdminId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.RenameTable(
                name: "Admins",
                newName: "Admin");

            migrationBuilder.RenameIndex(
                name: "IX_Admins_UserName",
                table: "Admin",
                newName: "IX_Admin_UserName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin",
                table: "Admin",
                column: "AdminId");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "AdminId",
                keyValue: 1,
                column: "Password",
                value: "^�H��(qQ��o��)'s`=\rj���*�rB�");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "AdminId",
                keyValue: 2,
                column: "Password",
                value: "\\N@6��G��Ae=j_��a%0�QU��\\");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "AdminId",
                keyValue: 3,
                column: "Password",
                value: "�j\\��f������x�s+2��D�o���");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "AdminId",
                keyValue: 4,
                column: "Password",
                value: "�].��g��Պ��t��?��^�T��`aǳ");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "AdminId",
                keyValue: 5,
                column: "Password",
                value: "E�=���:�-����gd����bF��80]�");
        }
    }
}
