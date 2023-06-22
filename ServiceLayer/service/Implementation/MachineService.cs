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
    public class MachineService : IMachine
    {
        private readonly ApplicationDbContext _context;
        Response<Machine> responce = new Response<Machine>();
        public MachineService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Response<Machine> Create(CreateMachineDto dto)
        {
            try
            {
                FileInfo imgFileInfo = new FileInfo(dto.Image.FileName);
                string imgpath = Guid.NewGuid().ToString() + imgFileInfo.Extension;
                string path = Path.Combine("assets/Images/Machines", imgpath);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    dto.Image.CopyTo(stream);
                };
                var record = new Machine() { Name = dto.Name, Quantity = dto.Quantity, Image = path };
                this._context.machines.Add(record);
                this._context.SaveChanges();
                this.responce.Message = "Success"; this.responce.MessageCode = StatusCodes.Status200OK ;this.responce.Data = record; this.responce.Success = true;
            }
            catch(Exception ex)
            {
                this.responce.Message = "Failed"; this.responce.MessageCode = StatusCodes.Status400BadRequest; this.responce.Data = (Machine)ex.Data; this.responce.Success = false;
            }
            return responce;

        }

        public Response<Machine> Delete(int id)
        {
            try
            {
                var record = this._context.machines.FirstOrDefault(r => r.Id == id);
                this._context.machines.Remove(record);
                this._context.SaveChanges();
                this.responce.Message = "Success"; this.responce.MessageCode = StatusCodes.Status200OK; this.responce.Data = record; this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = "Failed"; this.responce.MessageCode = StatusCodes.Status400BadRequest; this.responce.Data = (Machine)ex.Data; this.responce.Success = false;
            }
            return responce;
        }

        public Response<List<Machine>> GetAllMAchines()
        {
            Response<List<Machine>> responce = new Response<List<Machine>>();
            try
            {
                responce.Message = "Success";responce.MessageCode = StatusCodes.Status200OK;responce.Data = this._context.machines.ToList();responce.Success = true;
            }
            catch (Exception ex)
            {
                responce.Message = "Failed";responce.MessageCode = StatusCodes.Status400BadRequest;responce.Data = (List<Machine>)ex.Data;responce.Success = false;
            }
            return responce;
        }

        public Response<Machine> GetById(int id)
        {
            try
            {
                this.responce.Message = "Success"; this.responce.MessageCode = StatusCodes.Status200OK; this.responce.Data = this._context.machines.FirstOrDefault(r => r.Id == id); this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = "Failed"; this.responce.MessageCode = StatusCodes.Status400BadRequest; this.responce.Data = (Machine)ex.Data; this.responce.Success = false;
            }
            return responce;
        }

        public Response<Machine> Update(UpdateMachineDto dto)
        {
            try
            {
                var record = this._context.machines.FirstOrDefault(r => r.Id == dto.Id);
                record.Name = dto.Name; record.Quantity = dto.Quantity;
                if ( record.Image != null)
                {
                    using (Stream stream = new FileStream(record.Image, FileMode.Create))
                    {
                        dto.Image.CopyTo(stream);
                    };
                }
                this._context.machines.Update(record);
                this._context.SaveChanges();
                this.responce.Message = "Success"; this.responce.MessageCode = StatusCodes.Status200OK; this.responce.Data = record; this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = "Failed"; this.responce.MessageCode = StatusCodes.Status400BadRequest; this.responce.Data = (Machine)ex.Data; this.responce.Success = false;
            }
            return responce;
        }
    }
}
