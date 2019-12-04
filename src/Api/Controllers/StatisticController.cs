using System.Threading.Tasks;
using Domain.Statistic;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Api.Controllers
{
    [Route("statistic")]
    [ApiController]
    public class StatisticController : Controller
    {
        private readonly IStatisticService _urlService;

        public StatisticController(IStatisticService urlService)
        {
            _urlService = urlService;
        }

        [HttpGet("user")]
        public async Task<ActionResult<UrlStatisticInfo[]>> GetUserUrlStatistics()
        {
            return Ok(await _urlService.GetUserUrlStatisticAsync());
        }

        [HttpGet]
        public async Task<ActionResult<UrlStatisticInfo[]>> GetUrlStatistics()
        {
            return Ok(await _urlService.GetUrlStatisticAsync());
        }
    }
}