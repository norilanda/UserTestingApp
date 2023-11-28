using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserTestingApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class StrongerPasswordGeneration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.UpdateData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCompleted", "Mark" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 58, 35, 193, DateTimeKind.Local).AddTicks(7230), 3.0 });

            migrationBuilder.UpdateData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateCompleted",
                value: new DateTime(2022, 12, 14, 4, 49, 57, 324, DateTimeKind.Local).AddTicks(7250));

            migrationBuilder.UpdateData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCompleted", "Mark" },
                values: new object[] { new DateTime(2023, 11, 12, 17, 0, 59, 849, DateTimeKind.Local).AddTicks(4126), 3.0 });

            migrationBuilder.UpdateData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DateCompleted",
                value: new DateTime(2023, 5, 13, 10, 19, 8, 659, DateTimeKind.Local).AddTicks(1954));

            migrationBuilder.UpdateData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateCompleted", "Mark" },
                values: new object[] { new DateTime(2023, 4, 3, 10, 47, 37, 314, DateTimeKind.Local).AddTicks(90), 2.0 });

            migrationBuilder.UpdateData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "TestId", "UserId" },
                values: new object[] { 4L, 2L });

            migrationBuilder.UpdateData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "DateCompleted", "TestId", "UserId" },
                values: new object[] { new DateTime(2023, 2, 8, 10, 9, 31, 39, DateTimeKind.Local).AddTicks(5950), 5L, 2L });

            migrationBuilder.UpdateData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "TestId", "UserId" },
                values: new object[] { 6L, 2L });

            migrationBuilder.InsertData(
                table: "AssignedTests",
                columns: new[] { "Id", "DateCompleted", "Mark", "TestId", "UserId" },
                values: new object[,]
                {
                    { 13L, new DateTime(2023, 3, 8, 1, 4, 4, 804, DateTimeKind.Local).AddTicks(7544), 2.0, 1L, 3L },
                    { 14L, null, null, 2L, 3L },
                    { 15L, new DateTime(2022, 12, 10, 3, 57, 46, 575, DateTimeKind.Local).AddTicks(2195), 2.0, 3L, 3L },
                    { 16L, null, null, 4L, 3L },
                    { 17L, new DateTime(2022, 11, 30, 5, 50, 50, 334, DateTimeKind.Local).AddTicks(3866), 2.0, 5L, 3L }
                });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Number", "TestId" },
                values: new object[] { 2, 2L });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4L,
                column: "TestId",
                value: 3L);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5L,
                column: "TestId",
                value: 3L);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6L,
                column: "TestId",
                value: 4L);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Number",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "Number", "TestId" },
                values: new object[] { 1, 8L });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11L,
                column: "TestId",
                value: 9L);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12L,
                column: "TestId",
                value: 10L);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 13L,
                column: "TestId",
                value: 10L);

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Name",
                value: "facere");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Name",
                value: "cupiditate");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Name",
                value: "tenetur");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Name",
                value: "qui");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Name",
                value: "doloribus");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Name",
                value: "maiores");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Name",
                value: "maiores");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Name",
                value: "nemo");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 9L,
                column: "Name",
                value: "voluptate");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 10L,
                column: "Name",
                value: "voluptates");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "7519580C03D32CD1F057FFAF49931124B10239EF574115EA5516C92CDD347B7F530A888BCB307637EED1BFC9FD34ECA78645BA8DDC9ECD5152C5CA1558B212BA", "OJAhltlnFgZDK3UHjzncisJRiNwrg31opSmQm1H9LZuhD+bjhR9cR1RFOgAUDB3yP+M0j+aMm+ipPwW1pAd8zg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "34A84DE7F8C3915BCC23490CB6C3AEC19BB233E4194A73FF8AECA1514D138481768E09DDBBF4ACDB02A8F0EDFC2AB7E761373FB34F1F2C9445593C41461897D9", "OJAhltlnFgZDK3UHjzncisJRiNwrg31opSmQm1H9LZuhD+bjhR9cR1RFOgAUDB3yP+M0j+aMm+ipPwW1pAd8zg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "1281D424C197862D09CE4F3621EACBB8E93FBAEC239F2BCB1E8E8C55EEC29B9FA631DDFF68D67BCF5FB98E8FCC11BD0DE6E4A5218D01077CD7270399E0AA907F", "OJAhltlnFgZDK3UHjzncisJRiNwrg31opSmQm1H9LZuhD+bjhR9cR1RFOgAUDB3yP+M0j+aMm+ipPwW1pAd8zg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.UpdateData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCompleted", "Mark" },
                values: new object[] { new DateTime(2023, 9, 11, 21, 28, 29, 846, DateTimeKind.Local).AddTicks(4499), 2.0 });

            migrationBuilder.UpdateData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateCompleted",
                value: new DateTime(2023, 7, 16, 7, 47, 39, 60, DateTimeKind.Local).AddTicks(5043));

            migrationBuilder.UpdateData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DateCompleted", "Mark" },
                values: new object[] { new DateTime(2023, 5, 18, 20, 29, 52, 277, DateTimeKind.Local).AddTicks(7308), 1.0 });

            migrationBuilder.UpdateData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DateCompleted",
                value: new DateTime(2023, 5, 8, 1, 26, 30, 658, DateTimeKind.Local).AddTicks(6719));

            migrationBuilder.UpdateData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "DateCompleted", "Mark" },
                values: new object[] { new DateTime(2023, 7, 24, 18, 46, 4, 828, DateTimeKind.Local).AddTicks(5935), 3.0 });

            migrationBuilder.UpdateData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "TestId", "UserId" },
                values: new object[] { 1L, 3L });

            migrationBuilder.UpdateData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "DateCompleted", "TestId", "UserId" },
                values: new object[] { new DateTime(2023, 3, 9, 7, 10, 51, 704, DateTimeKind.Local).AddTicks(7832), 2L, 3L });

            migrationBuilder.UpdateData(
                table: "AssignedTests",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "TestId", "UserId" },
                values: new object[] { 3L, 3L });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Number", "TestId" },
                values: new object[] { 1, 3L });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4L,
                column: "TestId",
                value: 4L);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5L,
                column: "TestId",
                value: 4L);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6L,
                column: "TestId",
                value: 5L);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Number",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "Number", "TestId" },
                values: new object[] { 2, 7L });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11L,
                column: "TestId",
                value: 8L);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12L,
                column: "TestId",
                value: 9L);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 13L,
                column: "TestId",
                value: 9L);

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Answer", "Number", "Question", "TestId" },
                values: new object[,]
                {
                    { 14L, "16", 1, "15 + 1 =", 10L },
                    { 15L, "17", 2, "16 + 1 =", 10L }
                });

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Name",
                value: "expedita");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Name",
                value: "delectus");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Name",
                value: "laboriosam");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Name",
                value: "et");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Name",
                value: "est");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Name",
                value: "quaerat");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Name",
                value: "quia");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Name",
                value: "voluptatem");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 9L,
                column: "Name",
                value: "nesciunt");

            migrationBuilder.UpdateData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 10L,
                column: "Name",
                value: "quidem");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "6BADBF3C5842C748C4F30513DFA5F20E4232CAC44531FA0FA95D42D0C04AC53C22E746A9E2E19AC1B51BF6BE2628202449F8BC4163A0C0FECF5DED8654B4203A", "vEUXIxlvdvOfWB3rHBkCqhhcADEQv96KACIOWYfFAwgmsYPVExj6i859J/4B9LFPnj4683Q3lBM0267m0ROpug==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "302AECE75676893D130FD93E28666BCCA91F14222BBD26EDC79D6E6355A5FBA2CF3F79296FCCB94ACE016A491AC1D89C460FC823D568004DF28752EEC266BD03", "vEUXIxlvdvOfWB3rHBkCqhhcADEQv96KACIOWYfFAwgmsYPVExj6i859J/4B9LFPnj4683Q3lBM0267m0ROpug==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "AC5ACFF90B2C8FC1FACBE05703956C7AA5084DEB19FCEB0D4F9402817C89826DDB9610F27A7F54BEC9DDBAC303697B032CB3025636D5AA2C9887950C594BBA68", "vEUXIxlvdvOfWB3rHBkCqhhcADEQv96KACIOWYfFAwgmsYPVExj6i859J/4B9LFPnj4683Q3lBM0267m0ROpug==" });
        }
    }
}
