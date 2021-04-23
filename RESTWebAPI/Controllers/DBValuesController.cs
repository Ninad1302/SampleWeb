using JournalDataAccess;
using RESTWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace RESTWebAPI.Controllers
{
    public class DBValuesController : ApiController
    {
        //[Route("")]
        //[Route("Home")]
        //[Route("Home/Index")]
        public IEnumerable<Sales_Journal> Get()
        {
            using (SampleDatabaseEntities entities = new SampleDatabaseEntities())
            {
                return entities.Sales_Journal.ToList();
            }
        }

        public Sales_Journal Get(int id)
        {
            using (SampleDatabaseEntities entities = new SampleDatabaseEntities())
            {
                return entities.Sales_Journal.FirstOrDefault(e => e.Transaction_ID == id);
            }
        }

        public IHttpActionResult PutJournal(int id, [FromBody] Sales_Journal objSJ)
        {
            using (SampleDatabaseEntities entities = new SampleDatabaseEntities())
            {
                Sales_Journal objOldSJ = entities.Sales_Journal.Find(id);
                if (objOldSJ != null && objOldSJ.Transaction_ID.Equals(objSJ.Transaction_ID))
                {
                    entities.Entry(objOldSJ).State = System.Data.Entity.EntityState.Detached;
                    entities.Entry(objSJ).State = System.Data.Entity.EntityState.Modified;
                    entities.SaveChanges();
                    return Ok(objSJ);
                }
                return NotFound();
            }
        }

        public Sales_Journal PostJournal([FromBody] Sales_Journal objSJ)
        {
            if (objSJ == null)
                return null;

            using (SampleDatabaseEntities entities = new SampleDatabaseEntities())
            {
                try
                {
                    entities.Sales_Journal.Add(objSJ);
                    entities.SaveChanges();
                    return objSJ;
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException)
                {
                    return null;
                }
            }
        }

        public IHttpActionResult DeleteJournal(int id)
        {
            using (SampleDatabaseEntities entities = new SampleDatabaseEntities())
            {
                Sales_Journal sj = entities.Sales_Journal.Find(id);
                if (sj == null)
                    return NotFound();

                entities.Sales_Journal.Remove(sj);
                entities.SaveChanges();
                return Ok();
            }
        }
    
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "GET - value is " + id;
        //}

        //// POST api/<controller>
        //public string Post([FromBody] string value)
        //{
        //    return "POST - value is " + value;
        //}

        //// PUT api/<controller>/5
        //public string Put(int id, [FromBody] string value)
        //{
        //    return "PUT - id is " + id + " value is " + value;
        //}

        //// DELETE api/<controller>/5
        //public string Delete(int id)
        //{
        //    return "DELETE - id is " + id;
        //}
    }
}