using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarterKit.Migrations
{
    /// <inheritdoc />
    public partial class be2bee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$FvtF.MayYxicTP/FbNNC8uw2wvFxa2gO00VffSvy7cWgEdkSSSrHu");
        }
    }
}
