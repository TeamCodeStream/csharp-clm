using NewRelic.Api.Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class Account
{
	public string Email { get; set; }
	public bool Active { get; set; }
	public DateTime CreatedDate { get; set; }
	public IList<string> Roles { get; set; }
}

namespace AspNetCoreMvc
{
	public class Helpers
	{
		[Trace]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static string CustomStaticMethodOne(string data)
		{
			var dataFromStaticMethodTwo = CustomStaticMethodTwo();
			return data + " @ " + dataFromStaticMethodTwo;
		}

		[Trace]
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static string CustomStaticMethodTwo()
		{
			return DateTime.Now.ToLongTimeString();
		}

		[Trace]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public string CustomMethodOne(string data)
		{
			var dataFromMethodTwo = CustomMethodTwo();
			return data + " @ " + dataFromMethodTwo;
		}

		[Trace]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public string JsonStuff()
		{
			Account account = new Account
			{
				Email = "james@example.com",
				Active = true,
				CreatedDate = new DateTime(2013, 1, 20, 0, 0, 0, DateTimeKind.Utc),
				Roles = new List<string>
				{
					"User",
					"Admin"
				}
			};
			string json = JsonConvert.SerializeObject(account, Formatting.Indented);
			return json;
		}
		
		[Trace]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Account JsonStuffTwo()
		{
			string accountStr = "{\"Email\": \"bob@bob.net\", \"CreatedDate\": \"Invalid\"  }";
			Account account = JsonConvert.DeserializeObject<Account>(accountStr);
			return account;
		}

		[Trace]
		[MethodImpl(MethodImplOptions.NoInlining)]
		private string CustomMethodTwo()
		{
			return DateTime.Now.ToShortTimeString();
		}
	}
}
