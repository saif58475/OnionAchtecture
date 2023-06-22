using DomainLayer.Dtos;
using DomainLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.service.Contract;
using ServiceLayer.service.Implementation;

namespace DentClinic.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RelatedDiseaseController : ControllerBase
    {
        private readonly IRelatedDisease relatedDisease;
        public RelatedDiseaseController(IRelatedDisease _relatedDisease)
        {
            relatedDisease = _relatedDisease;
        }

        [HttpGet]
        [Route("GetAllRelatedDiseases")]
        public Response<List<RelatedDisease>> GetAllRelatedDiseases()
        {
            return this.relatedDisease.GetAllRelatedDiseases();
        }
        [HttpGet]
        [Route("GetById")]
        public Response<RelatedDisease> GetById(int id)
        {
            return this.relatedDisease.GetById(id);
        }
        [HttpPost]
        [Route("Create")]
        public Response<RelatedDisease> Create(CreateRelatedDiseasedto dto)
        {
             return this.relatedDisease.Create(dto);
        }
        [HttpPut]
        [Route("Update")]
        public Response<RelatedDisease> Update(RelatedDisease rec)
        {
            return this.relatedDisease.Update(rec);
        }
        [HttpDelete]
        [Route("Delete")]
        public Response<RelatedDisease> Delete(int id)
        {
            return this.relatedDisease.Delete(id);
        }
    }
}
