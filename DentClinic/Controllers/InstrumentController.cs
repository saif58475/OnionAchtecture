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
    public class InstrumentController : ControllerBase
    {
        private readonly IInstrument instrument;
        public InstrumentController(IInstrument _instrument)
        {
            this.instrument = _instrument;
        }
        [HttpGet]
        [Route("GetAllInstruments")]
        public  Response<List<Instrument>> GetAllInstruments()
        {
            return this.instrument.GetAllInstruments();
        }
        [HttpGet]
        [Route("GetById")]
        public Response<Instrument> GetById(int id)
        {
            return this.instrument.GetById(id);
        }
        [HttpPost]
        [Route("Create")]
        public Response<Instrument> Create([FromForm] CreateInstrumentDto dto)
        {
            return this.instrument.Create(dto);
        }
        [HttpPut]
        [Route("Update")]
        public Response<Instrument> Update(Instrument record)
        {
            return this.instrument.Update(record);
        }
        [HttpDelete]
        [Route("Delete")]
        public Response<Instrument> Delete(int id)
        {
            return this.instrument.Delete(id);
        }
    }
}
