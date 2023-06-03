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
    public class DentistController : ControllerBase
    {
        private readonly IDentist _dentist;
        public DentistController(IDentist dentist)
        {
            this._dentist = dentist;
        }
        [HttpGet]
        [Route("GetAllDentists")]
        public Response<List<Dentist>> GetAllDetists()
        {
           var records = this._dentist.GetAllDentists();
            return records;
        }
        [HttpGet]
        [Route("GetById")]
        public Response<Dentist> GetById(int id)
        {
            var record = this._dentist.GetById(id);
            return record;
        }
        [HttpPost]
        [Route("Create")]
        public Response<Dentist> CreateDentist(CreateDentistDto dentist)
        {  
            return this._dentist.AddDentist(dentist);
        }
        [HttpPut]
        [Route("Update")]
        public Response<Dentist> Update(Dentist dentist)
        {
            return this._dentist.UpdateDentist(dentist);
        }
        [HttpDelete]
        [Route("Delete")]
        public Response<Dentist> Delete(int id)
        {
            return this._dentist.Delete(id);
        }
     }
}
