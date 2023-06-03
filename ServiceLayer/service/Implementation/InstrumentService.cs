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
    public class InstrumentService : IInstrument
    {
        private readonly ApplicationDbContext context;
        Response<Instrument> responce = new Response<Instrument>();
        public InstrumentService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public Response<Instrument> Create(CreateInstrumentDto dto)
        {
            try
            {
                FileInfo imgFileInfo = new FileInfo(dto.Image.FileName);
                string imgpath = Guid.NewGuid().ToString() + imgFileInfo.Extension;
                string path = Path.Combine("F:/Clinic BackEnd/DentClinic/DentClinic/assets/Images/Instruments", imgpath);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    dto.Image.CopyTo(stream);
                };
                var record = new Instrument() { Name = dto.Name, Quantity = dto.Quantity, Image = path };
                this.context.instruments.Add(record);
                this.context.SaveChanges();
                this.responce.Message = "Success"; this.responce.MessageCode = StatusCodes.Status200OK; this.responce.Data = record; this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = "Failed"; this.responce.MessageCode = StatusCodes.Status400BadRequest; this.responce.Data = (Instrument)ex.Data; this.responce.Success = false;
            }
            return responce;
           
        }

        public Response<Instrument> Delete(int id)
        {
            try
            {
                var record = this.context.instruments.FirstOrDefault(r => r.Id == id);
                this.context.instruments.Remove(record);
                this.context.SaveChanges();
                this.responce.Message = "Success"; this.responce.MessageCode = StatusCodes.Status200OK; this.responce.Data = record; this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = "Failed"; this.responce.MessageCode = StatusCodes.Status400BadRequest; this.responce.Data = (Instrument)ex.Data; this.responce.Success = false;
            }
            return responce;
        }

        public Response<List<Instrument>> GetAllInstruments()
        {
            Response<List<Instrument>> responce = new Response<List<Instrument>>();
            try
            {
               responce.Message = "Success";responce.MessageCode = StatusCodes.Status200OK;responce.Data = this.context.instruments.ToList();responce.Success = true;
            }
            catch (Exception ex)
            {
               responce.Message = "Failed";responce.MessageCode = StatusCodes.Status400BadRequest;responce.Data = (List<Instrument>)ex.Data;responce.Success = false;
            }
            return responce;
        }

        public Response<Instrument> GetById(int id)
        {
            try
            {
                this.responce.Message = "Success"; this.responce.MessageCode = StatusCodes.Status200OK; this.responce.Data = this.context.instruments.FirstOrDefault(r => r.Id == id); this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = "Failed"; this.responce.MessageCode = StatusCodes.Status400BadRequest; this.responce.Data = (Instrument)ex.Data; this.responce.Success = false;
            }
            return responce;
        }

        public Response<Instrument> Update(Instrument tool)
        {
            try
            {
                var record = this.context.instruments.FirstOrDefault(r => r.Id == tool.Id);
                record.Name = tool.Name; record.Quantity = tool.Quantity;
                //if (tool.Image != null)
                //{
                //    string imgpath = record.Image;
                //    string path = Path.Combine("F:/Clinic BackEnd/DentClinic/DentClinic/assets/Images/Instruments", imgpath);
                //    using (Stream stream = new FileStream(record.Image, FileMode.Create))
                //    {
                //        tool.Image.CopyTo(stream);
                //    };
                //}
                this.context.instruments.Update(record);
                this.context.SaveChanges();
                this.responce.Message = "Success"; this.responce.MessageCode = StatusCodes.Status200OK; this.responce.Data = record; this.responce.Success = true;
            }
            catch (Exception ex)
            {
                this.responce.Message = "Failed"; this.responce.MessageCode = StatusCodes.Status400BadRequest; this.responce.Data = (Instrument)ex.Data; this.responce.Success = false;
            }
            return responce;
        }
    }
}
