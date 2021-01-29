using System;
using System.Collections.Generic;
using System.Linq;
using BlazorAccessServerDirectories.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace BlazorAccessServerDirectories.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectoryController : ControllerBase
    {
        private readonly IFileProvider fileProvider;

        public DirectoryController(IFileProvider fileProvider)
        {
            this.fileProvider = fileProvider;
        }

        [HttpGet]
        public IEnumerable<DirectoryContent> GetDirectoryList()
        {
            var contents = this.fileProvider.GetDirectoryContents("");

            return contents.Select(c => new DirectoryContent { Path = c.PhysicalPath }).ToList();
        }
    }
}
