using DomainLayer.Dtos;
using DomainLayer.Model;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.DbContextLayer;
using ServiceLayer.service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.service.Implementation
{
    public class ConsumberService : IConsumber
    {
        private readonly ApplicationDbContext context;
        Response<Consumber> responce = new Response<Consumber>();
        public ConsumberService(ApplicationDbContext _context)
        {
            context = _context;
        }
        public Response<Consumber> Create(CreateConsumberDto dto)
        { 
            try
            {
                var record = new Consumber(){ ConsumberName = dto.ConsumberName,Quantity = dto.Quantity };
                this.context.Consumbers.Add(record);
                this.context.SaveChanges();
                this.responce.Message = "Success";this.responce.MessageCode = StatusCodes.Status200OK; this.responce.Data = record; this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = "Failed"; this.responce.MessageCode = StatusCodes.Status200OK; this.responce.Data = (Consumber)ex.Data; this.responce.Success = false;
            }
            return responce;
        }

        public Response<Consumber> Delete(int id)
        {
            try
            {
                var record = this.context.Consumbers.FirstOrDefault(r => r.Id == id);
                this.context.Consumbers.Remove(record);
                this.context.SaveChanges();
                this.responce.Message = "Success"; this.responce.MessageCode = StatusCodes.Status200OK; this.responce.Data = record; this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = "Failed"; this.responce.MessageCode = StatusCodes.Status200OK; this.responce.Data = (Consumber)ex.Data; this.responce.Success = false;
            }
            return responce;
        }

        public Response<List<Consumber>> GetAllConsumbers()
        {
            Response<List<Consumber>> responce = new Response<List<Consumber>>();
            try
            {
                responce.Message = "Success"; responce.MessageCode = StatusCodes.Status200OK; responce.Data = this.context.Consumbers.ToList(); responce.Success = true;
            }
            catch (Exception ex)
            {
                responce.Message = "Failed"; responce.MessageCode = StatusCodes.Status400BadRequest; responce.Data = (List<Consumber>)ex.Data; responce.Success = false;
            }
            return responce;
        }

        public Response<Consumber> GetById(int id)
        {
            try
            {
                this.responce.Message = "Success"; this.responce.MessageCode = StatusCodes.Status200OK; this.responce.Data = this.context.Consumbers.FirstOrDefault(r => r.Id == id); this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = "Failed"; this.responce.MessageCode = StatusCodes.Status200OK; this.responce.Data = (Consumber)ex.Data; this.responce.Success = false;
            }
            return responce;
        }

        public Response<Consumber> Update(Consumber rec)
        {
            try
            {
                var record = this.context.Consumbers.FirstOrDefault(r => r.Id == rec.Id);
                record.ConsumberName = rec.ConsumberName; record.Quantity = rec.Quantity;
                this.context.Update(record);
                this.context.SaveChanges();
                this.responce.Message = "Success"; this.responce.MessageCode = StatusCodes.Status200OK; this.responce.Data = record; this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = "Failed"; this.responce.MessageCode = StatusCodes.Status200OK; this.responce.Data = (Consumber)ex.Data; this.responce.Success = false;
            }
            return responce;
        }
    }
}
