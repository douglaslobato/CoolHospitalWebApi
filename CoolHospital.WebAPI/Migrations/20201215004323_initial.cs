using Microsoft.EntityFrameworkCore.Migrations;

namespace CoolHospital.WebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Idade = table.Column<int>(nullable: false),
                    Carteirinha = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    MedicoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especialidades_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PacientesEspecialidades",
                columns: table => new
                {
                    PacienteId = table.Column<int>(nullable: false),
                    EspecialidadeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacientesEspecialidades", x => new { x.PacienteId, x.EspecialidadeId });
                    table.ForeignKey(
                        name: "FK_PacientesEspecialidades_Especialidades_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacientesEspecialidades_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "Nome", "Sobrenome" },
                values: new object[] { 1, "Grey", "Richard" });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "Nome", "Sobrenome" },
                values: new object[] { 2, "Cristen", "Schmidt" });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "Nome", "Sobrenome" },
                values: new object[] { 3, "Antony", "Edmundo" });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "Nome", "Sobrenome" },
                values: new object[] { 4, "Shepherd", "Rick" });

            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "Id", "Ativo", "Carteirinha", "Idade", "Nome", "Sobrenome" },
                values: new object[] { 1, true, 909090, 20, "Felipe", "Alves" });

            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "Id", "Ativo", "Carteirinha", "Idade", "Nome", "Sobrenome" },
                values: new object[] { 2, true, 909091, 25, "Rodrigo", "Pereira" });

            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "Id", "Ativo", "Carteirinha", "Idade", "Nome", "Sobrenome" },
                values: new object[] { 3, true, 909092, 21, "Priscila", "Oliveira" });

            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "Id", "Ativo", "Carteirinha", "Idade", "Nome", "Sobrenome" },
                values: new object[] { 4, true, 909093, 22, "Paula", "Piolho" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "MedicoId", "Nome" },
                values: new object[] { 4, 1, "Ortopedista" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "MedicoId", "Nome" },
                values: new object[] { 3, 2, "Psiquiatra" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "MedicoId", "Nome" },
                values: new object[] { 2, 3, "Pediatria" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "MedicoId", "Nome" },
                values: new object[] { 1, 4, "Cardiologia" });

            migrationBuilder.InsertData(
                table: "PacientesEspecialidades",
                columns: new[] { "PacienteId", "EspecialidadeId" },
                values: new object[] { 2, 4 });

            migrationBuilder.InsertData(
                table: "PacientesEspecialidades",
                columns: new[] { "PacienteId", "EspecialidadeId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "PacientesEspecialidades",
                columns: new[] { "PacienteId", "EspecialidadeId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "PacientesEspecialidades",
                columns: new[] { "PacienteId", "EspecialidadeId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "PacientesEspecialidades",
                columns: new[] { "PacienteId", "EspecialidadeId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "PacientesEspecialidades",
                columns: new[] { "PacienteId", "EspecialidadeId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Especialidades_MedicoId",
                table: "Especialidades",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_PacientesEspecialidades_EspecialidadeId",
                table: "PacientesEspecialidades",
                column: "EspecialidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PacientesEspecialidades");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Medicos");
        }
    }
}
