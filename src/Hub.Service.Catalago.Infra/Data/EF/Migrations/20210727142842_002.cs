using Microsoft.EntityFrameworkCore.Migrations;

namespace Hub.Service.Catalago.Infra.Data.EF.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Profissoes_ProfissaoId",
                table: "Fornecedores");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Profissoes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Fornecedores",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProfissaoId",
                table: "Fornecedores",
                newName: "profissao_id");

            migrationBuilder.RenameIndex(
                name: "IX_Fornecedores_ProfissaoId",
                table: "Fornecedores",
                newName: "IX_Fornecedores_profissao_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Profissoes_profissao_id",
                table: "Fornecedores",
                column: "profissao_id",
                principalTable: "Profissoes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Profissoes_profissao_id",
                table: "Fornecedores");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Profissoes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Fornecedores",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "profissao_id",
                table: "Fornecedores",
                newName: "ProfissaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Fornecedores_profissao_id",
                table: "Fornecedores",
                newName: "IX_Fornecedores_ProfissaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Profissoes_ProfissaoId",
                table: "Fornecedores",
                column: "ProfissaoId",
                principalTable: "Profissoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
