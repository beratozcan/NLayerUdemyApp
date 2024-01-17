using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoGroupController : CustomController
    {

        


        private readonly IMapper _mapper;
        private readonly IService<TodoGroup> _service;



        public TodoGroupController(IMapper mapper, IService<TodoGroup> service)
        {
            _mapper = mapper;
            _service = service;



        }







        [HttpGet]
        public async Task<IActionResult> All()
        {
            var todoGroups = await _service.GetAllAsync();

            var todoGroupDto = _mapper.Map<List<TodoGroupDto>>(todoGroups.ToList());

            return CreateActionResult(CustomResponseDto<List<TodoGroupDto>>.Success(200, todoGroupDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todoGroup = await _service.GetByIdAsync(id);

            var todoGroupDto = _mapper.Map<TodoGroupDto>(todoGroup);

            return CreateActionResult(CustomResponseDto<TodoGroupDto>.Success(200, todoGroupDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(TodoGroupDto todoGroupDto)
        {
            var todoGroup = await _service.AddAsync(_mapper.Map<TodoGroup>(todoGroupDto));

            var _todoGroupDto = _mapper.Map<TodoGroupDto>(todoGroup);

            return CreateActionResult(CustomResponseDto<TodoGroupDto>.Success(201, _todoGroupDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(TodoGroupDto todoGroupDto)
        {
            await _service.UpdateAsync(_mapper.Map<TodoGroup>(todoGroupDto));



            return CreateActionResult(CustomResponseDto<NoContentDTO>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var todoGroup = await _service.GetByIdAsync(id);

            await _service.RemoveAsync(todoGroup);

            var todoGroupDto = _mapper.Map<TodoGroupDto>(todoGroup);

            return CreateActionResult(CustomResponseDto<NoContentDTO>.Success(204));
        }
    }

}

