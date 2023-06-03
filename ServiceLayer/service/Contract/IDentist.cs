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
    public interface IDentist
    {
        //get dentist by id 
        Response<Dentist> GetById(int id);
        //get all the dentists
        Response<List<Dentist>> GetAllDentists();
        //Create a dentist
        Response<Dentist> AddDentist(CreateDentistDto dentist);
        //update dentist
        Response<Dentist> UpdateDentist(Dentist dentist);
        //delete specific record
        Response<Dentist> Delete(int id);
    }
}
