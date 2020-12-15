using System.Threading.Tasks;
using CoolHospital.WebAPI.Data;
using CoolHospital.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoolHospital.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IRepository _repo;
        public PacienteController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
             var result = _repo.GetAllPacientes(false);
             
            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _repo.GetPacienteById(id, true);
             
            if (result == null) return BadRequest("Paciente não encontrado");

            return Ok(result);

        }

        [HttpGet("ByEspecialidadeId/{especialidadeId}")]
        public IActionResult GetByEspecialidadeId(int especialidadeId)
        {
            var result = _repo.GetAllPacientesByEspecialidadeId(especialidadeId, false);
             
            if (result == null) return BadRequest("Especialidade não encontrada");

            return Ok(result);

        }

        [HttpPost]
        public IActionResult Post(Paciente paciente)
        {
           // var result = _repo.GetAllPacientesByEspecialidadeId(especialidadeId, false);
             
            _repo.Add(paciente);
            if (_repo.SaveChanges())
            {
                return Created($"/api/paciente/{paciente.Id}", paciente);
            } 

                return BadRequest("Paciente não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Paciente paciente)
        {
            var result = _repo.GetPacienteById(id, true);

            if (result == null) return BadRequest("Paciente não encontrado");
             
            _repo.Update(paciente);
            if (_repo.SaveChanges())
            {
                return Created($"/api/paciente/{paciente.Id}", paciente);
            } 

                return BadRequest("Paciente não alterado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Paciente paciente)
        {
            var result = _repo.GetPacienteById(id, true);

            if (result == null) return BadRequest("Paciente não encontrado");
             
            _repo.Update(paciente);
            if (_repo.SaveChanges())
            {
                return Created($"/api/paciente/{paciente.Id}", paciente);
            } 

                return BadRequest("Paciente não alterado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _repo.GetPacienteById(id);

            if (result == null) return BadRequest("Paciente não encontrado");
             
            _repo.Delete(result);
            if (_repo.SaveChanges())
            {
                return Ok("Paciente deletado");
            } 

                return BadRequest("Paciente não deletado");
        }

    }
}