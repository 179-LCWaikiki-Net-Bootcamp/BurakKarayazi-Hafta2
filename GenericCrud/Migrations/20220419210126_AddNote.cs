using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GenericCrud.Migrations
{
    public partial class AddNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "NoteId",
                table: "ToDoItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_NoteId",
                table: "ToDoItems",
                column: "NoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_Notes_NoteId",
                table: "ToDoItems",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_Notes_NoteId",
                table: "ToDoItems");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_ToDoItems_NoteId",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "NoteId",
                table: "ToDoItems");
        }
    }
}
