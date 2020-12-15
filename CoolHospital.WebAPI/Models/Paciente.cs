using System;
using System.Collections.Generic;

namespace CoolHospital.WebAPI.Models
{
    public class Paciente
    {
        public Paciente(int id, string nome, string sobrenome, int idade, int carteirinha, Boolean ativo) 
        {
            this.Id = id;
                this.Nome = nome;
                this.Sobrenome = sobrenome;
                this.Idade = idade;
                this.Carteirinha = carteirinha;
                this.Ativo = ativo;
               
        }

                public int Id { get; set; }
        
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public int Idade { get; set; }

        public int Carteirinha { get; set; }

        public Boolean Ativo { get; set; } = true;

        public IEnumerable<PacienteEspecialidade> PacientesEspecialidades { get; set; }

    }
}