using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameLib.Core.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_AspNetUsers_UserId",
                table: "Ratings");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Ratings",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("4032bbe1-0f97-4471-b9d0-c87a5b633daf"), "4032bbe1-0f97-4471-b9d0-c87a5b633daf", "Admin", "ADMIN" },
                    { new Guid("6ce756e1-ad31-4ac5-8330-96ca9b992b14"), "6ce756e1-ad31-4ac5-8330-96ca9b992b14", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("cb12f56c-43ad-4155-809e-423234118125"), 0, "755644bf-f39b-47b6-9e03-eb191716763f", "user@gmail.com", true, "User", "User", false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEAtGql7B0ScFuyTcXaSeULEy7VzcRwVyFq4+DB+eiM8MK4AEv88AQzBtaqls6F9dTQ==", null, false, "f57840fa-1ef0-40b5-9c64-e552f15209cf", false, "user@gmail.com" },
                    { new Guid("e9664af5-2201-4038-930d-a79ae1dafde1"), 0, "1cc2b1c9-4c96-4d1c-9789-faa33fc3969c", "admin@admin.com", true, "Admin", "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEGoU0IEkI7dQbPJk5fy4oEz8PNENPU3O7Y8wA1fO6auZ4KixXIparawo9fUAw0PknQ==", null, false, "ae9aa43a-0cff-4cb3-9249-73db140647ac", false, "admin@admin.com" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("8b81aa92-d048-4eaa-bb74-01292c0ceb35"), "German" },
                    { new Guid("8c0c890d-22cf-4dce-863f-08bc8e1358b8"), "Polish" },
                    { new Guid("95f7628e-c0ca-4aa6-95af-7c3dbcef4354"), "Spanish" },
                    { new Guid("c746e809-0c99-4699-ae2c-5647d86f2206"), "Ukraine" },
                    { new Guid("e8de1d49-379e-4070-b063-625754febd5b"), "Italian" },
                    { new Guid("f2528f03-20bc-4704-acf3-7632dd697dd0"), "English" },
                    { new Guid("f5832c9c-62a2-437b-8cc3-4a5b1fc1644f"), "French" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("6ce756e1-ad31-4ac5-8330-96ca9b992b14"), new Guid("cb12f56c-43ad-4155-809e-423234118125") },
                    { new Guid("4032bbe1-0f97-4471-b9d0-c87a5b633daf"), new Guid("e9664af5-2201-4038-930d-a79ae1dafde1") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_AspNetUsers_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_AspNetUsers_UserId",
                table: "Ratings");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6ce756e1-ad31-4ac5-8330-96ca9b992b14"), new Guid("cb12f56c-43ad-4155-809e-423234118125") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4032bbe1-0f97-4471-b9d0-c87a5b633daf"), new Guid("e9664af5-2201-4038-930d-a79ae1dafde1") });

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("8b81aa92-d048-4eaa-bb74-01292c0ceb35"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("8c0c890d-22cf-4dce-863f-08bc8e1358b8"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("95f7628e-c0ca-4aa6-95af-7c3dbcef4354"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("c746e809-0c99-4699-ae2c-5647d86f2206"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("e8de1d49-379e-4070-b063-625754febd5b"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("f2528f03-20bc-4704-acf3-7632dd697dd0"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("f5832c9c-62a2-437b-8cc3-4a5b1fc1644f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4032bbe1-0f97-4471-b9d0-c87a5b633daf"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6ce756e1-ad31-4ac5-8330-96ca9b992b14"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb12f56c-43ad-4155-809e-423234118125"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9664af5-2201-4038-930d-a79ae1dafde1"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Ratings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_AspNetUsers_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
