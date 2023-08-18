using MySpotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpotify.Data.Interfaces
{
    public interface IRhythmRepository
    {
        Rhythm Add(string RhythmName);
        void Remove(int RhythmId);
        Rhythm Update(Rhythm rhythm);
        Rhythm GetById(int Id);
        List<Rhythm> GetAll();
        List<Rhythm> GetByName(string Name);

    }
}
