using DomainLayer.Dtos;
using DomainLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.DbContextLayer;
using ServiceLayer.service.Contract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.service.Implementation
{
    public class UserService : IUser
    {
        private readonly ApplicationDbContext _context;
        public IConfiguration _configration;
        public UserService(IConfiguration configuration, ApplicationDbContext context)
        {
            this._configration = configuration;
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


        public string Login(LoginUserDto dto)
        {
            
            var record = this._context.users.Where(u => u.email == dto.email && u.Password == dto.password).FirstOrDefault();
            if (record == null)
            {
                return  "Failed To Login";
            }
            else
            {
                return GENERATEJSONWEBTOKEN(dto.email, record.Id);
            }
        }

        public string GENERATEJSONWEBTOKEN(string username, int id)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName,username),
                new Claim(JwtRegisteredClaimNames.Sub,id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(
                issuer: _configration["Jwt:Issuer"],
                audience: _configration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddDays(2),
                signingCredentials: credentials);
            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodeToken;


        }

       
    }
}
