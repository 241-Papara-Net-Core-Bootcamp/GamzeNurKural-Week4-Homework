using PaparaProject.Domain.Entities;
using PaparaProject.Services.DTOs;
using System.Collections.Generic;

namespace PaparaProject.Services.Abstracts
{
    public interface IWorkerService
    {
        public List<WorkerDto> GetAll();
        public WorkerDto GetById(int id);
        public void Add(WorkerDto workerDto);
        public void Update(WorkerDto workerDto, int id);
        public void Delete(int id);
        public void HardDelete(int id);
    }
}
