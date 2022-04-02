using InMemoryCacheExample.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryCacheExample.Services
{

    public class PrayerTimeCache : IPrayerTimeCache
    {
        private const string KEY = "time_cache";
        private readonly IMemoryCache memoryCache;
        private readonly PrayerTimeService prayerTimeService;

        public PrayerTimeCache(IMemoryCache memoryCache, PrayerTimeService prayerTimeService)
        {
            this.memoryCache = memoryCache;
            this.prayerTimeService = prayerTimeService;
        }

        private async Task AddToCacheAsync(PrayerTimeVM prayerTime)
        {
            var option = new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(3),
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(3),

            };


            memoryCache.Set<PrayerTimeVM>(KEY, prayerTime, option);
        }

        public async Task<PrayerTimeVM> GetCachedPrayerTime()
        {
                PrayerTimeVM prayerTime = new PrayerTimeVM();
            if (!memoryCache.TryGetValue(KEY, out prayerTime))
            {

                prayerTime = await prayerTimeService.GetPrayerTimes();
                _ = AddToCacheAsync(prayerTime);
            }

            return prayerTime;

        }
    }
}
