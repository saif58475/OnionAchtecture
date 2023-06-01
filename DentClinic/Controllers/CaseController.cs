using DomainLayer.Dtos;
using DomainLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.service.Contract;

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
        public List<Case> GetAllCases()
        {
            return this._case.GetAllCases();
        }
        [HttpGet]
        [Route("GetById")]
        public Case GetById(int id)
        {
            return this._case.GetById(id);
        }
        [HttpPost]
        [Route("Create")]
        public Case Create(CreateCaseDto dto)
        {
            return this._case.Create(dto);
        }
        [HttpPut]
        [Route("Update")]
        public Case Update(Case rec)
        {
            return this._case.Update(rec);
        }
        [HttpDelete]
        [Route("Delete")]
        public Case Delete(int id)
        {
            return this._case.Delete(id);
        }
    }
}
