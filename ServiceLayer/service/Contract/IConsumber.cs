using DomainLayer.Dtos;
using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.service.Contract
{
    public interface IConsumber
    {
        List<Consumber> GetAllConsumbers();
        Consumber Create(CreateConsumberDto dto);
        Consumber GetById(int id);
        Consumber Update(Consumber rec);
        Consumber Delete(int id);
    }
}
