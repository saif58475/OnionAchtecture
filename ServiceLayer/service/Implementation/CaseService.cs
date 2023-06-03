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
    public class CaseService : ICase
    {
        private readonly ApplicationDbContext context;
        Response<Case> responce = new Response<Case>();
        public CaseService(ApplicationDbContext _context)
        {
            context = _context;
        }
        public Response<Case> Create(CreateCaseDto dto)
        {
            
            try
            {
                var record = new Case() { CaseName = dto.CaseName, Description = dto.Description };
                this.context.Cases.Add(record);
                this.context.SaveChanges();
                this.responce.Message = "Success"; this.responce.MessageCode = 200; this.responce.Data = record; this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = ex.Message; this.responce.MessageCode = StatusCodes.Status400BadRequest; this.responce.Data = (Case)ex.Data; this.responce.Success = false;
            }
           
            return responce;
        }

        public Response<Case> Delete(int id)
        {
            try
            {
                var record = this.context.Cases.FirstOrDefault(r => r.Id == id);
                this.context.Cases.Remove(record);
                this.context.SaveChanges();
                this.responce.Message = "Success"; this.responce.MessageCode = 200; this.responce.Data = record; this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = ex.Message; this.responce.MessageCode = StatusCodes.Status400BadRequest; this.responce.Data = (Case)ex.Data; this.responce.Success = false;
            }
            return responce;
        }

        public Response<List<Case>> GetAllCases()
        {
            var responce = new Response<List<Case>>();
            try
            {
                responce.Message = "Success"; responce.MessageCode = 200; responce.Data = this.context.Cases.ToList(); responce.Success = true;
            }
            catch (Exception ex)
            {
                responce.Message = ex.Message; responce.MessageCode = StatusCodes.Status400BadRequest; responce.Data = (List<Case>)ex.Data; responce.Success = false;
            }
            return responce;
        }

        public Response<Case> GetById(int id)
        {
            try
            {
                this.responce.Message = "Success"; this.responce.MessageCode = 200; responce.Data = this.context.Cases.FirstOrDefault(r => r.Id == id); this.responce.Success = true;       
            }
            catch (Exception ex)
            {
                this.responce.Message = ex.Message; this.responce.MessageCode = StatusCodes.Status400BadRequest; this.responce.Data = (Case)ex.Data; this.responce.Success = false;
            }
            return responce;
        }

        public Response<Case> Update(Case rec)
        {
            try
            {
                var record = this.context.Cases.FirstOrDefault(r => r.Id == rec.Id);
                record.CaseName = rec.CaseName; record.Description = rec.Description;
                this.context.Cases.Update(record);
                this.context.SaveChanges();
                this.responce.Message = "Success"; this.responce.MessageCode = 200; this.responce.Data = record; this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = ex.Message; this.responce.MessageCode = StatusCodes.Status400BadRequest; this.responce.Data = (Case)ex.Data; this.responce.Success = false;
            }
            return responce;
        }
    }
}
