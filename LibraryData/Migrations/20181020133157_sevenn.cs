using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryData.Migrations
{
    public partial class sevenn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchHours_LibraryBranches_BranchID",
                table: "BranchHours");

            migrationBuilder.RenameColumn(
                name: "BranchID",
                table: "BranchHours",
                newName: "BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_BranchHours_BranchID",
                table: "BranchHours",
                newName: "IX_BranchHours_BranchId");

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "BranchHours",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchHours_LibraryBranches_BranchId",
                table: "BranchHours",
                column: "BranchId",
                principalTable: "LibraryBranches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchHours_LibraryBranches_BranchId",
                table: "BranchHours");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                table: "BranchHours",
                newName: "BranchID");

            migrationBuilder.RenameIndex(
                name: "IX_BranchHours_BranchId",
                table: "BranchHours",
                newName: "IX_BranchHours_BranchID");

            migrationBuilder.AlterColumn<int>(
                name: "BranchID",
                table: "BranchHours",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BranchHours_LibraryBranches_BranchID",
                table: "BranchHours",
                column: "BranchID",
                principalTable: "LibraryBranches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
