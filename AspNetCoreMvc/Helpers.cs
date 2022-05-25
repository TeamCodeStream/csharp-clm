using NewRelic.Api.Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

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
		private string CustomMethodTwo()
		{
			return DateTime.Now.ToShortTimeString();
		}
	}
}
