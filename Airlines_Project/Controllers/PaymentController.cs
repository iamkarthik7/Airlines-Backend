using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Airlines_Project.Models;

namespace Airlines_Project.Controllers
{
    public class PaymentController : ApiController
    {
        AirlinesEntities10 db = new AirlinesEntities10();
        // GET api/<controller>
        public IEnumerable<Payment> Get()
        {
            return db.Payments.ToList();
        }

        // GET api/<controller>/5
        public Payment Get(int id)
        {
            return db.Payments.Find(id);
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Payment p)
        {
            try
            {
                db.Payments.Add(p);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch(Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, Payment rs)
        {
            try
            {
                if (id == rs.paymentid)
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
                Payment m = db.Payments.Find(id);
                if (m != null)
                {
                    db.Payments.Remove(m);
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