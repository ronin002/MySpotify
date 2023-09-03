using MySpotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySpotify.Data.Interfaces;
using MySpotify.Services.Interfaces;
using MySpotify.Data.Repositories;

namespace MySpotify.Services.Impl
{
    /*
    public class RhythmService : IRhythmService
    {
        private IRhythmRepository _rythmRepository;

        public RhythmService(IRhythmRepository rythmRepository)
        {
            _rythmRepository = rythmRepository;
        }
        
        public Rhythm Add(string rhythm)
        {
            return _rythmRepository.Add(rhythm);
        }
        public void Remove(string Id)
        {
            int id = 0;
            if (int.TryParse(Id,out id))
            {
                _rythmRepository.Remove(id);
            }
        }

        public Rhythm Update( Rhythm rhythm)
        {
            rhythm = _rythmRepository.Update(rhythm);
            return rhythm;
        }
    
        public List<Rhythm> GetAll()
        {
            var rhythms = _rythmRepository.GetAll();
            return rhythms;
        }

        public Rhythm GetById(string Id)
        {
            int id = 0;
            if (int.TryParse(Id, out id))
            {
                var rhythm = _rythmRepository.GetById(id);
                return rhythm;
            }
            return null;
        }

        public List<Rhythm> GetByName(string Name)
        {
            var rhythms = _rythmRepository.GetByName(Name);
            return rhythms;
        }

       
    }
    */
}
