using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FTDNA_Coding_Task.Data;

using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FTDNA_Coding_Task.Controllers.Statuses
{

	[Route("api/[controller]")]
    public class Statuses : Controller
    {
		private readonly DatabaseContext context = new DatabaseContext();

		// GET: api/Samples
		[HttpGet]
        public IEnumerable<StatusReponse> Get()
		{
			var results = context.Statuses.Select(v => new StatusReponse()
			{
				Id = v.StatusId,
				Status = v.Status
			});

			return results;
		}
    }
}
