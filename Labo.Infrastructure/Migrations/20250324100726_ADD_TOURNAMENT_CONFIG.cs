using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ADD_TOURNAMENT_CONFIG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Tournaments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentRound",
                table: "Tournaments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddCheckConstraint(
                name: "CK_MAX_DEADLINE",
                table: "Tournaments",
                sql: "(DeadlineDate >= DATEADD(DAY, MinMembers, GETDATE()))");

            migrationBuilder.AddCheckConstraint(
                name: "CK_MAX_ELO",
                table: "Tournaments",
                sql: "MaxElo BETWEEN 0 AND 3000");

            migrationBuilder.AddCheckConstraint(
                name: "CK_MAX_MEMBERS",
                table: "Tournaments",
                sql: "MaxMembers BETWEEN 2 AND 32");

            migrationBuilder.AddCheckConstraint(
                name: "CK_MIN_ELO",
                table: "Tournaments",
                sql: "MinElo BETWEEN 0 AND 3000");

            migrationBuilder.AddCheckConstraint(
                name: "CK_MIN_MEMBERS",
                table: "Tournaments",
                sql: "MinMembers BETWEEN 2 AND 32");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_MAX_DEADLINE",
                table: "Tournaments");

            migrationBuilder.DropCheckConstraint(
                name: "CK_MAX_ELO",
                table: "Tournaments");

            migrationBuilder.DropCheckConstraint(
                name: "CK_MAX_MEMBERS",
                table: "Tournaments");

            migrationBuilder.DropCheckConstraint(
                name: "CK_MIN_ELO",
                table: "Tournaments");

            migrationBuilder.DropCheckConstraint(
                name: "CK_MIN_MEMBERS",
                table: "Tournaments");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Tournaments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CurrentRound",
                table: "Tournaments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);
        }
    }
}
