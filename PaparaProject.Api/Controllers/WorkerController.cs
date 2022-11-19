using PaparaProject.Domain.Entities;
using PaparaProject.Services.Abstracts;
using PaparaProject.Services.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection.Metadata.Ecma335;
using AutoMapper;

namespace PaparaProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService, IMapper mapper)
        {
            _workerService = workerService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _workerService.GetAll();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _workerService.GetById(id);
            if (result != null)
                return Ok(result);
            return BadRequest("Worker with this id not found.");
        }

        [HttpPost]
        public IActionResult Post(WorkerDto workerDto)
        {
            _workerService.Add(workerDto);
            return Ok(workerDto);
        }

        [HttpPut]
        public IActionResult Update(WorkerDto workerDto, int id)
        {
            var result = _workerService.GetById(id);
            if (result == null)
                return BadRequest("Worker with this id not found.");
            _workerService.Update(workerDto, id);
            return Ok(workerDto);
        }

        [HttpPut("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _workerService.GetById(id);
            if (result == null)
                return BadRequest("Worker with this id not found.");
            _workerService.Delete(id);
            return Ok();
        }        
        
        [HttpDelete]
        public IActionResult HardDelete(int id)
        {
            var result = _workerService.GetById(id);
            if (result == null)
                return BadRequest("Worker with this id not found.");
            _workerService.HardDelete(id);
            return Ok();
        }
    }
}
