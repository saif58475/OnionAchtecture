using DomainLayer.Dtos;
using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.service.Contract
{
    public interface IMachine
    {
        List<Machine> GetAllMAchines();
        Machine GetById(int id);
        Machine Create(CreateMachineDto dto);
        Machine Update(Machine dto);
        Machine Delete(int id);
    }
}
