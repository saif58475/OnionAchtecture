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
    public class DentistService : IDentist
    {
        private readonly ApplicationDbContext context;
        public DentistService(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        public CreateDentistDto AddDentist(CreateDentistDto dentist)
        {
            var record = new Dentist();
            record.Name = dentist.Name;
            record.Age = dentist.Age;
            record.Major = dentist.Major;
            this.context.dentists.Add(record);
            this.context.SaveChanges();
            return dentist;
        }

        public Dentist Delete(int id)
        {
            var record = this.context.dentists.FirstOrDefault(r => r.Id == id);
            this.context.dentists.Remove(record);
            this.context.SaveChanges();
            return record;
        }

        public List<Dentist> GetAllDentists()
        {
            return this.context.dentists.ToList();
        }

        public Dentist GetById(int id)
        {
            var record = this.context.dentists.FirstOrDefault(r => r.Id == id);
            return record;
        }

        public Dentist UpdateDentist(Dentist dentist)
        {
            var record = this.context.dentists.FirstOrDefault(r => r.Id == dentist.Id);
            record.Name = dentist.Name;
            record.Age = dentist.Age;
            record.Major = dentist.Major;
            this.context.dentists.Update(record);
            this.context.SaveChanges();
            return record;
        }
    }
}
