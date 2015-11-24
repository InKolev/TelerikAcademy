namespace StudentSystem.Services.Controllers
{
    using Data.Contracts;
    using Data;
    using System.Data.Entity;
    using System.Web;
    using System.Web.Http;

    public class StudentsController : ApiController
    {
        private IStudentSystemDbContext db = new StudentSystemDbContext();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return this.Ok(db.Students.ToListAsync());
        }

        [HttpGet]
        public IHttpActionResult Find(int id)
        {
            return this.Ok();
        }

        public IHttpActionResult Find(string fullname)
        {
            return this.Ok();
        }

        public void Put()
        {

        }
    }
}
