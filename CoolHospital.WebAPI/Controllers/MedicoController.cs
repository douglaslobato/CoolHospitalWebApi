using System.Collections.Generic;
using AutoMapper;
using CoolHospital.WebAPI.Data;
using CoolHospital.WebAPI.Dtos;
using CoolHospital.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoolHospital.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        public MedicoController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
             var medico = _repo.GetAllMedicos(false);

             var medicoResult = _mapper.Map<IEnumerable<MedicoDto>>(medico);
             
            return Ok(medicoResult);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _repo.GetMedicoById(id, false);
             
            if (result == null) return BadRequest("Médico não encontrado");

            var medicoDto = _mapper.Map<MedicoDto>(result);

            return Ok(medicoDto);

        }

        [HttpGet("ByEspecialidadeId/{especialidadeId}")]
        public IActionResult GetByEspecialidadeId(int especialidadeId)
        {
            var result = _repo.GetAllMedicosByEspecialidadeId(especialidadeId, false);
             
            if (result == null) return BadRequest("Especialidade não encontrada");

            return Ok(result);

        }

        [HttpPost]
        public IActionResult Post(MedicoRegistrarDto model)
        {
            var medico = _mapper.Map<Medico>(model);

            _repo.Add(medico);
            if (_repo.SaveChanges())
            {
                return Created($"/api/medico/{model.Id}", _mapper.Map<MedicoDto>(medico));
            } 

                return BadRequest("Médico não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, MedicoRegistrarDto model)
        {
            var medico = _repo.GetMedicoById(id, true);

            if (medico == null) return BadRequest("Médico não encontrado");
             
            _mapper.Map(model, medico); 
            _repo.Update(medico);
            if (_repo.SaveChanges())
            {
                return Created($"/api/medico/{model.Id}", _mapper.Map<MedicoDto>(medico));
            } 

                return BadRequest("Médico não alterado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, MedicoRegistrarDto model)
        {
            var medico = _repo.GetMedicoById(id, true);

            if (medico == null) return BadRequest("Médico não encontrado");
             
            _mapper.Map(model, medico); 
            _repo.Update(medico);
            if (_repo.SaveChanges())
            {
                return Created($"/api/medico/{model.Id}", _mapper.Map<MedicoDto>(medico));
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