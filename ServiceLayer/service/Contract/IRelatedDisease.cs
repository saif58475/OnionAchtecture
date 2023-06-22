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
    public interface IRelatedDisease
    {
        //GetAllRecords
        Response<List<RelatedDisease>> GetAllRelatedDiseases();
        //Create Related Disease
        Response<RelatedDisease> Create(CreateRelatedDiseasedto dto);
        //Update RElated Disease
        Response<RelatedDisease> Update(RelatedDisease record);
        //Get Related Disease by id
        Response<RelatedDisease> GetById(int id);
        //To Delete Related Disease 
        Response<RelatedDisease> Delete(int id);
    }
}
