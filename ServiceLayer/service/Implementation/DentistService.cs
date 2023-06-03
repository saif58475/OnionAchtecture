using DomainLayer.Dtos;
using DomainLayer.Model;
using RepositoryLayer.DbContextLayer;
using ServiceLayer.service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.service.Implementation;
using Microsoft.AspNetCore.Http;

namespace ServiceLayer.service.Implementation
{
    public class DentistService : IDentist
    {
        private readonly ApplicationDbContext context;
        Response<Dentist> responce = new Response<Dentist>();
        public DentistService(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        public Response<Dentist> AddDentist(CreateDentistDto dentist)
        {
            var responce = new Response<Dentist>();
            try
            {
                var record = new Dentist();
                record.Name = dentist.Name;
                record.Age = dentist.Age;
                record.Major = dentist.Major;
                this.context.dentists.Add(record);
                this.context.SaveChanges();
                responce.Message = "Success";responce.MessageCode = 200; responce.Data = record;responce.Success = true;

            }
            catch (Exception ex)
            {
                responce.Message = "Failed"; responce.MessageCode = StatusCodes.Status400BadRequest; responce.Data = (Dentist)ex.Data; responce.Success = true;
            }
            return responce;
        }

        public Response<Dentist> Delete(int id)
        {
            try
            {
                var record = this.context.dentists.FirstOrDefault(r => r.Id == id);
                this.context.dentists.Remove(record);
                this.context.SaveChanges();
                this.responce.Message = "Success";this.responce.MessageCode = 200; this.responce.Data = record;this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = "Failed"; this.responce.MessageCode = StatusCodes.Status400BadRequest; this.responce.Data = (Dentist)ex.Data; this.responce.Success = false;
            }
            return responce;
        }

        public Response<List<Dentist>> GetAllDentists()
        {
            Response<List<Dentist>> responce = new Response<List<Dentist>>();
            try
            {
                var records = this.context.dentists.ToList();
                responce.Message = "Success"; responce.MessageCode = 200; responce.Data = records; responce.Success = true;
            }
            catch (Exception ex)
            {
                responce.Message = "Failed"; responce.MessageCode = StatusCodes.Status400BadRequest; responce.Data = (List<Dentist>)ex.Data; responce.Success = false;
            }
            return responce;
        }

        public Response<Dentist> GetById(int id)
        {
            try
            {
                this.responce.Message = "Success"; this.responce.MessageCode = 200; this.responce.Data = this.context.dentists.FirstOrDefault(r => r.Id == id); this.responce.Success = true;
            }
            catch (Exception ex)
            {
                responce.Message = "Failed"; responce.MessageCode = StatusCodes.Status400BadRequest; responce.Data = (Dentist)ex.Data; responce.Success = false;
            }
            return responce;
        }

        public Response<Dentist> UpdateDentist(Dentist dentist)
        {
            try
            {
                var record = this.context.dentists.FirstOrDefault(r => r.Id == dentist.Id);
                record.Name = dentist.Name;
                record.Age = dentist.Age;
                record.Major = dentist.Major;
                this.context.dentists.Update(record);
                this.context.SaveChanges();
                this.responce.Message = "Success"; this.responce.MessageCode = 200; this.responce.Data = record; this.responce.Success = true;
            }
            catch (Exception ex)
            {
                responce.Message = "Failed"; responce.MessageCode = StatusCodes.Status400BadRequest; responce.Data = (Dentist)ex.Data; responce.Success = false;
            }
            return responce;
        }
    }
}
