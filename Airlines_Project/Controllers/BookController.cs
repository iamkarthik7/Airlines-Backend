 using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Airlines_Project.Models;

namespace Airlines_Project.Controllers
{
    public class BookController : ApiController
    {
        AirlinesEntities20 db = new AirlinesEntities20();
        // GET api/<controller>
        public IEnumerable<Book> Get()
        {
            return db.Books.ToList();
        }

        // GET api/<controller>/5
        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Book tc)
        {
            try
            {
                db.Books.Add(tc);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, Book tc)
        {
            try
            {
                if (id == tc.ticketnumber)
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
                Book m = db.Books.Find(id);
                if (m != null)
                {
                    db.Books.Remove(m);
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
        public IEnumerable<Book> Get([FromUri] string mail)
        {
            var selectPassenger = db.Books.Where(i => i.email == mail);
            return selectPassenger;
        }
    }
}