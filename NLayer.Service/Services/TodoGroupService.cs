using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class TodoGroupService: Service<TodoGroup>, ITodoGroupService
    {

        private readonly ITodoGroupRepository _todoGroupRepository;
        private readonly IMapper _mapper;

        public TodoGroupService(IGenericRepository<TodoGroup> repository, IUnitOfWork unitOfWork, IMapper mapper, ITodoGroupRepository todoGroupRepository) : base(repository, unitOfWork)
        {
            _todoGroupRepository = todoGroupRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<TodoGroupWithTodoDTO>> GetTodoGroupWithTodos(int id)
        {
            var todoGroup = await _todoGroupRepository.GetTodoGroupWithTodosByIdAsync(id);

            var todoGroupDto = _mapper.Map<TodoGroupWithTodoDTO>(todoGroup);

            return CustomResponseDto<TodoGroupWithTodoDTO>.Success(200, todoGroupDto);
        }
    }
}
