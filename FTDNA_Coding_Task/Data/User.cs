using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FTDNA_Coding_Task.Data
{
    public class User
    {
		/// <summary>
		/// Gets or sets the user identifier.
		/// </summary>
		/// <value>
		/// The user identifier.
		/// </value>
		public int UserId { get; set; }

		/// <summary>
		/// Gets or sets the user first name
		/// </summary>
		/// <value>
		/// The first name.
		/// </value>
		public string FirstName { get; set; }

		/// <summary>
		/// Gets or sets the user last name
		/// </summary>
		/// <value>
		/// The last name
		/// </value>
		public string LastName { get; set; }

		/// <summary>
		/// Gets or sets the samples.
		/// </summary>
		/// <value>
		/// The samples.
		/// </value>
		public List<Sample> Samples { get; set; }
	}
}
