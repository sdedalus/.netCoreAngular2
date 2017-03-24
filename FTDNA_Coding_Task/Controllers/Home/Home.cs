using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FTDNA_Coding_Task.Controllers
{
    [Route("api/[controller]")]
    public class Home : Controller
    {
		// GET api/values
		/// <summary>
		/// This end point is here to support hypertext requirements of REST 
		/// it acts as a single entrypoint to client side applications and promotes 
		/// loose coupling between resources and resource designators.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
        public ActionResult Get()
        {
			// anonimous objects were used in the interest of time.
			return Json(new
			{
				_links = new {
					self = new { href = "api/home" } ,
					samples = new { href = "api/samples?{id}{barcode}{createdAt}{createdBy}{statusId}" },
					users = new { href = "api/users" },
					stasuses = new { href = "api/statuses" }
				}
			});

		}
    }
}
