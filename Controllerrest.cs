using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;
using System.Linq;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace RestAPI
{
    [Route("api/etudiants")]
    public class Controllerrest : Controller
    {
        private MydbContexte dbService;


        public Controllerrest(MydbContexte dbContext)
        {
            dbService = dbContext;
        }

        [HttpGet]
        public IEnumerable<Etudiant> list()
        {
            return dbService.Etudiants;
        }

        [HttpGet("{Id}")]
        public Etudiant DetOne(long Id)
        {
            return dbService.Etudiants.FirstOrDefault(s => s.Id == Id);
        }

        [HttpPost]
        public Etudiant Save([FromBody] Etudiant student)
        {
            dbService.Etudiants.Add(student);
            dbService.SaveChanges();
            return student;
        }
        [HttpDelete("{Id}")]
        public void Delete(long Id)
        {
            Etudiant student = dbService.Etudiants.FirstOrDefault(s => s.Id == Id);
            dbService.Etudiants.Remove(student);
            dbService.SaveChanges();
        }

        [HttpPut("{Id}")]
        public Etudiant Update(int Id, [FromBody] Etudiant student)
        {
            student.Id = Id;
            dbService.Etudiants.Update(student);
            dbService.SaveChanges();
            return student;
        }
   }
}

