using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Distance.Dtos;
using Distance.Models;

namespace Distance.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Driver, DriverDto>();
            Mapper.CreateMap<Car, CarDto>();

            Mapper.CreateMap<DriverDto, Driver>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<CarDto, Car>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}