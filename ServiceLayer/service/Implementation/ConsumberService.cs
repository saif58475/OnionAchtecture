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
    public class ConsumberService : IConsumber
    {
        private readonly ApplicationDbContext context;
        public ConsumberService(ApplicationDbContext _context)
        {
            context = _context;
        }
        public Consumber Create(CreateConsumberDto dto)
        {
            var record = new Consumber()
            {
                ConsumberName = dto.ConsumberName,
                Quantity = dto.Quantity
            };
            this.context.Consumbers.Add(record);
            this.context.SaveChanges();
            return record;
        }

        public Consumber Delete(int id)
        {
            var record = this.context.Consumbers.FirstOrDefault(r => r.Id == id);
            this.context.Consumbers.Remove(record);
            this.context.SaveChanges();
            return record;
        }

        public List<Consumber> GetAllConsumbers()
        {
            var records = this.context.Consumbers.ToList();
            return records;
        }

        public Consumber GetById(int id)
        {
            return this.context.Consumbers.FirstOrDefault(r => r.Id == id);
        }

        public Consumber Update(Consumber rec)
        {
            var record = this.context.Consumbers.FirstOrDefault(r => r.Id == rec.Id);
            record.ConsumberName = rec.ConsumberName;record.Quantity = rec.Quantity;
            this.context.Update(record);
            this.context.SaveChanges();
            return record;
        }
    }
}
