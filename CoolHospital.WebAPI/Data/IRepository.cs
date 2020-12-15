using CoolHospital.WebAPI.Models;

namespace CoolHospital.WebAPI.Data
{
    public interface IRepository
    {
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         bool SaveChanges();


         //PACIENTES//

         Paciente[] GetAllPacientes(bool includeMedico = false);
         Paciente[] GetAllPacientesByEspecialidadeId(int especialidadeId, bool includeMedico = false);
         Paciente GetPacienteById(int pacienteId, bool includeMedico = false);

         //MEDICOS -- EM ANDAMENTO// 
         Medico[] GetAllMedicos(bool includePaciente = false);
         Medico[] GetAllMedicosByEspecialidadeId(int especialidadeId, bool includePaciente = false);
         Medico GetMedicoById(int medicoId, bool includePaciente = false);
    }
}