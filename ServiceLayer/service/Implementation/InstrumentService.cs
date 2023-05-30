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
    public class InstrumentService : IInstrument
    {
        private readonly ApplicationDbContext context;
        public InstrumentService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public Instrument Create(CreateInstrumentDto dto)
        {
            //FileInfo imgFileInfo = new FileInfo(dto.Image);
            //string imgpath = Guid.NewGuid().ToString() + imgFileInfo.Extension;
            //string path = Path.Combine("Images", imgpath);
            //using (Stream stream = new FileStream(path, FileMode.Create))
            //{
            //    dto.Image.CopyTo(stream);
            //};
            var record = new Instrument() { Name = dto.Name, Quantity = dto.Quantity , Image = "null"};
            this.context.instruments.Add(record);
            this.context.SaveChanges();
            return record;
           
        }

        public Instrument Delete(int id)
        {
            var record = this.context.instruments.FirstOrDefault(r => r.Id == id);
            this.context.instruments.Remove(record);
            this.context.SaveChanges();
            return record;
        }

        public List<Instrument> GetAllInstruments()
        {
            return this.context.instruments.ToList();
        }

        public Instrument GetById(int id)
        {
            return this.context.instruments.FirstOrDefault(r => r.Id == id);
        }

        public Instrument Update(Instrument tool)
        {
            var record = this.context.instruments.FirstOrDefault(r => r.Id == tool.Id);
            record.Name = tool.Name; record.Quantity = tool.Quantity;
            this.context.instruments.Update(record);
            this.context.SaveChanges();
            return record;
            
        }
    }
}
