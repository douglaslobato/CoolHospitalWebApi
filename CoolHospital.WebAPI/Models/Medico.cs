using System.Collections.Generic;

namespace CoolHospital.WebAPI.Models
{
    public class Medico
    {
        public Medico(int id, string nome, string sobrenome) 
        {
            this.Id = id;
                this.Nome = nome;
                this.Sobrenome = sobrenome;
               
        }
                public int Id { get; set; }
        
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public IEnumerable<Especialidade> Especialidades { get; set; }

    }
}