using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.service.Contract
{
    public interface IUser
    {
        //getallrecords
        List<User> GetAllRecords();
        //get record by id 
        User GetById(int id);
        //add new record
        string AddUser(User user);
        //update specific record
        string UpdateUser(User user);
        //delete specific record
        string Delete(int id);
    }
}
