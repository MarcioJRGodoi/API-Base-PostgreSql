﻿using API_PostgreSql.Domain.DTOs;
using API_PostgreSql.Domain.Models.CageAgregate;
using API_PostgreSql.Domain.Models.EmployeeAgregate;
using AutoMapper;

namespace API_PostgreSql.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Cage, CageDTO>();


        }
    }
}
