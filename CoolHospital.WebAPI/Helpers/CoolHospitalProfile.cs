using AutoMapper;
using CoolHospital.WebAPI.Dtos;
using CoolHospital.WebAPI.Models;

namespace CoolHospital.WebAPI.Helpers
{
    public class CoolHospitalProfile : Profile
    {
        
       public CoolHospitalProfile()
        {
            CreateMap<Paciente, PacienteDto>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                );             

            CreateMap<PacienteDto, Paciente>();
            CreateMap<Paciente, PacienteRegistrarDto>().ReverseMap();

            //MEDICODTO//

            CreateMap<Medico, MedicoDto>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                );

            CreateMap<MedicoDto, Medico>();
            CreateMap<Medico, MedicoRegistrarDto>().ReverseMap();
            CreateMap<EspecialidadeDto, Especialidade >().ReverseMap();
           // CreateMap<PacienteEspecialidade, PacienteEspecialidadeDto>().ReverseMap();

        }
    }
}