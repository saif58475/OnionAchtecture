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
    public class InstrumentController : ControllerBase
    {
        private readonly IInstrument instrument;
        public InstrumentController(IInstrument _instrument)
        {
            this.instrument = _instrument;
        }
        [HttpGet]
        [Route("GetAllInstruments")]
        public List<Instrument> GetAllInstruments()
        {
            return this.instrument.GetAllInstruments();
        }
        [HttpGet]
        [Route("GetById")]
        public Instrument GetById(int id)
        {
            return this.instrument.GetById(id);
        }
        [HttpPost]
        [Route("Create")]
        public Instrument Create(CreateInstrumentDto dto)
        {
            return this.instrument.Create(dto);
        }
        [HttpPut]
        [Route("Update")]
        public Instrument Update(Instrument record)
        {
            return this.instrument.Update(record);
        }
        [HttpDelete]
        [Route("Delete")]
        public Instrument Delete(int id)
        {
            return this.instrument.Delete(id);
        }
    }
}
