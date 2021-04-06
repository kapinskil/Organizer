using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizer.Migrations
{
    public partial class _2ed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PomodoroTasks_PomodoroTaskStatuses_PomodoroTaskStatusId",
                table: "PomodoroTasks");

            migrationBuilder.DropColumn(
                name: "PomodoroStatusId",
                table: "PomodoroTasks");

            migrationBuilder.AlterColumn<int>(
                name: "PomodoroTaskStatusId",
                table: "PomodoroTasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PomodoroTasks_PomodoroTaskStatuses_PomodoroTaskStatusId",
                table: "PomodoroTasks",
                column: "PomodoroTaskStatusId",
                principalTable: "PomodoroTaskStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PomodoroTasks_PomodoroTaskStatuses_PomodoroTaskStatusId",
                table: "PomodoroTasks");

            migrationBuilder.AlterColumn<int>(
                name: "PomodoroTaskStatusId",
                table: "PomodoroTasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PomodoroStatusId",
                table: "PomodoroTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PomodoroTasks_PomodoroTaskStatuses_PomodoroTaskStatusId",
                table: "PomodoroTasks",
                column: "PomodoroTaskStatusId",
                principalTable: "PomodoroTaskStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
