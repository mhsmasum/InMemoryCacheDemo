using InMemoryCacheExample.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace InMemoryCacheExample.Services
{
    public class PrayerTimeService
    {
        private readonly IHttpClientFactory _httpClient;
        public PrayerTimeService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PrayerTimeVM> GetPrayerTimes()
        {
            PrayerTimeVM prayereTime = new PrayerTimeVM();
            try
            {
                var client = _httpClient.CreateClient("getPrayerTime");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var url = string.Format("http://api.aladhan.com/v1/timings/1398332113?latitude=51.508515&longitude=-0.1254872&method=2");
                var httpResponse = await client.GetAsync(url);
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();
                    prayereTime = JsonConvert.DeserializeObject<PrayerTimeVM>(result);
                }

                return prayereTime;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
