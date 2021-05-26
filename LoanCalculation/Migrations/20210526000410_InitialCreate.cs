using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanCalculation.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnnualInterestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PercentageAdministrationFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountAdministrationFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanConfiguration", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LoanConfiguration",
                columns: new[] { "Id", "AmountAdministrationFee", "AnnualInterestRate", "PercentageAdministrationFee" },
                values: new object[] { 1, 1000m, 5m, 1m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanConfiguration");
        }
    }
}
