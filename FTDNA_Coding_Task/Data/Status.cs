using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FTDNA_Coding_Task.Data
{
    public class SampleStatus
	{
		/// <summary>
		/// Gets or sets the user identifier.
		/// </summary>
		/// <value>
		/// The status identifier.
		/// </value>
		public int StatusId { get; set; }

		/// <summary>
		/// Gets or sets the status 
		/// </summary>
		/// <value>
		/// The first name.
		/// </value>
		public string Status { get; set; }

		/// <summary>
		/// Gets or sets the samples.
		/// </summary>
		/// <value>
		/// The samples.
		/// </value>
		public List<Sample> Samples { get; set; }
	}
}
