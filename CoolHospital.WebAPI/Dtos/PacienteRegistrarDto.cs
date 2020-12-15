namespace CoolHospital.WebAPI.Dtos
{
    public class PacienteRegistrarDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get; set; }
        public int Carteirinha { get; set; }
        public bool Ativo { get; set; } = true;
    }
}