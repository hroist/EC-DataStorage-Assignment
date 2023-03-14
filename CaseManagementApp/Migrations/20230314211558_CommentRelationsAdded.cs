using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class CommentRelationsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentEntities_CaseEntities_CaseId",
                table: "CommentEntities");

            migrationBuilder.DropTable(
                name: "CaseEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusEntities",
                table: "StatusEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentEntities",
                table: "CommentEntities");

            migrationBuilder.DropIndex(
                name: "IX_CommentEntities_CaseId",
                table: "CommentEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientEntities",
                table: "ClientEntities");

            migrationBuilder.RenameTable(
                name: "StatusEntities",
                newName: "Statuses");

            migrationBuilder.RenameTable(
                name: "CommentEntities",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "ClientEntities",
                newName: "Clients");

            migrationBuilder.RenameIndex(
                name: "IX_ClientEntities_Email",
                table: "Clients",
                newName: "IX_Clients_Email");

            migrationBuilder.AddColumn<int>(
                name: "ReportId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ReportId",
                table: "Comments",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ClientId",
                table: "Reports",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_StatusId",
                table: "Reports",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Reports_ReportId",
                table: "Comments",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Reports_ReportId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ReportId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Statuses",
                newName: "StatusEntities");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "CommentEntities");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "ClientEntities");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_Email",
                table: "ClientEntities",
                newName: "IX_ClientEntities_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusEntities",
                table: "StatusEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentEntities",
                table: "CommentEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientEntities",
                table: "ClientEntities",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CaseEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseEntities_ClientEntities_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ClientEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseEntities_StatusEntities_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentEntities_CaseId",
                table: "CommentEntities",
                column: "CaseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CaseEntities_ClientId",
                table: "CaseEntities",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseEntities_StatusId",
                table: "CaseEntities",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentEntities_CaseEntities_CaseId",
                table: "CommentEntities",
                column: "CaseId",
                principalTable: "CaseEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
