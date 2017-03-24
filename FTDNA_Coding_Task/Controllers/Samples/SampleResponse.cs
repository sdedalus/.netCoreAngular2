using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FTDNA_Coding_Task.Controllers.Samples
{
    public class SampleResponse
    {
		/// <summary>
		/// Gets or sets the sample identifier.
		/// </summary>
		/// <value>
		/// The sample identifier.
		/// </value>
		public int SampleId { get; set; }

		/// <summary>
		/// Gets or sets the barcode.
		/// </summary>
		/// <value>
		/// The barcode.
		/// </value>
		public string Barcode { get; set; }

		/// <summary>
		/// Gets or sets the datetime the sample was created.
		/// </summary>
		/// <value>
		/// The created at.
		/// </value>
		public string CreatedAt { get; set; }

		/// <summary>
		/// Gets or sets the first name.
		/// </summary>
		/// <value>
		/// The first name.
		/// </value>
		public string FirstName { get; set; }

		/// <summary>
		/// Gets or sets the last name.
		/// </summary>
		/// <value>
		/// The last name.
		/// </value>
		public string LastName { get; set; }

		/// <summary>
		/// Gets or sets the status identifier.
		/// </summary>
		/// <value>
		/// The status identifier.
		/// </value>
		public string Status { get; set; }
	}
}
