using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hub.Service.Catalago.Infra.Data.EF.Migrations
{
    public partial class _003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Profissoes_profissao_id",
                table: "Fornecedores");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Profissoes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Profissoes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Fornecedores",
                newName: "Nome");

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

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Profissoes",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Fornecedores",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Profissoes_ProfissaoId",
                table: "Fornecedores",
                column: "ProfissaoId",
                principalTable: "Profissoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Profissoes_ProfissaoId",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Profissoes");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Fornecedores");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Profissoes",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Profissoes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Fornecedores",
                newName: "nome");

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
    }
}
