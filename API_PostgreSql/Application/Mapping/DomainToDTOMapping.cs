using API_PostgreSql.Domain.DTOs;
using API_PostgreSql.Domain.Models;
using AutoMapper;

namespace API_PostgreSql.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.NameEmployee, m => m.MapFrom(orig => orig.Name));
        }
    }
}
