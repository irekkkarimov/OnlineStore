using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class userBalancefix1_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBalances_Users_UserId1",
                table: "UserBalances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBalances",
                table: "UserBalances");

            migrationBuilder.DropIndex(
                name: "IX_UserBalances_UserId1",
                table: "UserBalances");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserBalances");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "UserBalances",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserBalances",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBalances",
                table: "UserBalances",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBalances",
                table: "UserBalances");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserBalances",
                newName: "UserId1");

            migrationBuilder.AlterColumn<int>(
                name: "UserId1",
                table: "UserBalances",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserBalances",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBalances",
                table: "UserBalances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBalances_UserId1",
                table: "UserBalances",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBalances_Users_UserId1",
                table: "UserBalances",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
