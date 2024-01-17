using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    
    public class TodosController : CustomController
    {

        private readonly IMapper _mapper;
        private readonly IService<TodoItem> _service;
        
        

        public TodosController(IMapper mapper, IService<TodoItem> service )
        {
            _mapper = mapper;
            _service = service;
            
            
            
        }

        

        



        [HttpGet]
        public async Task<IActionResult> All()
        {
            var todos = await _service.GetAllAsync();

            var todosDto = _mapper.Map<List<TodoDTO>>(todos.ToList());

            return CreateActionResult(CustomResponseDto<List<TodoDTO>>.Success(200,todosDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _service.GetByIdAsync(id);

            var todosDto = _mapper.Map<TodoDTO>(todo);

            return CreateActionResult(CustomResponseDto<TodoDTO>.Success(200, todosDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(TodoDTO todoDto)
        {
            var todo = await _service.AddAsync(_mapper.Map<TodoItem>(todoDto));

            var todosDto = _mapper.Map<TodoDTO>(todo);

            return CreateActionResult(CustomResponseDto<TodoDTO>.Success(201, todosDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(TodoDTO todoDto)
        {
            await _service.UpdateAsync(_mapper.Map<TodoItem>(todoDto));

            

            return CreateActionResult(CustomResponseDto<NoContentDTO>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var todo = await _service.GetByIdAsync(id);

            await _service.RemoveAsync(todo);

            var todosDto = _mapper.Map<TodoDTO>(todo);

            return CreateActionResult(CustomResponseDto<NoContentDTO>.Success(204));
        }
    }
}
