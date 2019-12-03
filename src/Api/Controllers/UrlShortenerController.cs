using System;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Api.Controllers
{
    [Route("")]
    [ApiController]
    public class UrlShortenerController : Controller
    {
        private readonly IUrlService _urlService;

        public UrlShortenerController(IUrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpPost("short-url")]
        public async Task<ActionResult<string>> CreateShortUrlAsync(string url)
        {
            return Ok(await _urlService.CreateShortUrlAsync(url, Guid.Empty));
        }

        [HttpGet("{shortUrl}")]
        public async Task<ActionResult<string>> GetUrlAsync(Guid shortUrl)
        {
            return Ok(await _urlService.GetUrlByShortAsync(shortUrl));
        }

        [HttpGet("statistic/user")]
        public async Task<ActionResult<UrlStatisticInfo[]>> GetUserUrlStatistics()
        {
            return Ok(await _urlService.GetUserUrlStatisticAsync(Guid.Empty));
        }

        [HttpGet("statistic")]
        public async Task<ActionResult<UrlStatisticInfo[]>> GetUrlStatistics()
        {
            return Ok(await _urlService.GetUrlStatisticAsync());
        }
    }
}