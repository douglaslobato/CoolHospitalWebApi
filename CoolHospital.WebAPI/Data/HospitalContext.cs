using System.Collections.Generic;
using CoolHospital.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CoolHospital.WebAPI.Data
{
    public class HospitalContext : DbContext
    {
      
       public HospitalContext(DbContextOptions<HospitalContext> options) : base (options) { }

       public DbSet <Paciente> Pacientes { get; set; } 
       public DbSet <PacienteEspecialidade> PacientesEspecialidades { get; set; }
       public DbSet <Especialidade> Especialidades{ get; set; }
       public DbSet <Medico> Medicos { get; set; }

       protected override void OnModelCreating(ModelBuilder builder)
       {
           builder.Entity<PacienteEspecialidade>()
                .HasKey(PE => new {PE.PacienteId, PE.EspecialidadeId});


                builder.Entity<Paciente>()
                    .HasData(new List<Paciente>(){
                        new Paciente(1, "Felipe", "Alves", 20, 909090, true),
                        new Paciente(2, "Rodrigo", "Pereira", 25, 909091, true),
                        new Paciente(3, "Priscila", "Oliveira", 21, 909092, true),
                        new Paciente(4, "Paula", "Piolho", 22, 909093, true),
                        
                    });

                builder.Entity<Especialidade>()
                    .HasData(new List<Especialidade>(){
                        new Especialidade(1, "Cardiologia", 4),
                        new Especialidade(2, "Pediatria", 3),
                        new Especialidade(3, "Psiquiatra", 2),
                        new Especialidade(4, "Ortopedista", 1),
                    });

                builder.Entity<Medico>()
                    .HasData(new List<Medico>(){
                        new Medico(1, "Grey", "Richard"),
                        new Medico(2, "Cristen", "Schmidt"),
                        new Medico(3, "Antony", "Edmundo"),
                        new Medico(4, "Shepherd", "Rick"),

                    });

                builder.Entity<PacienteEspecialidade>()
                    .HasData(new List<PacienteEspecialidade>(){
                        new PacienteEspecialidade() {PacienteId = 1, EspecialidadeId = 1},
                        new PacienteEspecialidade() {PacienteId = 1, EspecialidadeId = 3},
                        new PacienteEspecialidade() {PacienteId = 2, EspecialidadeId = 2},
                        new PacienteEspecialidade() {PacienteId = 2, EspecialidadeId = 4},
                        new PacienteEspecialidade() {PacienteId = 3, EspecialidadeId = 2},
                        new PacienteEspecialidade() {PacienteId = 1, EspecialidadeId = 4},


                    });
       }
    }
}