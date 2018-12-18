using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleSearchAPI.Models
{
	public class PersonInfo
	{
		/// <summary>
		/// The Id from SQL Server.
		/// </summary>
		public int Id { get; set; } = 0;
		/// <summary>
		/// The First Name of a person.
		/// </summary>
		public string FirstName { get; set; } = "";
		/// <summary>
		/// The Last name of a person.
		/// </summary>
		public string LastName { get; set; } = "";
	}
}
