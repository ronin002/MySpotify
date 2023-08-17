using System.Collections.Generic;
using MySpotify.Models;
using System.Linq;

namespace MySpotify.Data.Interfaces
{
    public interface ILogsRepository
    {
        Log Add(Log item);
        void AddMultiple(List<Log> logs);
        Log Update(Log item);
        void Remove(string key);
        Log Get(string id);
        IQueryable<Log> GetAll();
    }
}
