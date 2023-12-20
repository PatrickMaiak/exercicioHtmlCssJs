using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORM.Migrations
{
    public partial class InitialCOmpro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Local",
                table: "Compromisso",
                newName: "LocalId");

            migrationBuilder.RenameColumn(
                name: "Contato",
                table: "Compromisso",
                newName: "ContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compromisso_ContatoId",
                table: "Compromisso",
                column: "ContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compromisso_LocalId",
                table: "Compromisso",
                column: "LocalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compromisso_Contato_ContatoId",
                table: "Compromisso",
                column: "ContatoId",
                principalTable: "Contato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Compromisso_Local_LocalId",
                table: "Compromisso",
                column: "LocalId",
                principalTable: "Local",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compromisso_Contato_ContatoId",
                table: "Compromisso");

            migrationBuilder.DropForeignKey(
                name: "FK_Compromisso_Local_LocalId",
                table: "Compromisso");

            migrationBuilder.DropIndex(
                name: "IX_Compromisso_ContatoId",
                table: "Compromisso");

            migrationBuilder.DropIndex(
                name: "IX_Compromisso_LocalId",
                table: "Compromisso");

            migrationBuilder.RenameColumn(
                name: "LocalId",
                table: "Compromisso",
                newName: "Local");

            migrationBuilder.RenameColumn(
                name: "ContatoId",
                table: "Compromisso",
                newName: "Contato");
        }
    }
}
