using MySpotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpotify.Services.Interfaces
{
    public interface ISingerService
    {
        Singer Add(string singer);
        void Remove(string SingerId);
        Singer Update(Singer singer);
        Singer GetById(string Id);
        List<Singer> GetAll();
        List<Singer> GetByName(string Name);

    }
}
