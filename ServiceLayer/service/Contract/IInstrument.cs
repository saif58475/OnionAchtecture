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
    public interface IInstrument
    {
        //get all instruments
        Response<List<Instrument>> GetAllInstruments();
        //create instrument
        Response<Instrument> Create(CreateInstrumentDto dto);
        //get by id
        Response<Instrument> GetById(int id);
        //update instrument
        Response<Instrument> Update(UpdateInstrumentDto tool);
        //delete the record
        Response<Instrument> Delete(int id);

    }
}
