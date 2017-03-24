using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FTDNA_Coding_Task.Data;

using Microsoft.EntityFrameworkCore;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FTDNA_Coding_Task.Controllers.Samples
{

	[Route("api/[controller]")]
    public class Samples : Controller
    {
		private readonly DatabaseContext context = new DatabaseContext();

		// GET: api/Samples
		[HttpGet]
        public IEnumerable<SampleResponse> Get(int? id = null, string barcode = null, DateTime? createdAt = null, int? createdBy = null, int? statusId = null)
		{
			var results = context.Samples.Include(v => v.CreatedBy).Include(v => v.Status)
				.AddOptionalQueryPart(() => id != null, p => p.Where(c => c.SampleId == id))
				.AddOptionalQueryPart(() => barcode != null, p => p.Where(c => c.Barcode == barcode))
				.AddOptionalQueryPart(() => createdAt != null, p => p.Where(c => c.CreatedAt == createdAt))
				.AddOptionalQueryPart(() => createdBy != null, p => p.Where(c => c.CreatedBy.UserId == createdBy))
				.AddOptionalQueryPart(() => statusId != null, p => p.Where(c => c.Status.StatusId == statusId))
				.Select(v => new SampleResponse()
				{
					Barcode = v.Barcode,
					CreatedAt = v.CreatedAt.ToString("yyyy-MM-dd"),
					FirstName = v.CreatedBy.FirstName,
					LastName = v.CreatedBy.LastName,
					SampleId = v.SampleId.Value,
					Status = v.Status.Status
				})
				.ToList();

			return results;
		}



		// GET api/Samples/5
		[HttpGet("{id}")]
        public Sample Get(int id)
        {
			return context
				.Samples
				.FirstOrDefault(c => c.SampleId == id);
        }

		[HttpPost]
		public IActionResult Post([FromBody]SampleRequest request)
		{
			if(context.Samples.Any(c=>c.Barcode == request.Barcode))
			{
				return new BadRequestResult();
			}

			var createdBy = context.User.FirstOrDefault(c => c.UserId == request.CreatedBy);
			var status = context.Statuses.FirstOrDefault(c => c.StatusId == request.StatusId);

			if (createdBy == null || status == null)
			{
				return new BadRequestResult();
			}
			var sample = new Sample()
			{
				Barcode = request.Barcode,
				CreatedAt = DateTime.Now,
				CreatedById = request.CreatedBy,
				CreatedBy = createdBy,
				StatusId = request.StatusId,
				Status = status
			};
			//context.Attach(sample);
			context.Samples.Add(sample);
			// if the database is locked try again
			// I don't care for this but there seems to be a bug in SQLite 
			try
			{
				context.SaveChanges();
			}
			catch (Exception)
			{
				context.SaveChanges();
				
			}
			return Ok();

		
		}
    }
}
