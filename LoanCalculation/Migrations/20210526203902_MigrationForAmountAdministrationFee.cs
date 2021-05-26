using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanCalculation.Migrations
{
    public partial class MigrationForAmountAdministrationFee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LoanConfiguration",
                keyColumn: "Id",
                keyValue: 1,
                column: "AmountAdministrationFee",
                value: 10000m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LoanConfiguration",
                keyColumn: "Id",
                keyValue: 1,
                column: "AmountAdministrationFee",
                value: 1000m);
        }
    }
}
