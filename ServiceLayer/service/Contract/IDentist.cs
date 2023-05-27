using DomainLayer.Dtos;
using DomainLayer.Model;
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
        Dentist GetById(int id);
        //get all the dentists
        List<Dentist> GetAllDentists();
        //Create a dentist
        CreateDentistDto AddDentist(CreateDentistDto dentist);
        //update dentist
        Dentist UpdateDentist(Dentist dentist);
        //delete specific record
        Dentist Delete(int id);
    }
}
