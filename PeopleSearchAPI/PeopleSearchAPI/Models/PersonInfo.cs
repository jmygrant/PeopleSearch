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
		/// <summary>
		/// Store the street address of a person.
		/// </summary>
		public string StreetAddressLine01 { get; set; } = "";
		/// <summary>
		/// Another line for street address if needed.
		/// </summary>
		public string StreetAddressLine02 { get; set; } = "";
		/// <summary>
		/// Store the City.
		/// </summary>
		public string City { get; set; } = "";
		/// <summary>
		/// Store the State.
		/// </summary>
		public string State { get; set; } = "";
		/// <summary>
		/// Store the zipcode.
		/// </summary>
		public string ZipCode { get; set; } = "";

	}
}
