using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossLoggerDataManager.Data;
using CrossLoggerDataManager.Models;
using CrossLoggerDataManager.Processors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrossLoggerDataManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalRecordController : ControllerBase
    {
        private AppDbContext database;

        public PersonalRecordController(AppDbContext _database)
        {
            database = _database;
        }

        [HttpPost("addexcerise")]
        public string AddExercise(PersonalRecord record, string userTag)
        {

            return PersonalRecordProcessor.Create(database, record);
        }
        //// GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}