using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameLib.Core.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("c05e5498-4895-4121-aea3-10f95ceb5bbb"), "c05e5498-4895-4121-aea3-10f95ceb5bbb", "User", "USER" },
                    { new Guid("c80e3d0b-491a-4370-a426-72b85fef325a"), "c80e3d0b-491a-4370-a426-72b85fef325a", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("01387f69-0900-46f4-b1f7-3b3b5cca4670"), 0, "cff4a158-9492-49b5-8195-db62fa49545c", "admin@admin.com", true, "Admin", "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEBpuGFYZjvCeHg4aSmuGWeZGWNctJ09GQGFMvjGhZW2jABTk4j/hHPbMBa2xphuvog==", null, false, "2e106620-9b3e-4982-bdf2-ac6492e29f41", false, "admin@admin.com" },
                    { new Guid("2a3eabf3-388e-4d50-85c7-74bff223a455"), 0, "99e04f79-8c1f-448b-8f46-bb2fb86b858e", "user@gmail.com", true, "User", "User", false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEBvpwJdzG2wecIPrmBE6ST8lfLKOGSqicjhr8gCL+FXhY6Rk2tEjxVSodJ8M8HqjZw==", null, false, "7f462eb3-3322-48e6-9fa1-da968d5c61e1", false, "user@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("1370228b-24de-46d6-80ef-6297d951df3e"), "English" },
                    { new Guid("397578bd-26ae-486c-a18c-02f484451809"), "French" },
                    { new Guid("624e0dd1-8bb6-43fd-adde-602e135948f3"), "Polish" },
                    { new Guid("702dd9c5-5aa7-4642-8c3c-0cc1b6b7b3eb"), "Spanish" },
                    { new Guid("87d64510-dc96-4db6-a0ec-78eb0319048c"), "German" },
                    { new Guid("da63a26e-aade-4509-9762-1efa6bf7c181"), "Ukraine" },
                    { new Guid("f90ad6be-abce-4d3f-a8a0-e80d013709cb"), "Italian" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("c80e3d0b-491a-4370-a426-72b85fef325a"), new Guid("01387f69-0900-46f4-b1f7-3b3b5cca4670") },
                    { new Guid("c05e5498-4895-4121-aea3-10f95ceb5bbb"), new Guid("2a3eabf3-388e-4d50-85c7-74bff223a455") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c80e3d0b-491a-4370-a426-72b85fef325a"), new Guid("01387f69-0900-46f4-b1f7-3b3b5cca4670") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c05e5498-4895-4121-aea3-10f95ceb5bbb"), new Guid("2a3eabf3-388e-4d50-85c7-74bff223a455") });

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("1370228b-24de-46d6-80ef-6297d951df3e"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("397578bd-26ae-486c-a18c-02f484451809"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("624e0dd1-8bb6-43fd-adde-602e135948f3"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("702dd9c5-5aa7-4642-8c3c-0cc1b6b7b3eb"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("87d64510-dc96-4db6-a0ec-78eb0319048c"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("da63a26e-aade-4509-9762-1efa6bf7c181"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("f90ad6be-abce-4d3f-a8a0-e80d013709cb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c05e5498-4895-4121-aea3-10f95ceb5bbb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c80e3d0b-491a-4370-a426-72b85fef325a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("01387f69-0900-46f4-b1f7-3b3b5cca4670"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2a3eabf3-388e-4d50-85c7-74bff223a455"));

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
    }
}
