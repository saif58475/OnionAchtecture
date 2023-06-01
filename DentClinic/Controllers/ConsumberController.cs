﻿using DomainLayer.Dtos;
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
    public class ConsumberController : ControllerBase
    {
        private readonly IConsumber consumber;
        public ConsumberController(IConsumber _consumber)
        {
            consumber = _consumber;
        }

        [HttpGet]
        [Route("GetAllConsumbers")]
        public List<Consumber> GetAllConsumber()
        {
            return this.consumber.GetAllConsumbers();
        }
        [HttpGet]
        [Route("GetById")]
        public Consumber GetById(int id)
        {
            return this.consumber.GetById(id);
        }
        [HttpPost]
        [Route("Create")]
        public Consumber Create(CreateConsumberDto dto)
        {
            return this.consumber.Create(dto);
        }
        [HttpPut]
        [Route("Update")]
        public Consumber Update(Consumber rec)
        {
            return this.consumber.Update(rec);
        }
        [HttpDelete]
        [Route("Delete")]
        public Consumber Delete(int id)
        {
            return this.consumber.Delete(id);
        }
    }
}
