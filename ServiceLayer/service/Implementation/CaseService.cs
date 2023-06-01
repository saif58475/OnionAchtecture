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
    public class CaseService : ICase
    {
        private readonly ApplicationDbContext context;
        public CaseService(ApplicationDbContext _context)
        {
            context = _context;
        }
        public Case Create(CreateCaseDto dto)
        {
            var record = new Case() { CaseName = dto.CaseName, Description = dto.Description };
            this.context.Cases.Add(record);
            this.context.SaveChanges();
            return record;
        }

        public Case Delete(int id)
        {
            var record = this.context.Cases.FirstOrDefault(r => r.Id == id);
            this.context.Cases.Remove(record);
            this.context.SaveChanges();
            return record;
        }

        public List<Case> GetAllCases()
        {
            var records = this.context.Cases.ToList();
            return records;
        }

        public Case GetById(int id)
        {
            return this.context.Cases.FirstOrDefault(r => r.Id == id);
        }

        public Case Update(Case rec)
        {
            var record = this.context.Cases.FirstOrDefault(r => r.Id == rec.Id);
            record.CaseName = rec.CaseName; record.Description = rec.Description;
            this.context.Cases.Update(record);
            this.context.SaveChanges();
            return record;
        }
    }
}
