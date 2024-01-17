using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository;
using NLayer.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class TodoService : Service<TodoItem> , ITodoService
    {

        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public TodoService(IGenericRepository<TodoItem> repository, IUnitOfWork unitOfWork, IMapper mapper, ITodoRepository todoRepository) : base(repository,unitOfWork)
        {
            _mapper = mapper;
            _todoRepository = todoRepository;
        }

        public async Task<CustomResponseDto<TodoWithGroupDTO>> GetTodoWithTodoGroup()
        {
            var todos = await _todoRepository.GetTodoWithGroupByIdAsync();

            var todoDto = _mapper.Map<TodoWithGroupDTO>(todos);

            return CustomResponseDto<TodoWithGroupDTO>.Success(200, todoDto);

            
        }

        
    }
}
