using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Airlines_Project.Models;

namespace Airlines_Project.Controllers
{
    public class TCancleController : ApiController
    {
        AirlinesEntities18 db = new AirlinesEntities18();
        // GET api/<controller>
        public IEnumerable<Cancle> Get()
        {
            return db.Cancles.ToList();
        }

        // GET api/<controller>/5
        public Cancle Get(int id)
        {
            return db.Cancles.Find(id);
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Cancle tc)
        {
            try
            {
                db.Cancles.Add(tc);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch(Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, Cancle tc)
        {
            try
            {
                if(id==tc.cancleid)
                {
                    db.Entry(tc).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);

                }
            }
            catch(Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Cancle m = db.Cancles.Find(id);
                if (m != null)
                {
                    db.Cancles.Remove(m);
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