using PeopleSearchAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PeopleSearchAPI.Controllers
{
    public class PeopleController : ApiController
    {
		List<PersonInfo> people = new List<PersonInfo>();

		public PeopleController()
		{
			people.Add(new PersonInfo()
			{
				FirstName = "Tim",
				LastName = "Corey",
				Id = 1,
				StreetAddressLine01 = "111 First St",
				City = "Kaysville",
				State = "UT",
				ZipCode = "84037"
			});
			people.Add(new PersonInfo()
			{
				FirstName = "Sue",
				LastName = "Storm",
				Id = 2,
				StreetAddressLine01 = "C/O Fantastic Four Building",
				StreetAddressLine02 = "222 Second St",
				City = "Farmington",
				State = "UT",
				ZipCode = "84025"
			});
			people.Add(new PersonInfo()
			{
				FirstName = "Bilbo",
				LastName = "Baggins",
				Id = 3,
				StreetAddressLine01 = "333 Third St",
				City = "Layton",
				State = "UT",
				ZipCode = "84041"
			});
			people.Add(new PersonInfo()
			{
				FirstName = "Jared",
				LastName = "Mygrant",
				Id = 4,
				StreetAddressLine01 = "444 Fourth St",
				City = "Farmington",
				State = "UT",
				ZipCode = "84025"
			});
			people.Add(new PersonInfo()
			{
				FirstName = "Johnny",
				LastName = "Storm",
				Id = 5,
				StreetAddressLine01 = "555 Fifth St",
				City = "Kaysville",
				State = "UT",
				ZipCode = "84037"
			});
			people.Add(new PersonInfo()
			{
				FirstName = "Reed",
				LastName = "Richards",
				Id = 6,
				StreetAddressLine01 = "666 Sixth St",
				City = "Layton",
				State = "UT",
				ZipCode = "84041"
			});
		}

		/// <summary>
		/// Gets a list of the first names of all users.
		/// </summary>
		/// <returns>A List of first names</returns>
		//[Route("api/people/GetFirstNames")]
		//[HttpGet]
		//public List<string> GetFirstNames()
		//{
		//	List<string> output = new List<string>();

		//	foreach (var p in people)
		//	{
		//		output.Add(p.FirstName);
		//	}
		//	return output;
		//}

		/// <summary>
		/// Gets a list of person info who match the input search string.
		/// </summary>
		/// <param name="searchStr">A string to match records against.</param>
		/// <returns>A List of Persons objects where a match agianst the input string are found.</returns>
		[Route("api/people/GetMatches/{searchStr}")]
		[HttpGet]
		//STring does not seem to work may need to do something else.
		public List<PersonInfo> GetMatches(string searchStr)
		{
			if(!ValidateSearchInput(searchStr))
			{
				return null;
			}
			List<PersonInfo> results = new List<PersonInfo>();

			results = people.Where(x => x.FirstName.ToLower().Contains(searchStr) || x.LastName.ToLower().Contains(searchStr)).ToList();
			results.AddRange(people.Where(x => x.Id.ToString().Contains(searchStr)).ToList());
			results.AddRange(people.Where(x => x.StreetAddressLine01.Contains(searchStr) || x.StreetAddressLine02.Contains(searchStr)).ToList());
			results.AddRange(people.Where(x => x.City.Contains(searchStr)).ToList());
			results.AddRange(people.Where(x => x.State.Contains(searchStr)).ToList());
			results.AddRange(people.Where(x => x.ZipCode.Contains(searchStr)).ToList());

			return results;
		}

		private bool ValidateSearchInput(string searchStr)
		{
			if(searchStr.Where(x=> !(Char.IsLetterOrDigit(x))).ToList().Count > 0)
			{
				return false;
			}
			return true;
		}

		//// GET: api/People
		//public List<PersonInfo> Get()
		//{
		//	return people;
		//}

		//// GET: api/People/5
		//public PersonInfo Get(int id)
		//{
		//	return people.Where(x => x.Id == id).FirstOrDefault();
		//}

		//// POST: api/People
		//public void Post(PersonInfo val)
		//{
		//	people.Add(val);
		//}

		//// DELETE: api/People/5
		//public void Delete(int id)
		//{
		//	people.Remove(people.Where(x => x.Id == id).FirstOrDefault());
		//}
	}
}
