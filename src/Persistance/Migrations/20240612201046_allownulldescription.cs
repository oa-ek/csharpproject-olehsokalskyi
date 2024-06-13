using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class allownulldescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("1b2d9e7e-8e22-44a8-85fa-d7627c4483b1"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("27b60c7a-05d0-4cb3-af0b-5c4dbe0a0aca"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("2efd91ee-08d8-46b7-9a84-e2e18a955cd0"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("4e0ba3c5-234a-46ba-ae20-c0ee179a3c68"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("706e9787-1929-4f94-81d0-bee762e91c65"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("838dcc9e-ba9e-4466-809b-648e926f33cd"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("acf1978c-271c-4c0c-8a06-8b7ee39bb92b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0fbfbeee-0ceb-4288-8a6f-868d127bfc68"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b1a83fb1-f838-46a4-89c8-bec2d0d76a58"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("148aaa29-f137-44f7-b0a4-6391a34579de"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cddc2965-5cbf-41c9-b7f8-fd1e55ab181e"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Developers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("1af757cd-a85f-4132-b7db-b9abe86d4848"), "Spanish" },
                    { new Guid("39ac08c4-5538-41b3-9642-7d4953637b9d"), "Polish" },
                    { new Guid("5264577d-51de-4a15-bf57-7697a238b0f0"), "French" },
                    { new Guid("5bfe3e53-6abb-4351-bd98-0f3b96cde09d"), "Italian" },
                    { new Guid("7c8e862c-b7d4-4ae2-bdf4-a3ca9187adf2"), "Ukraine" },
                    { new Guid("8ea14626-e9fc-4c5f-a857-1705a57ca518"), "English" },
                    { new Guid("91b524fd-7a2e-49e3-9045-35087ecb4f05"), "German" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("04b93a99-7f05-490c-8b65-233d93af17a8"), "Admin" },
                    { new Guid("5af06273-1ec8-40b6-9e41-9edca8019b04"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "RoleId", "UserName" },
                values: new object[,]
                {
                    { new Guid("ddf1a01f-09ff-4dba-8cbe-71b19a0108ca"), "user@gmail.com", "User", "User", "$argon2id$v=19$m=65536,t=3,p=1$qeFiK6Jl6H04+Dl6BKsTCg$+BwGUX8lElCYi7ter8x5CSe/QpD0Xz7YJc5qJ0iU/YU", new Guid("5af06273-1ec8-40b6-9e41-9edca8019b04"), "user@gmail.com" },
                    { new Guid("faf445bc-902c-4b07-86e0-5c59da6c554f"), "admin@admin.com", "Admin", "Admin", "$argon2id$v=19$m=65536,t=3,p=1$Y/Evr2UMRpxc81SaUsoCWw$cQzWf8rcg8L/g0yC8asUtZzlTE2QRyzTnnZmzp4gukY", new Guid("04b93a99-7f05-490c-8b65-233d93af17a8"), "admin@admin.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("1af757cd-a85f-4132-b7db-b9abe86d4848"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("39ac08c4-5538-41b3-9642-7d4953637b9d"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("5264577d-51de-4a15-bf57-7697a238b0f0"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("5bfe3e53-6abb-4351-bd98-0f3b96cde09d"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("7c8e862c-b7d4-4ae2-bdf4-a3ca9187adf2"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("8ea14626-e9fc-4c5f-a857-1705a57ca518"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("91b524fd-7a2e-49e3-9045-35087ecb4f05"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ddf1a01f-09ff-4dba-8cbe-71b19a0108ca"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("faf445bc-902c-4b07-86e0-5c59da6c554f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("04b93a99-7f05-490c-8b65-233d93af17a8"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5af06273-1ec8-40b6-9e41-9edca8019b04"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Developers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("1b2d9e7e-8e22-44a8-85fa-d7627c4483b1"), "Italian" },
                    { new Guid("27b60c7a-05d0-4cb3-af0b-5c4dbe0a0aca"), "English" },
                    { new Guid("2efd91ee-08d8-46b7-9a84-e2e18a955cd0"), "Polish" },
                    { new Guid("4e0ba3c5-234a-46ba-ae20-c0ee179a3c68"), "Spanish" },
                    { new Guid("706e9787-1929-4f94-81d0-bee762e91c65"), "Ukraine" },
                    { new Guid("838dcc9e-ba9e-4466-809b-648e926f33cd"), "French" },
                    { new Guid("acf1978c-271c-4c0c-8a06-8b7ee39bb92b"), "German" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("148aaa29-f137-44f7-b0a4-6391a34579de"), "Admin" },
                    { new Guid("cddc2965-5cbf-41c9-b7f8-fd1e55ab181e"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "RoleId", "UserName" },
                values: new object[,]
                {
                    { new Guid("0fbfbeee-0ceb-4288-8a6f-868d127bfc68"), "user@gmail.com", "User", "User", "$argon2id$v=19$m=65536,t=3,p=1$8YN9LcXC6rbhnEVRK5xQiQ$s1uflgqtRotBNiGMvlmVIOAnJShHeMwTkwGtWlFoXGQ", new Guid("cddc2965-5cbf-41c9-b7f8-fd1e55ab181e"), "user@gmail.com" },
                    { new Guid("b1a83fb1-f838-46a4-89c8-bec2d0d76a58"), "admin@admin.com", "Admin", "Admin", "$argon2id$v=19$m=65536,t=3,p=1$/ubqcDdePna/ypanZQj8bQ$o4W5vUbxzjSgoLknkcuEveRvv+j8e4iExhD/KUpRAg8", new Guid("148aaa29-f137-44f7-b0a4-6391a34579de"), "admin@admin.com" }
                });
        }
    }
}
