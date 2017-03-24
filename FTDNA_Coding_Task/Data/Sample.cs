using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FTDNA_Coding_Task.Data
{
    public class Sample
    {
		/// <summary>
		/// Gets or sets the sample identifier.
		/// </summary>
		/// <value>
		/// The sample identifier.
		/// </value>
		public int? SampleId { get; set; }
		
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
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// Gets or sets who the sample is created by.
		/// </summary>
		/// <value>
		/// The created by.
		/// </value>
		public User CreatedBy { get; set; }

		/// <summary>
		/// Gets or sets the created by identifier.
		/// </summary>
		/// <value>
		/// The created by identifier.
		/// </value>
		public int CreatedById { get; set; }

		/// <summary>
		/// Gets or sets the status identifier.
		/// </summary>
		/// <value>
		/// The status identifier.
		/// </value>
		public SampleStatus Status { get; set; }

		/// <summary>
		/// Gets or sets the status identifier.
		/// </summary>
		/// <value>
		/// The status identifier.
		/// </value>
		public int StatusId { get; set; }
	}
}
