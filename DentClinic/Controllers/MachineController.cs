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
    public class MachineController : ControllerBase
    {
        private readonly IMachine _imachine;
        public MachineController(IMachine imachine)
        {
            _imachine = imachine;
        }
        [HttpGet]
        [Route("GetAllMachines")]
        public Response<List<Machine>> GetAllMachines()
        {
            return this._imachine.GetAllMAchines();
        } 
        [HttpGet]
        [Route("GetById")]
        public Response<Machine> GetById(int id)
        {
            return this._imachine.GetById(id);
        }
        [HttpPost]
        [Route("Create")]
        public Response<Machine> Create([FromForm] CreateMachineDto dto)
        {
            return this._imachine.Create(dto);
        }
        [HttpPut]
        [Route("Update")]
        public Response<Machine> Update(Machine record)
        {
            return this._imachine.Update(record);
        }
        [HttpDelete]
        [Route("Delete")]
        public Response<Machine> Delete(int id)
        {
            return this._imachine.Delete(id);
        }
    }
}
