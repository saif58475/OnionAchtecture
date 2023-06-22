﻿using DomainLayer.Dtos;
using DomainLayer.Model;
using Microsoft.AspNetCore.Http;
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
        Response<User> responce = new Response<User>();
        public UserService(IConfiguration configuration, ApplicationDbContext context)
        {
            this._configration = configuration;
            this._context = context;
        }
        public Response<User> AddUser(CreateUserDto user)
        {
            try
            {
                var record = new User() { Name = user.Name, email = user.email, Password = user.Password};
                this._context.users.Add(record);
                this._context.SaveChanges();
                this.responce.Message = "Success";
                this.responce.MessageCode = StatusCodes.Status200OK;
                this.responce.Data = record;
                this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = ex.Message;
                this.responce.MessageCode = StatusCodes.Status400BadRequest;
                this.responce.Data = null;
                this.responce.Success = false;
            }
            return this.responce;
        }
        public Response<User> Delete(int id)
        {
            try
            {
                var record = this._context.users.Where(r => r.Id == id).FirstOrDefault();
                this._context.users.Remove(record);
                this._context.SaveChanges();
                this.responce.Message = "Success";
                this.responce.MessageCode = StatusCodes.Status200OK;
                this.responce.Data = record;
                this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = ex.Message;
                this.responce.MessageCode = StatusCodes.Status400BadRequest;
                this.responce.Data = null;
                this.responce.Success = true;
            }
            return this.responce;
        }
        public Response<List<User>> GetAllRecords()
        {
            Response<List<User>> responce = new Response<List<User>>();
            try
            {
                responce.Message = "Success";
                responce.MessageCode = StatusCodes.Status200OK;
                responce.Data = this._context.users.ToList();
                responce.Success = true;
            }
            catch (Exception ex)
            {
                responce.Message = ex.Message;
                responce.MessageCode = StatusCodes.Status400BadRequest;
                responce.Data = null;
                responce.Success = false;
            }
            return responce;
        }
        public Response<User> GetById(int id)
        {
            try
            {
                this.responce.Message = "Success";
                this.responce.MessageCode = StatusCodes.Status200OK;
                this.responce.Data = this._context.users.FirstOrDefault(r => r.Id == id);
                this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = ex.Message;
                this.responce.MessageCode = StatusCodes.Status400BadRequest;
                this.responce.Data = null;
                this.responce.Success = false;
            }
            return this.responce;
        }
        public Response<User> UpdateUser(User user)
        {
            try
            {
                var record = this._context.users.Where(r => r.Id == user.Id).FirstOrDefault();
                record.Name = user.Name;
                record.Password = user.Password;
                record.email = user.email;
                this._context.users.Update(record);
                this._context.SaveChanges();
                this.responce.Message = "Success";
                this.responce.MessageCode = StatusCodes.Status202Accepted;
                this.responce.Data = record;
                this.responce.Success = true;
            }
            catch(Exception ex)
            {
                this.responce.Message = "Success";
                this.responce.MessageCode = StatusCodes.Status400BadRequest;
                this.responce.Data = null;
                this.responce.Success = true;
            }
            return this.responce;
        }
        public Response<LoginResponceDto> Login(LoginUserDto dto)
        {
            var record = this._context.users.Where(u => u.email == dto.email && u.Password == dto.password).FirstOrDefault();
            Response<LoginResponceDto> responce = new Response<LoginResponceDto>();
            if (record == null)
            {
                responce.Message = "Their is no user with this email";
                responce.MessageCode = 200;
                responce.Data = null;
                responce.Success = true;
            }
            else
            {
                LoginResponceDto tok = new LoginResponceDto() { token = GENERATEJSONWEBTOKEN(dto.email, record.Id) };
                responce.Message = "Success";
                responce.MessageCode = 200;
                responce.Data = tok;
                responce.Success = true;
            }
            return responce;
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
