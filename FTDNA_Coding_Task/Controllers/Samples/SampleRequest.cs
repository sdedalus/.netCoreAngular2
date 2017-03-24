using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FTDNA_Coding_Task.Controllers.Samples
{
    public class SampleRequest
    {
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
		public int CreatedBy { get; set; }

		/// <summary>
		/// Gets or sets the status identifier.
		/// </summary>
		/// <value>
		/// The status identifier.
		/// </value>
		public int StatusId { get; set; }
	}
}
