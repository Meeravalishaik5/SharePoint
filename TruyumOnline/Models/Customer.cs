using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruyumOnline.Models
{
	public class Customer
	{
		public int UserId { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string City { get; set; }
	}
}
