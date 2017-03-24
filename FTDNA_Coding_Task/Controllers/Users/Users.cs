using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FTDNA_Coding_Task.Data;

using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FTDNA_Coding_Task.Controllers.Users
{
	[Route("api/[controller]")]
    public class Users : Controller
    {
		private readonly DatabaseContext context = new DatabaseContext();

		// GET: api/Samples
		[HttpGet]
        public IEnumerable<UserResponse> Get()
		{
			var results = context.User.Select(v => new UserResponse()
			{
				Id = v.UserId,
				UserName = $"{v.FirstName} {v.LastName}" 
			});

			return results;
		}
    }
}
