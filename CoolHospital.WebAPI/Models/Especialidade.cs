using System.Collections.Generic;

namespace CoolHospital.WebAPI.Models
{
    public class Especialidade
    {
        public Especialidade(int id, string nome, int medicoId) 
        {
            this.Id = id;
                this.Nome = nome;
                this.MedicoId = medicoId;
               
        }
        public int Id { get; set; }

        public string Nome { get; set; }

        public Medico Medico { get; set; }

        public int MedicoId { get; set; }

        public IEnumerable<PacienteEspecialidade> PacientesEspecialidades { get; set; }

        
    }
}