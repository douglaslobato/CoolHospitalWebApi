using System.Collections.Generic;

namespace CoolHospital.WebAPI.Dtos
{
    public class MedicoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<EspecialidadeDto> Especialidades { get; set; }
     

    }
}