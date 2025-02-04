﻿using AutoMapper;
using PlatformMicroserviceNet.Models;
using PlatformMicroserviceNet.Dtos;

namespace PlatformMicroserviceNet.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            // Source -> Target
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<PlatformCreateDto, Platform>();
        }
    }
}
