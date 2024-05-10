using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameLib.Core.Migrations
{
    /// <inheritdoc />
    public partial class cascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d43a160d-df57-489c-97f2-3e39920df5c5"), new Guid("5a9a7b85-940a-4a66-abb2-8448076756a8") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("bd6eac7e-4b89-4d8d-a4ef-9341f7f0a978"), new Guid("cb8b8ce7-25c3-43bb-8c11-4540f059c4f8") });

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("2cacfe17-4e59-49d5-a713-5071189364e8"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("53a9ef99-4993-461b-8442-e0fa5c13edc1"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("75ff1781-d93f-4726-87d9-6213ecb81c57"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("7da0ff8b-ca2c-4b1b-9419-99892d7d63bb"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("7e4d30ac-bec4-462a-91ad-203161a1facf"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("abaa6a58-c707-44f3-8fc4-9b6d26394de6"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("bff3b3c7-4a13-4959-87b1-eb9224e0682f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bd6eac7e-4b89-4d8d-a4ef-9341f7f0a978"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d43a160d-df57-489c-97f2-3e39920df5c5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5a9a7b85-940a-4a66-abb2-8448076756a8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb8b8ce7-25c3-43bb-8c11-4540f059c4f8"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2e953341-fb4e-42cd-ae13-25f149452763"), "2e953341-fb4e-42cd-ae13-25f149452763", "Admin", "ADMIN" },
                    { new Guid("debc04cc-ce1e-467e-8777-df14e62d280d"), "debc04cc-ce1e-467e-8777-df14e62d280d", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("5ce263dc-658f-41a0-9f82-c58de42b8da4"), 0, "21fbf1b1-b739-4721-9dd8-b69e85ba483e", "admin@admin.com", true, "Admin", "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEPaRL0U+L/zTVzdT2sTfFQAsgPuxGVvdnEJcYPyWpEOkCqB80hc5Ziou8OQecDPHrQ==", null, false, "4507f728-1388-4522-ade3-a20ca83558c1", false, "admin@admin.com" },
                    { new Guid("ed86e99f-476f-4b6f-83c1-52a568d580bc"), 0, "e981a113-d4bd-4ddd-9e76-0dbb87cb97f8", "user@gmail.com", true, "User", "User", false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEGi+Wj9X3YgQOqKtnohgdwzECNpvDZhRHcbEG+FlMgiOyVFmpCJEFSyGWTjN/3znMg==", null, false, "78f5c099-ab15-4929-bb4f-c0daf30e3b9e", false, "user@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("2445c815-1d5c-4102-b090-fd284408f652"), "German" },
                    { new Guid("308a49a7-575c-4305-97b4-1567ead3cccc"), "English" },
                    { new Guid("57423b36-9c36-419e-8ba7-93b78796087c"), "Spanish" },
                    { new Guid("5b42d313-487f-414c-bcdb-743936eff491"), "Ukraine" },
                    { new Guid("c5873556-5a47-46a8-9571-3c0847247efb"), "French" },
                    { new Guid("e6866164-62fa-4b99-b300-0bcc65595c1e"), "Polish" },
                    { new Guid("f94bbf11-463a-4c5e-8f34-84cf7c144312"), "Italian" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2e953341-fb4e-42cd-ae13-25f149452763"), new Guid("5ce263dc-658f-41a0-9f82-c58de42b8da4") },
                    { new Guid("debc04cc-ce1e-467e-8777-df14e62d280d"), new Guid("ed86e99f-476f-4b6f-83c1-52a568d580bc") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2e953341-fb4e-42cd-ae13-25f149452763"), new Guid("5ce263dc-658f-41a0-9f82-c58de42b8da4") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("debc04cc-ce1e-467e-8777-df14e62d280d"), new Guid("ed86e99f-476f-4b6f-83c1-52a568d580bc") });

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("2445c815-1d5c-4102-b090-fd284408f652"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("308a49a7-575c-4305-97b4-1567ead3cccc"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("57423b36-9c36-419e-8ba7-93b78796087c"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("5b42d313-487f-414c-bcdb-743936eff491"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("c5873556-5a47-46a8-9571-3c0847247efb"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("e6866164-62fa-4b99-b300-0bcc65595c1e"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("f94bbf11-463a-4c5e-8f34-84cf7c144312"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2e953341-fb4e-42cd-ae13-25f149452763"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("debc04cc-ce1e-467e-8777-df14e62d280d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5ce263dc-658f-41a0-9f82-c58de42b8da4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed86e99f-476f-4b6f-83c1-52a568d580bc"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("bd6eac7e-4b89-4d8d-a4ef-9341f7f0a978"), "bd6eac7e-4b89-4d8d-a4ef-9341f7f0a978", "Admin", "ADMIN" },
                    { new Guid("d43a160d-df57-489c-97f2-3e39920df5c5"), "d43a160d-df57-489c-97f2-3e39920df5c5", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("5a9a7b85-940a-4a66-abb2-8448076756a8"), 0, "e163b5ef-29fb-4bbb-baf5-990a6af7a138", "user@gmail.com", true, "User", "User", false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEFBqX5Hjvigr9yJtu8NwGGbsfR5KaJDGJ+Z3IB/bR2W/TZbTSw5MeegHxrSzA3pCzw==", null, false, "804b1c46-91d0-4e3b-ae7b-7dd68ea17c6b", false, "user@gmail.com" },
                    { new Guid("cb8b8ce7-25c3-43bb-8c11-4540f059c4f8"), 0, "9e79662e-f7e5-420c-ab46-5551542cec08", "admin@admin.com", true, "Admin", "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAED+TAY7si6tnExQzooRhziv2WWbvA4Cde1a+sTVYLbPWp5JP4UQ2aKDRSdb4ZIJB5w==", null, false, "220feb9d-9721-4d43-a4db-9eded551d643", false, "admin@admin.com" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("2cacfe17-4e59-49d5-a713-5071189364e8"), "Spanish" },
                    { new Guid("53a9ef99-4993-461b-8442-e0fa5c13edc1"), "Italian" },
                    { new Guid("75ff1781-d93f-4726-87d9-6213ecb81c57"), "English" },
                    { new Guid("7da0ff8b-ca2c-4b1b-9419-99892d7d63bb"), "French" },
                    { new Guid("7e4d30ac-bec4-462a-91ad-203161a1facf"), "Polish" },
                    { new Guid("abaa6a58-c707-44f3-8fc4-9b6d26394de6"), "German" },
                    { new Guid("bff3b3c7-4a13-4959-87b1-eb9224e0682f"), "Ukraine" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("d43a160d-df57-489c-97f2-3e39920df5c5"), new Guid("5a9a7b85-940a-4a66-abb2-8448076756a8") },
                    { new Guid("bd6eac7e-4b89-4d8d-a4ef-9341f7f0a978"), new Guid("cb8b8ce7-25c3-43bb-8c11-4540f059c4f8") }
                });
        }
    }
}
