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
        List<Instrument> GetAllInstruments();
        //create instrument
        Instrument Create(CreateInstrumentDto dto);
        //get by id
        Instrument GetById(int id);
        //update instrument
        Instrument Update(Instrument tool);
        //delete the record
        Instrument Delete(int id);

    }
}
