using CoolHospital.WebAPI.Data;
using CoolHospital.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoolHospital.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController : ControllerBase
    {
        private readonly IRepository _repo;
        public MedicoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
             var result = _repo.GetAllMedicos(true);
             
            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _repo.GetMedicoById(id, false);
             
            if (result == null) return BadRequest("Médico não encontrado");

            return Ok(result);

        }

        [HttpGet("ByEspecialidadeId/{especialidadeId}")]
        public IActionResult GetByEspecialidadeId(int especialidadeId)
        {
            var result = _repo.GetAllMedicosByEspecialidadeId(especialidadeId, false);
             
            if (result == null) return BadRequest("Especialidade não encontrada");

            return Ok(result);

        }

        [HttpPost]
        public IActionResult Post(Medico medico)
        {
           // var result = _repo.GetAllPacientesByEspecialidadeId(especialidadeId, false);
             
            _repo.Add(medico);
            if (_repo.SaveChanges())
            {
                return Created($"/api/medico/{medico.Id}", medico);
            } 

                return BadRequest("Médico não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Medico medico)
        {
            var result = _repo.GetMedicoById(id, true);

            if (result == null) return BadRequest("Médico não encontrado");
             
            _repo.Update(medico);
            if (_repo.SaveChanges())
            {
                return Created($"/api/medico/{medico.Id}", medico);
            } 

                return BadRequest("Médico não alterado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Medico medico)
        {
            var result = _repo.GetMedicoById(id, true);

            if (result == null) return BadRequest("Médico não encontrado");
             
            _repo.Update(medico);
            if (_repo.SaveChanges())
            {
                return Created($"/api/medico/{medico.Id}", medico);
            } 

                return BadRequest("Médico não alterado");
        }    

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _repo.GetMedicoById(id);

            if (result == null) return BadRequest("Medico não encontrado");
             
            _repo.Delete(result);
            if (_repo.SaveChanges())
            {
                return Ok("Medico deletado");
            } 

                return BadRequest("Medico não deletado");
        }
    }

}