using System.Collections.Generic;
using CoolHospital.WebAPI.Models;

namespace CoolHospital.WebAPI.Dtos
{
    public class PacienteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int Carteirinha { get; set; }
        public bool Ativo { get; set; } = true;
       // public IEnumerable<PacienteEspecialidade> PacientesEspecialidades { get; set; }
    }
}