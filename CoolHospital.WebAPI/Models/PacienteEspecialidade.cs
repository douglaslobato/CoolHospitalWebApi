namespace CoolHospital.WebAPI.Models
{
    public class PacienteEspecialidade
    {
        public PacienteEspecialidade() { }

        public PacienteEspecialidade(Paciente paciente, int pacienteId, Especialidade especialidade, int especialidadeId) 
        {
            this.Paciente = paciente;
                this.PacienteId = pacienteId;
                this.Especialidade = especialidade;
                this.EspecialidadeId = especialidadeId;
               
        }
                public Paciente Paciente { get; set; }

        public int PacienteId { get; set; }

        public Especialidade Especialidade { get; set; }

        public int EspecialidadeId { get; set; }
        
    }
}