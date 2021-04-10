using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public static List<Student> _studentlist { get; set; } = new List<Student>();
        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            return _studentlist;
        }

        [HttpGet("{id}")]
        public Student GetStudent(string id)
        {
            foreach (Student x in _studentlist)
            {
                if (x.numerIndeksu.Contains(id)) return x;
            }
            return null;
        }

        [HttpPut("{id}")]
        public HttpResponseMessage PutStudent(string id, [FromBody] Student opt)
        {
            var resp = new HttpResponseMessage();
            resp.StatusCode = (HttpStatusCode.Accepted);
            foreach (Student x in _studentlist) {
                Student temp = x;
                if (opt.nazwisko != null) temp.nazwisko = opt.nazwisko;
                if (opt.imie != null) temp.imie = opt.imie;
                if (opt.imie_matki != null) temp.imie_matki = opt.imie_matki;
                if (opt.imie_ojca != null) temp.imie_ojca = opt.imie_ojca;
                if (opt.studia != null) temp.studia = opt.studia;
                if (opt.tryb != null) temp.tryb = opt.tryb;
                if (opt.email != null) temp.email = opt.email;
                if (opt.dataUrodzenia != null) temp.dataUrodzenia = opt.dataUrodzenia;
                _studentlist.Remove(x);
                _studentlist.Add(temp);
                GenericToCSV.WriteCSV<Student>(_studentlist, Directory.GetCurrentDirectory() + "\\DB.csv");
                return resp;
            }
            resp.StatusCode = (HttpStatusCode.BadRequest);
            return resp;
        }

        [HttpPost]
        public HttpResponseMessage PostStudent([FromBody] Student opt)
        {

            var resp = new HttpResponseMessage();
            if (string.IsNullOrEmpty(opt?.numerIndeksu))
            {
                resp.StatusCode = (HttpStatusCode.BadRequest);
                return resp;
            }

            _studentlist.Add(opt);
            resp.StatusCode = (HttpStatusCode.Created);
            GenericToCSV.WriteCSV<Student>(_studentlist, Directory.GetCurrentDirectory() + "\\DB.csv");

            return resp;
        }


        [HttpDelete("{id}")]
        public string RemoveStudent(string id)
        {
            foreach (Student x in _studentlist)
            {
                if (x.numerIndeksu.Contains(id))
                {
                    _studentlist.Remove(x);
                    GenericToCSV.WriteCSV<Student>(_studentlist, Directory.GetCurrentDirectory() + "\\DB.csv");
                    return "removed " + id;
                }
            }
            GenericToCSV.WriteCSV<Student>(_studentlist, Directory.GetCurrentDirectory() + "\\DB.csv");
            return "Not Found:" + id;
        }
    }
}