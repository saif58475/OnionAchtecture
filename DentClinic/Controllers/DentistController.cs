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
    public class DentistController : ControllerBase
    {
        private readonly IDentist _dentist;
        public DentistController(IDentist dentist)
        {
            this._dentist = dentist;
        }
        [HttpGet]
        [Route("GetAllDentists")]
        public List<Dentist> GetAllDetists()
        {
           var records = this._dentist.GetAllDentists();
            return records;
        }
        [HttpGet]
        [Route("GetById")]
        public Dentist GetById(int id)
        {
            var record = this._dentist.GetById(id);
            return record;
        }
        [HttpPost]
        [Route("Create")]
        public CreateDentistDto CreateDentist(CreateDentistDto dentist)
        {
            this._dentist.AddDentist(dentist);
            return dentist;
        }
        [HttpPut]
        [Route("Update")]
        public Dentist Update(Dentist dentist)
        {
           var record = this._dentist.UpdateDentist(dentist);
            return record;
        }
        [HttpDelete]
        [Route("Delete")]
        public string Delete(int id)
        {
            this._dentist.Delete(id);
            return "Deleted Successfully";
        }
     }
}
