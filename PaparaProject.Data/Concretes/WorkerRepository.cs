using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PaparaProject.Data.Abstracts;
using PaparaProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProject.Data.Concretes
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly IConfiguration configuration;

        public WorkerRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Add(Worker entity)
        {
            entity.Status = true;
            entity.CreatedDate = DateTime.Now;
            var query = "INSERT INTO Workers (FirstName,LastName,Gender,BirthDate,Department,Mail,Phone, Status, CreatedDate) VALUES (@FirstName,@LastName,@Gender,@BirthDate,@Department,@Mail,@Phone,@Status,@CreatedDate)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = connection.Execute(query, entity);
            }
        }

        public int Delete(int id)
        {
            var query = "UPDATE Workers SET Status = 0  WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = connection.Execute(query, new {Id =id});
                return result;
            }

        }

        public List<Worker> GetAll()
        {
            var query = "SELECT * FROM Workers WHERE Status=1";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = connection.Query<Worker>(query);
                return result.ToList();
            }
        }

        public Worker GetById(int id)
        {
            var query = "SELECT * FROM Workers WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = connection.QuerySingleOrDefault<Worker>(query, new { Id = id });
                return result;
            }
        }

        public int HardDelete(int id)
        {
            var query = "DELETE FROM Workers WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = connection.Execute(query, new { Id = id });
                return result;
            }
        }

        public int Update(Worker entity, int id)
        {
            var query = $"UPDATE Workers SET FirstName = @FirstName, LastName = @LastName, Gender = @Gender, BirthDate = @BirthDate, Department = @Department, Mail = @Mail, Phone = @Phone  WHERE Id = {id}";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = connection.Execute(query, entity);
                return result;
            }
        }
    }
}
