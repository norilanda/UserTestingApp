using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserTestingApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "expedita" },
                    { 2L, "delectus" },
                    { 3L, "laboriosam" },
                    { 4L, "et" },
                    { 5L, "est" },
                    { 6L, "quaerat" },
                    { 7L, "quia" },
                    { 8L, "voluptatem" },
                    { 9L, "nesciunt" },
                    { 10L, "quidem" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Salt", "Username" },
                values: new object[,]
                {
                    { 1L, "6BADBF3C5842C748C4F30513DFA5F20E4232CAC44531FA0FA95D42D0C04AC53C22E746A9E2E19AC1B51BF6BE2628202449F8BC4163A0C0FECF5DED8654B4203A", "vEUXIxlvdvOfWB3rHBkCqhhcADEQv96KACIOWYfFAwgmsYPVExj6i859J/4B9LFPnj4683Q3lBM0267m0ROpug==", "user2" },
                    { 2L, "302AECE75676893D130FD93E28666BCCA91F14222BBD26EDC79D6E6355A5FBA2CF3F79296FCCB94ACE016A491AC1D89C460FC823D568004DF28752EEC266BD03", "vEUXIxlvdvOfWB3rHBkCqhhcADEQv96KACIOWYfFAwgmsYPVExj6i859J/4B9LFPnj4683Q3lBM0267m0ROpug==", "user3" },
                    { 3L, "AC5ACFF90B2C8FC1FACBE05703956C7AA5084DEB19FCEB0D4F9402817C89826DDB9610F27A7F54BEC9DDBAC303697B032CB3025636D5AA2C9887950C594BBA68", "vEUXIxlvdvOfWB3rHBkCqhhcADEQv96KACIOWYfFAwgmsYPVExj6i859J/4B9LFPnj4683Q3lBM0267m0ROpug==", "user4" }
                });

            migrationBuilder.InsertData(
                table: "AssignedTests",
                columns: new[] { "Id", "DateCompleted", "Mark", "TestId", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 9, 11, 21, 28, 29, 846, DateTimeKind.Local).AddTicks(4499), 2.0, 1L, 1L },
                    { 2L, null, null, 2L, 1L },
                    { 3L, new DateTime(2023, 7, 16, 7, 47, 39, 60, DateTimeKind.Local).AddTicks(5043), 3.0, 3L, 1L },
                    { 4L, null, null, 4L, 1L },
                    { 5L, new DateTime(2023, 5, 18, 20, 29, 52, 277, DateTimeKind.Local).AddTicks(7308), 1.0, 5L, 1L },
                    { 6L, null, null, 6L, 1L },
                    { 7L, new DateTime(2023, 5, 8, 1, 26, 30, 658, DateTimeKind.Local).AddTicks(6719), 1.0, 1L, 2L },
                    { 8L, null, null, 2L, 2L },
                    { 9L, new DateTime(2023, 7, 24, 18, 46, 4, 828, DateTimeKind.Local).AddTicks(5935), 3.0, 3L, 2L },
                    { 10L, null, null, 1L, 3L },
                    { 11L, new DateTime(2023, 3, 9, 7, 10, 51, 704, DateTimeKind.Local).AddTicks(7832), 3.0, 2L, 3L },
                    { 12L, null, null, 3L, 3L }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Answer", "Number", "Question", "TestId" },
                values: new object[,]
                {
                    { 1L, "3", 1, "2 + 1 =", 1L },
                    { 2L, "4", 1, "3 + 1 =", 2L },
                    { 3L, "5", 1, "4 + 1 =", 3L },
                    { 4L, "6", 1, "5 + 1 =", 4L },
                    { 5L, "7", 2, "6 + 1 =", 4L },
                    { 6L, "8", 1, "7 + 1 =", 5L },
                    { 7L, "9", 2, "8 + 1 =", 5L },
                    { 8L, "10", 1, "9 + 1 =", 6L },
                    { 9L, "11", 1, "10 + 1 =", 7L },
                    { 10L, "12", 2, "11 + 1 =", 7L },
                    { 11L, "13", 1, "12 + 1 =", 8L },
                    { 12L, "14", 1, "13 + 1 =", 9L },
                    { 13L, "15", 2, "14 + 1 =", 9L },
                    { 14L, "16", 1, "15 + 1 =", 10L },
                    { 15L, "17", 2, "16 + 1 =", 10L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
