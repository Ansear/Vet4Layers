using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using WebApi.Dtos;

namespace WebApi.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Appointment, AppointmentDto>().ReverseMap();
        CreateMap<Breed, BreedDto>().ReverseMap();
        CreateMap<City, CityDto>().ReverseMap();
        CreateMap<Country, CountryDto>().ReverseMap().ForMember(o=>o.Departaments, d=>d.Ignore()); //Permite ignorar el mapeo del atributo y asi se previene el Null
        CreateMap<Country,CountryXState>().ReverseMap();
        CreateMap<Departament, DepartamentDto>().ReverseMap();
        CreateMap<Client, ClientDto>().ReverseMap();
        CreateMap<CustomerPhone, CustomerPhoneDto>().ReverseMap();
        CreateMap<LocationPerson, LocationPersonDto>().ReverseMap();
        CreateMap<Pet, PetDto>().ReverseMap();
        CreateMap<Service, ServiceDto>().ReverseMap();
    }
}