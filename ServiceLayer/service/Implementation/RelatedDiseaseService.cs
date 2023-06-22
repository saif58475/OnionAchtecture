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
    public class RelatedDiseaseService : IRelatedDisease
    {
        private readonly ApplicationDbContext context;
        Response<RelatedDisease> responce = new Response<RelatedDisease>();
        public RelatedDiseaseService(ApplicationDbContext _context)
        {
            context = _context;
        }
        public Response<RelatedDisease> Create(CreateRelatedDiseasedto dto)
        {
            try
            {
                var record = new RelatedDisease() { Name = dto.Name, Description = dto.Description };
                this.context.RelatedDiseases.Add(record);
                this.context.SaveChanges();
                this.responce.Message = "Success"; this.responce.MessageCode = StatusCodes.Status200OK; this.responce.Data = record; this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = "Failed"; this.responce.MessageCode = StatusCodes.Status200OK; this.responce.Data = (RelatedDisease)ex.Data; this.responce.Success = false;
            }
            return responce;
        }

        public Response<RelatedDisease> Delete(int id)
        {
            try
            {
                var record = this.context.RelatedDiseases.FirstOrDefault(r => r.Id == id);
                this.context.RelatedDiseases.Remove(record);
                this.context.SaveChanges();
                this.responce.Message = "Success"; this.responce.MessageCode = StatusCodes.Status200OK; this.responce.Data = record; this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = "Failed"; this.responce.MessageCode = StatusCodes.Status200OK; this.responce.Data = (RelatedDisease)ex.Data; this.responce.Success = false;
            }
            return responce;
        }

        public Response<List<RelatedDisease>> GetAllRelatedDiseases()
        {
            Response<List<RelatedDisease>> responce = new Response<List<RelatedDisease>>();
            try
            {
                responce.Message = "Success"; responce.MessageCode = StatusCodes.Status200OK; responce.Data = this.context.RelatedDiseases.ToList(); responce.Success = true;
            }
            catch (Exception ex)
            {
                responce.Message = "Failed"; responce.MessageCode = StatusCodes.Status400BadRequest; responce.Data = (List<RelatedDisease>)ex.Data; responce.Success = false;
            }
            return responce;
        }

        public Response<RelatedDisease> GetById(int id)
        {
            try
            {
                this.responce.Message = "Success"; this.responce.MessageCode = StatusCodes.Status200OK; this.responce.Data = this.context.RelatedDiseases.FirstOrDefault(r => r.Id == id); this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = "Failed"; this.responce.MessageCode = StatusCodes.Status200OK; this.responce.Data = (RelatedDisease)ex.Data; this.responce.Success = false;
            }
            return responce;
        }

        public Response<RelatedDisease> Update(RelatedDisease rec)
        {
            try
            {
                var record = this.context.RelatedDiseases.FirstOrDefault(r => r.Id == rec.Id);
                record.Name = rec.Name; record.Description = rec.Description;
                this.context.Update(record);
                this.context.SaveChanges();
                this.responce.Message = "Success"; this.responce.MessageCode = StatusCodes.Status200OK; this.responce.Data = record; this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = "Failed"; this.responce.MessageCode = StatusCodes.Status200OK; this.responce.Data = (RelatedDisease)ex.Data; this.responce.Success = false;
            }
            return responce;
        }

    }
}
