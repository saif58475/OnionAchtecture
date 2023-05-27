using DomainLayer.Dtos;
using DomainLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.service.Contract;

namespace DentClinic.Controllers
{
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
        [Route("api/User/GetUserById")]
        public User GetBYId(int id)
        {
            var record = this._user.GetById(id);
            return record;
        }
        [HttpGet]
        [Route("api/User/GetAllUsers")]
        public List<User> GetAllRecords()
        {
            var records = this._user.GetAllRecords();
            return records;
        }
        [HttpPost]
        [Route("api/User/CreateUser")]
        public User CreateUser(User user)
        {
            this._user.AddUser(user);
            return user;
        }
        [HttpPut]
        [Route("api/User/UpdateUser")]
        public User UpdateUSer(User user)
        {
            this._user.UpdateUser(user);
            return user;
        }
        [HttpDelete]
        [Route("api/User/DeleteUser")]
        public string DeleteUser(int id)
        {
            this._user.Delete(id);
            return "Deleted Successfully";
        }
    }
}
