using Microsoft.AspNetCore.Mvc;
using DAL.Interfaces;
using Entities.Entities;
using DAL.Implementations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private IRoleDAL roleDAL;

        public RoleController()
        {
            roleDAL = new RoleDALImpl();
        }

        // GET: api/<RoleController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Role> roles = roleDAL.GetAll();
            return new JsonResult(roleDAL);
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Role role = roleDAL.Get(id);

            return new JsonResult(role);
        }

        // POST api/<RoleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
