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
    public class SingerService : ISingerService
    {
        private ISingerRepository _singerRepository;

        public SingerService(ISingerRepository singerRepository)
        {
            _singerRepository = singerRepository;
        }

        public Singer Add(string singer)
        {
            return _singerRepository.Add(singer);
        }
        public void Remove(string singerId)
        {
            Guid id = Guid.Empty;
            if (Guid.TryParse(singerId, out id))
            {
                _singerRepository.Remove(id);
            }
        }

        public Singer Update( Singer singer)
        {
            singer = _singerRepository.Update(singer);
            return singer;
        }

        public List<Singer> GetAll()
        {
            var singers = _singerRepository.GetAll();
            return singers;
        }

        public Singer GetById(string Id)
        {
            Guid id = Guid.Empty;
            if (Guid.TryParse(Id, out id))
            {
                var singer = _singerRepository.GetById(id);
                return singer;
            }
            return null;
        }

        public List<Singer> GetByName(string Name)
        {
            var rhythms = _singerRepository.GetByName(Name);
            return rhythms;
        }

       
    }
    */
}
