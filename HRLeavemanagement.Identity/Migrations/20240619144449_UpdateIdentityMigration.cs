using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRLeavemanagement.Identity.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdentityMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "877573a0-b5fc-4515-8649-f7d8862e154e", "admin@localhost.com", "AQAAAAIAAYagAAAAEGonOvZ7ND4J3Bz7r90Ko7dutkIUWn2L489XhX2oRWWMF+DrS5myDZMdH3951NFcvw==", "629d993d-13d1-4c2d-9fc9-b10748b4c483" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652,b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b9bf74c-d7bd-4d21-a59a-25b81b7f06b6", "user@localhost.com", "AQAAAAIAAYagAAAAEEISAMcppV27+2RvJN/dHeZNbxDtNWEam2U3zbV/ZemCT3B9/D9kZEdYlPaXRZxmqQ==", "1438672a-d5fc-4548-95f6-98280372f552" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a39b7532-e2ea-44e6-bd1e-e00f7c6813da", "admin@live.com", "AQAAAAIAAYagAAAAEELQHfzZFdAkEacDLQH2Y7p8zH3COQUAjX5wr+OhBNeYrs/fxNHbBgwMBcO1PNqIiw==", "87c33f99-6ca1-4075-9b63-b92c1333a0e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652,b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba6e9bde-2b1a-4d36-87c0-b8f279b5eefe", "user@live.com", "AQAAAAIAAYagAAAAEKsnNtzEoRMHTcAF0BvsB/5ip/v0vRLSFZKyWsIQdDdOsxT/cHZtJsQTg/OR/zy4eQ==", "a1500c38-080e-4aa3-bed4-8f868f629e26" });
        }
    }
}
