using AutoMapper;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.Behaviour;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.MappingProfiles
{
    public class BehaviorProfile : Profile
    {
        public BehaviorProfile()
        {
         
            CreateMap<Behavior, BehaviorModel>().ReverseMap();
           
               
        }
    }
}
