using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agendamento.Migrations
{
    /// <inheritdoc />
    public partial class AjustarDataNascimentoPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Pacientes",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Pacientes",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");
        }
    }
}
