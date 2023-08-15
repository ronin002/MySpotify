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
        Singer Add(Singer singer);
        Singer Remove(Singer singer);
        Singer Update(int Id, Singer singer);
        Singer GetById(int Id);
        List<Singer> GetAll();
        List<Singer> GetByName(string Name);

    }
}
