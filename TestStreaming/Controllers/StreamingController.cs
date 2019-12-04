using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestStreaming.Interface;

namespace TestStreaming.Controllers
{
    public class StreamingController : Controller
    {
        public IVideoStreamService _streamingService; 
        public StreamingController(IVideoStreamService streamingService)
        {
            _streamingService = streamingService;
        }
        [HttpGet("{name}")]
        public async Task<FileStreamResult> Get(string name)
        {
            var stream = await _streamingService.GetVideoByName(name);
            return new FileStreamResult(stream, "video/mp4");
        }

    }
}