using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication4.Model;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ILogger<CustomerController> _logger;
        private DBconnect context;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        // select 관련 Get Code
        [HttpGet]
        [Produces("application/json", Type = typeof(Customer_Data))]
        [Consumes("application/json")]
        public IEnumerable<Customer_Data> Get()
        {
            context = HttpContext.RequestServices.GetService(typeof(DBconnect)) as DBconnect;
            List<Customer_Data> list = context.GetData();
            return list;
        }

        // Insert 관련 Post Code
        [HttpPost]
//        [Produces("application/json", Type = typeof(Customer_Data))]
        [Produces("application/json")]
        [Consumes("application/json")]
        public IActionResult Post([FromBody] Customer_Data customer)
        {
            context = HttpContext.RequestServices.GetService(typeof(DBconnect)) as DBconnect;
            if (context.Insert(customer) == null) return BadRequest();
            return Ok();
        }

        // Update 관련 Put Code
        [HttpPut("{id}")]
        [Produces("application/json", Type = typeof(Customer_Data))]
        [Consumes("application/json")]
        public IActionResult Put(int id, [FromBody] Customer_Data customer)
        {
            context = HttpContext.RequestServices.GetService(typeof(DBconnect)) as DBconnect;
            if(context.Update(id, customer) == null) return BadRequest();
            return Ok();
        }
        
        // Delete 관련 Delete Code
        [HttpDelete("{id}")]
        [Produces("application/json", Type = typeof(Customer_Data))]
        [Consumes("application/json")]
        
        public IActionResult Delete(int id)
        {
            context = HttpContext.RequestServices.GetService(typeof(DBconnect)) as DBconnect;
            if(context.Delete(id) == -1) return BadRequest();
            return Ok();
        }
    }
}
