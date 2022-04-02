using InMemoryCacheExample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryCacheExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrayerTimeController : ControllerBase
    {
        private readonly IPrayerTimeCache _prayerTimeService;
        public PrayerTimeController(IPrayerTimeCache prayerTimeService)
        {
            _prayerTimeService = prayerTimeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok ( await _prayerTimeService.GetCachedPrayerTime());
        }
    }
}
