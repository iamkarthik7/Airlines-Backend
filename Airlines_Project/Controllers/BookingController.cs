using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Airlines_Project.Models;

namespace Airlines_Project.Controllers
{
    public class BookingController : ApiController
    {
        AirlinesEntities16 db = new AirlinesEntities16();
        // GET api/<controller>
        public IEnumerable<Bookingss> Get()
        {
            return db.Bookingsses.ToList();
        }

        // GET api/<controller>/5
        public Bookingss Get(int id)
        {
            
            return db.Bookingsses.Find(id);
        }
                
        // POST api/<controller>
        public HttpResponseMessage Post(Bookingss b)
        {
            try
            {
                db.Bookingsses.Add(b);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch(Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, Bookingss rs)
        {
            try
            {
                if (id == rs.ticketnumber)
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
                Bookingss m = db.Bookingsses.Find(id);
                if (m != null)
                {
                    db.Bookingsses.Remove(m);
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
    }
}