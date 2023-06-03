using DomainLayer.Dtos;
using DomainLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.service.Contract;
using ServiceLayer.service.Implementation;

namespace DentClinic.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumberController : ControllerBase
    {
        private readonly IConsumber consumber;
        public ConsumberController(IConsumber _consumber)
        {
            consumber = _consumber;
        }

        [HttpGet]
        [Route("GetAllConsumbers")]
        public Response<List<Consumber>> GetAllConsumber()
        {
            return this.consumber.GetAllConsumbers();
        } 
        [HttpGet]
        [Route("GetById")]
        public Response<Consumber> GetById(int id)
        {
            return this.consumber.GetById(id);
        }
        [HttpPost]
        [Route("Create")]
        public Response<Consumber> Create(CreateConsumberDto dto)
        {
            return this.consumber.Create(dto);
        }
        [HttpPut]
        [Route("Update")]
        public Response<Consumber> Update(Consumber rec)
        {
            return this.consumber.Update(rec);
        }
        [HttpDelete]
        [Route("Delete")]
        public Response<Consumber> Delete(int id)
        {
            return this.consumber.Delete(id);
        }
    }
}
