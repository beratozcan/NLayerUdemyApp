using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {

            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<TodoGroup, TodoGroupDto>().ReverseMap();
            CreateMap<TodoItem, TodoDTO>().ReverseMap();
            CreateMap<TodoItem, TodoGroupWithTodoDTO>();



        }
        
        
        
        
       
    }
}
