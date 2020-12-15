using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CoolHospital.WebAPI.Data;
using CoolHospital.WebAPI.Dtos;
using CoolHospital.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoolHospital.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        public PacienteController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
             var paciente = _repo.GetAllPacientes(true);
             var pacienteResult = _mapper.Map<IEnumerable<PacienteDto>>(paciente);
             
            return Ok(pacienteResult);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var paciente = _repo.GetPacienteById(id, true);
             
            if (paciente == null) return BadRequest("Paciente não encontrado");

            var pacienteDto = _mapper.Map<PacienteDto>(paciente);

            return Ok(pacienteDto);

        }

        [HttpGet("ByEspecialidadeId/{especialidadeId}")]
        public IActionResult GetByEspecialidadeId(int especialidadeId)
        {
            var paciente = _repo.GetAllPacientesByEspecialidadeId(especialidadeId, false);
             
            if (paciente == null) return BadRequest("Especialidade não encontrada");

            return Ok(paciente);

        }

        [HttpPost]
        public IActionResult Post(PacienteRegistrarDto model)
        {
            var paciente = _mapper.Map<Paciente>(model);         

            _repo.Add(paciente);
            if (_repo.SaveChanges())
            {
                return Created($"/api/paciente/{model.Id}", _mapper.Map<PacienteDto>(paciente));
            } 

                return BadRequest("Paciente não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, PacienteRegistrarDto model)
        {
            var paciente = _repo.GetPacienteById(id, true);

            if (paciente == null) return BadRequest("Paciente não encontrado");
             
            _mapper.Map(model, paciente);
            _repo.Update(paciente);
            if (_repo.SaveChanges())
            {
                return Created($"/api/paciente/{model.Id}", _mapper.Map<PacienteDto>(paciente));
            } 

                return BadRequest("Paciente não alterado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, PacienteRegistrarDto model)
        {
            var paciente = _repo.GetPacienteById(id, true);

            if (paciente == null) return BadRequest("Paciente não encontrado");
             
            _mapper.Map(model, paciente); 
            _repo.Update(paciente);
            if (_repo.SaveChanges())
            {
                return Created($"/api/paciente/{model.Id}", _mapper.Map<PacienteDto>(paciente));
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