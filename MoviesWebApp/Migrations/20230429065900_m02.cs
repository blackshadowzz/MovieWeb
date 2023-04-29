using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesWebApp.Migrations
{
    /// <inheritdoc />
    public partial class m02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_Genders_GenderID",
                table: "Actors");

            migrationBuilder.DropForeignKey(
                name: "FK_Directors_Genders_GenderID",
                table: "Directors");

            migrationBuilder.DropIndex(
                name: "IX_Directors_GenderID",
                table: "Directors");

            migrationBuilder.DropIndex(
                name: "IX_Actors_GenderID",
                table: "Actors");

            migrationBuilder.RenameColumn(
                name: "GenderID",
                table: "Directors",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "GenderID",
                table: "Actors",
                newName: "Gender");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Directors",
                newName: "GenderID");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Actors",
                newName: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Directors_GenderID",
                table: "Directors",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Actors_GenderID",
                table: "Actors",
                column: "GenderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Genders_GenderID",
                table: "Actors",
                column: "GenderID",
                principalTable: "Genders",
                principalColumn: "GenderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Directors_Genders_GenderID",
                table: "Directors",
                column: "GenderID",
                principalTable: "Genders",
                principalColumn: "GenderID");
        }
    }
}
