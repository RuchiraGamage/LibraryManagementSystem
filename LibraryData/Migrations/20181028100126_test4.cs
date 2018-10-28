using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryData.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckoutHistories_LibraryCards_LibraryCardID",
                table: "CheckoutHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_LibraryCards_LibraryCardID",
                table: "Checkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Holds_LibraryCards_LibraryCardID",
                table: "Holds");

            migrationBuilder.DropForeignKey(
                name: "FK_LibraryAssets_Status_StatusID",
                table: "LibraryAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_LibraryBranches_BranchHours_BranchHoursID",
                table: "LibraryBranches");

            migrationBuilder.DropForeignKey(
                name: "FK_Patrons_LibraryCards_libraryCardID",
                table: "Patrons");

            migrationBuilder.DropIndex(
                name: "IX_LibraryBranches_BranchHoursID",
                table: "LibraryBranches");

            migrationBuilder.DropColumn(
                name: "BranchHoursID",
                table: "LibraryBranches");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Status",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Discription",
                table: "Status",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "libraryCardID",
                table: "Patrons",
                newName: "LibraryCardId");

            migrationBuilder.RenameColumn(
                name: "TelephoneNumber",
                table: "Patrons",
                newName: "Telephone");

            migrationBuilder.RenameIndex(
                name: "IX_Patrons_libraryCardID",
                table: "Patrons",
                newName: "IX_Patrons_LibraryCardId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "LibraryCards",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Discription",
                table: "LibraryBranches",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "StatusID",
                table: "LibraryAssets",
                newName: "StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_LibraryAssets_StatusID",
                table: "LibraryAssets",
                newName: "IX_LibraryAssets_StatusId");

            migrationBuilder.RenameColumn(
                name: "LibraryCardID",
                table: "Holds",
                newName: "LibraryCardId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Holds",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Holds_LibraryCardID",
                table: "Holds",
                newName: "IX_Holds_LibraryCardId");

            migrationBuilder.RenameColumn(
                name: "LibraryCardID",
                table: "Checkouts",
                newName: "LibraryCardId");

            migrationBuilder.RenameIndex(
                name: "IX_Checkouts_LibraryCardID",
                table: "Checkouts",
                newName: "IX_Checkouts_LibraryCardId");

            migrationBuilder.RenameColumn(
                name: "LibraryCardID",
                table: "CheckoutHistories",
                newName: "LibraryCardId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckoutHistories_LibraryCardID",
                table: "CheckoutHistories",
                newName: "IX_CheckoutHistories_LibraryCardId");

            migrationBuilder.AlterColumn<int>(
                name: "LibraryCardId",
                table: "Patrons",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Patrons",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Patrons",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Patrons",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Patrons",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckoutHistories_LibraryCards_LibraryCardId",
                table: "CheckoutHistories",
                column: "LibraryCardId",
                principalTable: "LibraryCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_LibraryCards_LibraryCardId",
                table: "Checkouts",
                column: "LibraryCardId",
                principalTable: "LibraryCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holds_LibraryCards_LibraryCardId",
                table: "Holds",
                column: "LibraryCardId",
                principalTable: "LibraryCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryAssets_Status_StatusId",
                table: "LibraryAssets",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patrons_LibraryCards_LibraryCardId",
                table: "Patrons",
                column: "LibraryCardId",
                principalTable: "LibraryCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckoutHistories_LibraryCards_LibraryCardId",
                table: "CheckoutHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_LibraryCards_LibraryCardId",
                table: "Checkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Holds_LibraryCards_LibraryCardId",
                table: "Holds");

            migrationBuilder.DropForeignKey(
                name: "FK_LibraryAssets_Status_StatusId",
                table: "LibraryAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_Patrons_LibraryCards_LibraryCardId",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Patrons");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Status",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Status",
                newName: "Discription");

            migrationBuilder.RenameColumn(
                name: "LibraryCardId",
                table: "Patrons",
                newName: "libraryCardID");

            migrationBuilder.RenameColumn(
                name: "Telephone",
                table: "Patrons",
                newName: "TelephoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Patrons_LibraryCardId",
                table: "Patrons",
                newName: "IX_Patrons_libraryCardID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LibraryCards",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "LibraryBranches",
                newName: "Discription");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "LibraryAssets",
                newName: "StatusID");

            migrationBuilder.RenameIndex(
                name: "IX_LibraryAssets_StatusId",
                table: "LibraryAssets",
                newName: "IX_LibraryAssets_StatusID");

            migrationBuilder.RenameColumn(
                name: "LibraryCardId",
                table: "Holds",
                newName: "LibraryCardID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Holds",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Holds_LibraryCardId",
                table: "Holds",
                newName: "IX_Holds_LibraryCardID");

            migrationBuilder.RenameColumn(
                name: "LibraryCardId",
                table: "Checkouts",
                newName: "LibraryCardID");

            migrationBuilder.RenameIndex(
                name: "IX_Checkouts_LibraryCardId",
                table: "Checkouts",
                newName: "IX_Checkouts_LibraryCardID");

            migrationBuilder.RenameColumn(
                name: "LibraryCardId",
                table: "CheckoutHistories",
                newName: "LibraryCardID");

            migrationBuilder.RenameIndex(
                name: "IX_CheckoutHistories_LibraryCardId",
                table: "CheckoutHistories",
                newName: "IX_CheckoutHistories_LibraryCardID");

            migrationBuilder.AlterColumn<int>(
                name: "libraryCardID",
                table: "Patrons",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Patrons",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Patrons",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Patrons",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "BranchHoursID",
                table: "LibraryBranches",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LibraryBranches_BranchHoursID",
                table: "LibraryBranches",
                column: "BranchHoursID");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckoutHistories_LibraryCards_LibraryCardID",
                table: "CheckoutHistories",
                column: "LibraryCardID",
                principalTable: "LibraryCards",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_LibraryCards_LibraryCardID",
                table: "Checkouts",
                column: "LibraryCardID",
                principalTable: "LibraryCards",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Holds_LibraryCards_LibraryCardID",
                table: "Holds",
                column: "LibraryCardID",
                principalTable: "LibraryCards",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryAssets_Status_StatusID",
                table: "LibraryAssets",
                column: "StatusID",
                principalTable: "Status",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryBranches_BranchHours_BranchHoursID",
                table: "LibraryBranches",
                column: "BranchHoursID",
                principalTable: "BranchHours",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patrons_LibraryCards_libraryCardID",
                table: "Patrons",
                column: "libraryCardID",
                principalTable: "LibraryCards",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
