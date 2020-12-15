using System.Collections.Generic;
using CoolHospital.WebAPI.Models;

namespace CoolHospital.WebAPI.Dtos
{
    public class EspecialidadeDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public MedicoDto Medico { get; set; }

        public int MedicoId { get; set; }

      //  public IEnumerable<PacienteEspecialidade> PacientesEspecialidades { get; set; }
    }
}