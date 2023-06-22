using DomainLayer.Dtos;
using DomainLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.service.Contract;
using ServiceLayer.service.Implementation;

namespace DentClinic.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpGet]
        [Route("GetUserById")]
        public Response<User> GetById(int id)
        {
            return this._user.GetById(id);
        }
        [HttpGet]
        [Route("GetAllUsers")]
        public Response<List<User>> GetAllRecords()
        {
            return this._user.GetAllRecords();
        }
        [HttpPost]
        [Route("CreateUser")]
        public Response<User> CreateUser(CreateUserDto user)
        {
            return this._user.AddUser(user);
        }
        [HttpPut]
        [Route("UpdateUser")]
        public Response<User> UpdateUser(User user)
        {
            return this._user.UpdateUser(user);
        }
        [HttpDelete]
        [Route("DeleteUser")]
        public Response<User> DeleteUser(int id)
        {
            return this._user.Delete(id);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public Response<LoginResponceDto> Login(LoginUserDto dto)
        {
            return this._user.Login(dto);
        }
    }
}
