using DomainLayer.Dtos;
using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.service.Contract
{
    public interface ICase
    {
        List<Case> GetAllCases();
        Case Create(CreateCaseDto dto);
        Case Update(Case dto);
        Case GetById(int id);
        Case Delete(int id);

    }
}
