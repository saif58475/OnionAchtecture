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
    public interface IConsumber
    {
        Response<List<Consumber>> GetAllConsumbers();
        Response<Consumber> Create(CreateConsumberDto dto);
        Response<Consumber> GetById(int id);
        Response<Consumber> Update(Consumber rec);
        Response<Consumber> Delete(int id);
    }
}
