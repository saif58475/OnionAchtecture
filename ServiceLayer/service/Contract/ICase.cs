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
    public interface ICase
    {
        Response<List<Case>> GetAllCases();
        Response<Case> Create(CreateCaseDto dto);
        Response<Case> Update(Case dto);
        Response<Case> GetById(int id);
        Response<Case> Delete(int id);

    }
}
