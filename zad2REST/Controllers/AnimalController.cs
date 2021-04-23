using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Http;
using WebApplication1.Models;
using zad2REST;

namespace WebApplication1.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        List<Animal> animals = new List<Animal>();
        
        [HttpGet]
        public IEnumerable<Animal> GetAnimals()
        {
            SqlConnection sql = SQLConnection.GetDBConnection("db-mssql16.pjwstk.edu.pl");
            string sqlCommand = "SELECT TOP (1000) [IdAnimal],[Name],[Description],[Category],[Area] FROM[s18807].[dbo].[Animal]";
            using (SqlCommand command = new SqlCommand(sqlCommand, sql))
            {
                sql.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Animal a = new Animal();
                        a.IdAnimal = (int)reader.GetValue(0);
                        a.Name = reader.GetString(1);
                        a.Description = reader.GetString(2);
                        a.Category = reader.GetString(3);
                        a.Area = reader.GetString(4);
                        animals.Add(a);
                    }
                    return animals;
                }
            }
            return null;
        }



        [HttpGet("{orderBy}")]
        public IEnumerable<Animal> GetAnimals(string orderBy)
        {
            SqlConnection sql= SQLConnection.GetDBConnection("db-mssql16.pjwstk.edu.pl");
            string sqlCommand = "SELECT TOP (1000) [IdAnimal],[Name],[Description],[Category],[Area] FROM[s18807].[dbo].[Animal]";
            using (SqlCommand command = new SqlCommand(sqlCommand, sql))
            {
                sql.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Animal a = new Animal();
                        a.IdAnimal= (int)reader.GetValue(0);
                        a.Name= reader.GetString(1);
                        a.Description= reader.GetString(2);
                        a.Category= reader.GetString(3);
                        a.Area= reader.GetString(4);
                        animals.Add(a);
                    }
                    return animals;
                }
            }
            return null;
        }

        [HttpPut("{id}")]
        public HttpResponseMessage PutAnimal(string id, [FromBody] Student opt)
        {
            var resp = new HttpResponseMessage();
            resp.StatusCode = (HttpStatusCode.Accepted);
            resp.StatusCode = (HttpStatusCode.BadRequest);
            return resp;
        }

        [HttpPost]
        public HttpResponseMessage PostAnimal([FromBody] Student opt)
        {

            var resp = new HttpResponseMessage();
            resp.StatusCode = (HttpStatusCode.Created);
            return resp;
        }


        [HttpDelete("{id}")]
        public string RemoveAnimal(string id)
        {
            return "Not Found:" + id;
        }
    }
}