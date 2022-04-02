using InMemoryCacheExample.Models;
using System.Threading.Tasks;

namespace InMemoryCacheExample.Services
{
    public interface IPrayerTimeCache
    {
        Task<PrayerTimeVM> GetCachedPrayerTime();
    }
}