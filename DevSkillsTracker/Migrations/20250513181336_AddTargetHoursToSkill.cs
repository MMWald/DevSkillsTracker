using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevSkillsTracker.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddTargetHoursToSkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TargetHours",
                table: "Skills",
                type: "REAL",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LearningLogs",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_LearningLogs_UserId",
                table: "LearningLogs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LearningLogs_AspNetUsers_UserId",
                table: "LearningLogs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LearningLogs_AspNetUsers_UserId",
                table: "LearningLogs");

            migrationBuilder.DropIndex(
                name: "IX_LearningLogs_UserId",
                table: "LearningLogs");

            migrationBuilder.DropColumn(
                name: "TargetHours",
                table: "Skills");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LearningLogs",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
