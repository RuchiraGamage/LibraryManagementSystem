using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryData.Migrations
{
    public partial class eight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchHoursID",
                table: "LibraryBranches",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LibraryBranches_BranchHoursID",
                table: "LibraryBranches",
                column: "BranchHoursID");

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryBranches_BranchHours_BranchHoursID",
                table: "LibraryBranches",
                column: "BranchHoursID",
                principalTable: "BranchHours",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibraryBranches_BranchHours_BranchHoursID",
                table: "LibraryBranches");

            migrationBuilder.DropIndex(
                name: "IX_LibraryBranches_BranchHoursID",
                table: "LibraryBranches");

            migrationBuilder.DropColumn(
                name: "BranchHoursID",
                table: "LibraryBranches");
        }
    }
}
