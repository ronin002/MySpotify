using MySpotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpotify.Services.Interfaces
{
    public interface IRhythmService
    {
        Rhythm Add(Rhythm rhythm);
        Rhythm Remove(Rhythm rhythm);
        Rhythm Update(int Id, Rhythm rhythm);
        Rhythm GetById(int Id);
        List<Rhythm> GetAll();
        List<Rhythm> GetByName(string Name);

    }
}
