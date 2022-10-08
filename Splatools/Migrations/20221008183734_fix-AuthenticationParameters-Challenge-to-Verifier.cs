using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Splatools.Migrations
{
    public partial class fixAuthenticationParametersChallengetoVerifier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Challenge",
                table: "AuthenticationParameters",
                newName: "Verifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Verifier",
                table: "AuthenticationParameters",
                newName: "Challenge");
        }
    }
}
