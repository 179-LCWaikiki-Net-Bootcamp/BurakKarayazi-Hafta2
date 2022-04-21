using Microsoft.EntityFrameworkCore.Migrations;

namespace GenericCrud.Migrations
{
    public partial class NoteIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_Notes_NoteId",
                table: "ToDoItems");

            migrationBuilder.AlterColumn<long>(
                name: "NoteId",
                table: "ToDoItems",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_Notes_NoteId",
                table: "ToDoItems",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_Notes_NoteId",
                table: "ToDoItems");

            migrationBuilder.AlterColumn<long>(
                name: "NoteId",
                table: "ToDoItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_Notes_NoteId",
                table: "ToDoItems",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
