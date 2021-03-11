using FileUpload.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace FileUpload.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IWebHostEnvironment _environment;

		public HomeController(ILogger<HomeController> logger,
			IWebHostEnvironment environment)
		{
			_logger = logger;
			_environment = environment;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult PostFile(IFormFile file)
		{
			var type = file.ContentType;
			var path = Path.GetTempPath();

			var uploadDirectory = "img/logo/";
			var uploadPath = Path.Combine(_environment.WebRootPath, uploadDirectory);

			if (!Directory.Exists(uploadPath))
				Directory.CreateDirectory(uploadPath);

			var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
			var filePath = Path.Combine(uploadPath, fileName);

			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				file.CopyTo(stream);
			}

			return RedirectToAction("Index");
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
