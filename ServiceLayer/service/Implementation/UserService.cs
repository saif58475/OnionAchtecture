using DomainLayer.Dtos;
using DomainLayer.Model;
using RepositoryLayer.DbContextLayer;
using ServiceLayer.service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.service.Implementation
{
    public class UserService : IUser
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            this._context = context;
        }
        public string AddUser(User user)
        {
            try
            {
                var record = new User();
                record.Name = user.Name;
                record.email = user.email;
                record.Password = user.Password;
                this._context.users.Add(record);
                this._context.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                var record = this._context.users.Where(r => r.Id == id).FirstOrDefault();
                this._context.users.Remove(record);
                this._context.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<User> GetAllRecords()
        {
            return this._context.users.ToList();
        }

        public User GetById(int id)
        {
            var record = this._context.users.FirstOrDefault(r => r.Id == id);
            return record;
        }

        public string UpdateUser(User user)
        {
            try
            {
                var record = this._context.users.Where(r => r.Id == user.Id).FirstOrDefault();
                record.Name = user.Name;
                record.Password = user.Password;
                record.email = user.email;
                this._context.users.Update(record);
                this._context.SaveChanges();
                return "Success";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
