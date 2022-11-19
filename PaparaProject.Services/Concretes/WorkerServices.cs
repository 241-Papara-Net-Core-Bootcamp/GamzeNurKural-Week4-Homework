using AutoMapper;
using PaparaProject.Data.Abstracts;
using PaparaProject.Domain.Entities;
using PaparaProject.Services.Abstracts;
using PaparaProject.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaparaProject.Services.Concretes
{
    public class WorkerServices : IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly IMapper _mapper;

        public WorkerServices(IWorkerRepository workerRepository, IMapper mapper)
        {
            _workerRepository = workerRepository;
            _mapper = mapper;
        }

        public void Add(WorkerDto workerDto)
        {
            var worker = _mapper.Map<Worker>(workerDto);
            _workerRepository.Add(worker);
        }

        public List<WorkerDto> GetAll()
        {
            var workers = _workerRepository.GetAll();
            var workerDto = _mapper.Map<List<WorkerDto>>(workers);
            return workerDto;
        }

        public WorkerDto GetById(int id)
        {
            var worker = _workerRepository.GetById(id);
            var workerDto = _mapper.Map<WorkerDto>(worker);
            return workerDto;
        }

        public void Update(WorkerDto workerDto, int id)
        {
            var worker = _workerRepository.GetById(id);
            var updatedWorker = _mapper.Map<Worker>(workerDto);
            _workerRepository.Update(updatedWorker, id);

        }

        public void Delete(int id)
        {
            _workerRepository.Delete(id);
        }

        public void HardDelete(int id)
        {
            var worker = _workerRepository.GetById(id);
            _workerRepository.HardDelete(id);
        }
    }
}
