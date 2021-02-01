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
    [RoutePrefix("Api/Register")]
    public class RegisterController : ApiController
    {
        AirlinesEntities4 db = new AirlinesEntities4();
        // GET api/<controller>
        public IEnumerable<Register> Get()
        {
            return db.Registers.ToList();
        }

        // GET api/<controller>/5
        public Register Get(int id)
        {
            return db.Registers.Find(id);
        }

        // POST api/<controller>
     
        [HttpPost]
        public HttpResponseMessage Post(Register rs)
        {
            try
            {
                db.Registers.Add(rs);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch(Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, Register rs)
        {
            try
            {
                if (id == rs.Passinger_Id)
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
                Register m = db.Registers.Find(id);
                if (m != null)
                {
                    db.Registers.Remove(m);
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

        [Route("Login")]
        [HttpPost]
        public Response CustomerLogin(Login login)
        {
            var log = db.Registers.Where(x => x.Email.Equals(login.Email) && x.Password.Equals(login.Password)).FirstOrDefault();
            if (log == null)
            {
                return new Response { Status = "Invalid", Message = "Invalid User." };
            }
            else
                return new Response { Status = "Success", Message = "Login Successfully" };
        }
    }
}