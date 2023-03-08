using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("4ccdf908-35fc-48ae-9cd8-6379e9fe062d"), "Some descr.", "Incident1" },
                    { new Guid("f5883015-4874-47d9-aa12-61cd4a1b1c04"), "Some special descr.", "Incident2" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "IncidentId", "Name" },
                values: new object[,]
                {
                    { new Guid("1c836356-3c0b-4478-a3c7-cd178c393bb1"), new Guid("f5883015-4874-47d9-aa12-61cd4a1b1c04"), "intellectual" },
                    { new Guid("6c8f59d1-b4d9-4888-b2af-3823c1584b22"), new Guid("4ccdf908-35fc-48ae-9cd8-6379e9fe062d"), "mystery007" },
                    { new Guid("d72e2fc0-12f9-4c00-9ad5-1e3b1965c360"), new Guid("4ccdf908-35fc-48ae-9cd8-6379e9fe062d"), "fastestgun" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "AccountId", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("06a28087-17dc-4eaa-957d-a73761b953c2"), new Guid("d72e2fc0-12f9-4c00-9ad5-1e3b1965c360"), "vinve@gmail.com", "Vinsent", "Vega" },
                    { new Guid("75803ca4-79cf-43ab-953a-3c33f931d47d"), new Guid("6c8f59d1-b4d9-4888-b2af-3823c1584b22"), "emailam@gmail.com", "Alek", "Markovych" },
                    { new Guid("f555ddc5-2839-4445-b8af-6df2ecb1c529"), new Guid("1c836356-3c0b-4478-a3c7-cd178c393bb1"), "ruco@gmail.com", "Rust", "Cohle" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: new Guid("06a28087-17dc-4eaa-957d-a73761b953c2"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: new Guid("75803ca4-79cf-43ab-953a-3c33f931d47d"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: new Guid("f555ddc5-2839-4445-b8af-6df2ecb1c529"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: new Guid("1c836356-3c0b-4478-a3c7-cd178c393bb1"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: new Guid("6c8f59d1-b4d9-4888-b2af-3823c1584b22"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: new Guid("d72e2fc0-12f9-4c00-9ad5-1e3b1965c360"));

            migrationBuilder.DeleteData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: new Guid("4ccdf908-35fc-48ae-9cd8-6379e9fe062d"));

            migrationBuilder.DeleteData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: new Guid("f5883015-4874-47d9-aa12-61cd4a1b1c04"));
        }
    }
}
