using DomainLayer.Dtos;
using DomainLayer.Model;
using ServiceLayer.service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.service.Contract
{
    public interface IUser
    {
        //Get All Records
        Response<List<User>> GetAllRecords();
        //get record by id 
        Response<User> GetById(int id);
        //add new record
        Response<User> AddUser(CreateUserDto user);
        //update specific record
        Response<User> UpdateUser(User user);
        //delete specific record
        Response<User> Delete(int id);
        //this is login and get token
        Response<LoginResponceDto> Login(LoginUserDto dto);
    }
}
