using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Airlines_Project.Models;
namespace Airlines_Project.Controllers
{
    public class ContactUsController : ApiController
    {
        AirlinesEntities3 db = new AirlinesEntities3();
        // GET api/<controller>
        public IEnumerable<ContactU> Get()
        {
            return db.ContactUs.ToList();
        }

        // GET api/<controller>/5
        public ContactU Get(int id)
        {
            return db.ContactUs.Find(id);
        }

        // POST api/<controller>
        public HttpResponseMessage Post(ContactU cu)
        {
            try
            {
                db.ContactUs.Add(cu);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, ContactU rs)
        {
            try
            {
                if (id == rs.contactid)
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
                ContactU m = db.ContactUs.Find(id);
                if (m != null)
                {
                    db.ContactUs.Remove(m);
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