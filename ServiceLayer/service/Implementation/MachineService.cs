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
    public class MachineService : IMachine
    {
        private readonly ApplicationDbContext _context;
        public MachineService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Machine Create(CreateMachineDto dto)
        {
            FileInfo imgFileInfo = new FileInfo(dto.Image.FileName);
            string imgpath = Guid.NewGuid().ToString() + imgFileInfo.Extension;
            string path = Path.Combine("F:/Clinic BackEnd/DentClinic/DentClinic/assets/Images/Machines", imgpath);
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                dto.Image.CopyTo(stream);
            };
            var record = new Machine() { Name = dto.Name, Quantity = dto.Quantity, Image = path};
            this._context.machines.Add(record);
            this._context.SaveChanges();
            return record;

        }

        public Machine Delete(int id)
        {
            var record = this._context.machines.FirstOrDefault(r => r.Id == id);
            this._context.machines.Remove(record);
            this._context.SaveChanges();
            return record;
        }

        public List<Machine> GetAllMAchines()
        {
            return this._context.machines.ToList();
        }

        public Machine GetById(int id)
        {
            return this._context.machines.FirstOrDefault(r => r.Id == id);
        }

        public Machine Update(Machine dto)
        {
            var record = this._context.machines.FirstOrDefault(r => r.Id == dto.Id);
            record.Name = dto.Name;record.Quantity = dto.Quantity;
            this._context.machines.Update(record);
            this._context.SaveChanges();
            return record;
        }
    }
}
