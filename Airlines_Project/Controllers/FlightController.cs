using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Airlines_Project.Models;
using Airlines_Project.VM;

namespace Airlines_Project.Controllers
{
    public class FlightController : ApiController
    {
        AirlinesEntities5 db = new AirlinesEntities5();
        // GET api/<controller>
        public IEnumerable<Flightdetail> Get()
        {
            return db.Flightdetails.ToList();
        }

        // GET api/<controller>/5
        public Flightdetail Get(int id)
        {
            return db.Flightdetails.Find(id);
        }

        // POST api/<controller>

        // PUT api/<controller>/5
        public HttpResponseMessage Post(Flightdetail b)
        {
            try
            {
                db.Flightdetails.Add(b);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, Flightdetail rs)
        {
            try
            {
                if (id == rs.flightid)
                {
                    db.Entry(rs).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Flightdetail m = db.Flightdetails.Find(id);
                if (m != null)
                {
                    db.Flightdetails.Remove(m);
                    db.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        [HttpGet]
        public IEnumerable<Flightdetail> Get([FromUri] string from, [FromUri] string to)
        {
            var selectedFlights = db.Flightdetails.Where(i => i.ffrom == from && i.fto == to);
            return selectedFlights;
        }
    }
}