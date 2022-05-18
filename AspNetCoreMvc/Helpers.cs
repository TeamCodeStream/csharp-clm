using NewRelic.Api.Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvc
{
	public class Helpers
	{
		[Trace]
		public static string CustomStaticMethodOne(string data)
		{
			var dataFromStaticMethodTwo = CustomStaticMethodTwo();
			return data + " @ " + dataFromStaticMethodTwo;
		}

		[Trace]
		private static string CustomStaticMethodTwo()
		{
			return DateTime.Now.ToLongTimeString();
		}

		[Trace]
		public string CustomMethodOne(string data)
		{
			var dataFromMethodTwo = CustomMethodTwo();
			return data + " @ " + dataFromMethodTwo;
		}

		[Trace]
		private string CustomMethodTwo()
		{
			return DateTime.Now.ToShortTimeString();
		}
	}
}
