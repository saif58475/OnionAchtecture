using DomainLayer.Dtos;
using DomainLayer.Model;
using ServiceLayer.service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.service.Contract
{
    public interface IMachine
    {
        Response<List<Machine>> GetAllMAchines();
        Response<Machine> GetById(int id);
        Response<Machine> Create(CreateMachineDto dto);
        Response<Machine> Update(UpdateMachineDto dto);
        Response<Machine> Delete(int id);
    }
}
