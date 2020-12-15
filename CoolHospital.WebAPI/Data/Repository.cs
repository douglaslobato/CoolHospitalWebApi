using System.Linq;
using CoolHospital.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CoolHospital.WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly HospitalContext _context;
        public Repository(HospitalContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }


        //PACIENTES//
        public Paciente[] GetAllPacientes(bool includeMedico = false)
        {
            IQueryable<Paciente> query = _context.Pacientes;

            if (includeMedico)
            {
                query = query.Include(p => p.PacientesEspecialidades)
                             .ThenInclude(pe => pe.Especialidade)
                             .ThenInclude(e => e.Medico);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return query.ToArray();
        }

        public Paciente[] GetAllPacientesByEspecialidadeId(int especialidadeId, bool includeMedico = false)
        {
            IQueryable<Paciente> query = _context.Pacientes;

            if (includeMedico)
            {
                query = query.Include(p => p.PacientesEspecialidades)
                             .ThenInclude(pe => pe.Especialidade)
                             .ThenInclude(e => e.Medico);
            }

            query = query.AsNoTracking()
                        .OrderBy(p => p.Id)
                        .Where(paciente => paciente.PacientesEspecialidades.Any(e => e.EspecialidadeId == especialidadeId));

            return query.ToArray();
        }
        public Paciente GetPacienteById(int pacienteId, bool includeMedico = false)
        {
            IQueryable<Paciente> query = _context.Pacientes;

            if (includeMedico)
            {
                query = query.Include(p => p.PacientesEspecialidades)
                             .ThenInclude(pe => pe.Especialidade)
                             .ThenInclude(e => e.Medico);
            }

            query = query.AsNoTracking()
                        .OrderBy(p => p.Id)
                        .Where(paciente => paciente.Id == pacienteId);

            return query.FirstOrDefault();
        }

        // MEDICOS // 

        public Medico[] GetAllMedicos(bool includePaciente = false)
        {
            IQueryable<Medico> query = _context.Medicos;

            if (includePaciente)
            {
                query = query.Include(e => e.Especialidades)
                             .ThenInclude(pe => pe.PacientesEspecialidades)
                             .ThenInclude(p => p.Paciente);
            }

            query = query.AsNoTracking()
                         .OrderBy(m => m.Id);

            return query.ToArray();
                         
        }

        public Medico[] GetAllMedicosByEspecialidadeId(int especialidadeId, bool includePaciente = false)
        {
            IQueryable<Medico> query = _context.Medicos;

            if (includePaciente)
            {
                query = query.Include(e => e.Especialidades)
                             .ThenInclude(pe => pe.PacientesEspecialidades)
                             .ThenInclude(p => p.Paciente);
            }

            query = query.AsNoTracking()
                         .OrderBy(m => m.Id)
                         .Where(medico => medico.Especialidades.Any(pe => pe.PacientesEspecialidades.Any(e => e.EspecialidadeId == especialidadeId)));

            return query.ToArray();
        }

        public Medico GetMedicoById(int medicoId, bool includePaciente = false)
        {
            IQueryable<Medico> query = _context.Medicos;

            if (includePaciente)
            {
                query = query.Include(e => e.Especialidades)
                             .ThenInclude(pe => pe.PacientesEspecialidades)
                             .ThenInclude(p => p.Paciente);
            }

            query = query.AsNoTracking()
                         .OrderBy(m => m.Id)
                         .Where(medico => medico.Id == medicoId);

            return query.FirstOrDefault();
        }
    }
}