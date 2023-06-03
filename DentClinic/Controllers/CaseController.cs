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
    public class CaseController : ControllerBase
    {
        private readonly ICase _case;

        public CaseController(ICase caseee)
        {
            _case = caseee;
        }

        [HttpGet]
        [Route("GetAllCases")]
        public Response<List<Case>> GetAllCases()
        {
            return this._case.GetAllCases();
        }
        [HttpGet]
        [Route("GetById")]
        public Response<Case> GetById(int id)
        {
            return this._case.GetById(id);
        }
        [HttpPost]
        [Route("Create")]
        public Response<Case> Create(CreateCaseDto dto)
        {
            return this._case.Create(dto);
        }
        [HttpPut]
        [Route("Update")]
        public Response<Case> Update(Case rec)
        {
            return this._case.Update(rec);
        }
        [HttpDelete]
        [Route("Delete")]
        public Response<Case> Delete(int id)
        {
            return this._case.Delete(id);
        }
    }
}
