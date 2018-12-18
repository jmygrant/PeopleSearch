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
			people.Add(new PersonInfo() { FirstName = "Tim", LastName = "Corey", Id = 1 });
			people.Add(new PersonInfo() { FirstName = "Sue", LastName = "Storm", Id = 2 });
			people.Add(new PersonInfo() { FirstName = "Bilbo", LastName = "Baggins", Id = 3 });
		}

		/// <summary>
		/// Gets a list of the first names of all users.
		/// </summary>
		/// <returns>A List of first names</returns>
		[Route("api/people/GetFirstNames")]
		[HttpGet]
		public List<string> GetFirstNames()
		{
			List<string> output = new List<string>();

			foreach (var p in people)
			{
				output.Add(p.FirstName);
			}
			return output;
		}

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
			List<PersonInfo> results = new List<PersonInfo>();

			results = people.Where(x => x.FirstName.Contains(searchStr) || x.LastName.Contains(searchStr)).ToList();

			return results;
		}

		// GET: api/People
		public List<PersonInfo> Get()
		{
			return people;
		}

		// GET: api/People/5
		public PersonInfo Get(int id)
		{
			return people.Where(x => x.Id == id).FirstOrDefault();
		}

		// POST: api/People
		public void Post(PersonInfo val)
		{
			people.Add(val);
		}

		// DELETE: api/People/5
		public void Delete(int id)
		{
			people.Remove(people.Where(x => x.Id == id).FirstOrDefault());
		}
	}
}
