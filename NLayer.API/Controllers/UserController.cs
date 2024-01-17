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
    public class UserController : CustomController
    {
        private readonly IMapper _mapper;
        private readonly IService<User> _service;


        public UserController(IMapper mapper, IService<User> service)
        {
            _mapper = mapper;
            _service = service;



        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var User = await _service.GetAllAsync();

            var UserDto = _mapper.Map<List<UserDTO>>(User.ToList());

            return CreateActionResult(CustomResponseDto<List<UserDTO>>.Success(200, UserDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var User = await _service.GetByIdAsync(id);

            var UserDto = _mapper.Map<UserDTO>(User);

            return CreateActionResult(CustomResponseDto<UserDTO>.Success(200, UserDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(UserDTO UserDto)
        {
            var user = await _service.AddAsync(_mapper.Map<User>(UserDto));

            var userDto = _mapper.Map<UserDTO>(user);

            return CreateActionResult(CustomResponseDto<UserDTO>.Success(201, userDto));
        }


        [HttpPut]
        public async Task<IActionResult> Update(UserDTO userDto)
        {
            await _service.UpdateAsync(_mapper.Map<User>(userDto));



            return CreateActionResult(CustomResponseDto<NoContentDTO>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var user = await _service.GetByIdAsync(id);

            await _service.RemoveAsync(user);

            var userDto = _mapper.Map<UserDTO>(user);

            return CreateActionResult(CustomResponseDto<NoContentDTO>.Success(204));
        }

    }
}
