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
        Rhythm Add(string rhythm);
        void Remove(string rhythm);
        Rhythm Update(Rhythm rhythm);
        Rhythm GetById(string Id);
        List<Rhythm> GetAll();
        List<Rhythm> GetByName(string Name);

    }
}
