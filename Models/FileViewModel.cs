using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FileUpload.Models
{
	public class FileViewModel
	{
		public string Name { get; set; }
		public IFormFile File { get; set; }
	}
}
