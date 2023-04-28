using System;
using AspNetCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace AspNetCoreMvc.Controllers
{
	public class AgentsController : Controller
	{
		private readonly ILogger<AgentsController> _logger;

		public AgentsController(ILogger<AgentsController> logger)
		{
			_logger = logger;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public IActionResult Show()
		{
			var helpers = new Helpers();
			Thread.Sleep(200);
			ViewData["InstanceMethod"] = helpers.CustomMethodOne("Wake me. When you need me.");
			ViewData["StaticMethod"] = Helpers.CustomStaticMethodOne("It's dangerous to go alone, take this!");
			ViewData["JsonStuff"] = helpers.JsonStuff();
			return View();
		}
		
		[MethodImpl(MethodImplOptions.NoInlining)]
		public IActionResult DoError()
		{
			Thread.Sleep(200);
			throw new Exception("Agitated");
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public IActionResult Create()
		{
			var helpers = new Helpers();
			ViewData["InstanceMethod"] = helpers.CustomMethodOne("You are not prepared!");
			ViewData["StaticMethod"] = Helpers.CustomStaticMethodOne("You Must Construct Additional Pylons!");
			return View();
		}

        [MethodImpl(MethodImplOptions.NoInlining)]
        public IActionResult SlowResponse()
        {
            var helpers = new Helpers();

            var randomWait = new Random();
            var waitTime = randomWait.Next(150, 250);
            Thread.Sleep(waitTime);

            ViewData["InstanceMethod"] = helpers.CustomMethodOne("Waiting...");
            ViewData["StaticMethod"] = Helpers.CustomStaticMethodOne($"We waited an extra {waitTime} milliseconds on this one!");

            return View();
        }
        
		[MethodImpl(MethodImplOptions.NoInlining)]
		public IActionResult RealisticError()
		{
			var helpers = new Helpers();
			ViewData["Account"] = helpers.JsonStuffTwo();
			return View();
		}
		
		[MethodImpl(MethodImplOptions.NoInlining)]
		public IActionResult Destroy() => DestroyImpl();

		private IActionResult DestroyImpl()
		{
			var helpers = new Helpers();
			ViewData["InstanceMethod"] = helpers.CustomMethodOne("It's time to kick ass and chew bubblegum, and I'm all out of gum.");
			ViewData["StaticMethod"] = Helpers.CustomStaticMethodOne("Survival can be a matter of luck or skill. And you can't rely on luck.");
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
