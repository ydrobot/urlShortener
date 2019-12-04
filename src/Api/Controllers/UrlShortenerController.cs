using System.Threading.Tasks;
using Domain.Url;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<ActionResult<string>> CreatedAsync(string url)
        {
            return Ok(await _urlService.CreateShortUrlAsync(url));
        }

        [HttpGet("{shortUrl}")]
        public async Task<ActionResult<string>> GetUrlAsync(string shortUrl)
        {
            return Redirect(await _urlService.GetUrlByShortAsync(shortUrl));
        }
    }
}