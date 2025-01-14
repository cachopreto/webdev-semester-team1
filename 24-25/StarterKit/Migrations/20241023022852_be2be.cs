using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarterKit.Migrations
{
    /// <inheritdoc />
    public partial class be2be : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$mewnI3FzC3lgjP2yuuTNZ.o5DSo76ieGJlemd69srATo7m5Fys7W6");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$Pb/APnOzGl9xHJmWY9097u3iClMp6J7Ra/th46D2cbIp2YvIZP/2i");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$BKLKs.0QxYX1fuNVP6SBNOkagpXp68mmA6BKi5ApbpbgAcPqYiQTu");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$Uu1a1yaRSQ2Bobdx5nxu3O7u/hh03XQvWhS8lR46PoiXZzAXPCGBm");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$1UDpcm55LjM26Mpxl/AVXu6cDkuoHcmROG6.TBPo2BTXYAGo5wk6K");

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminId", "Email", "Password", "UserName" },
                values: new object[] { 6, "admin6@example.com", "$2a$11$FvtF.MayYxicTP/FbNNC8uw2wvFxa2gO00VffSvy7cWgEdkSSSrHu", "bisho" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 6);

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
    }
}
