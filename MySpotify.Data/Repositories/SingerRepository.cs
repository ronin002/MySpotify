using MySpotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySpotify.Data.Interfaces;

namespace MySpotify.Data.Repositories
{
    public class SingerRepository : ISingerRepository
    {
        public Singer Add(Singer singer)
        {
            throw new NotImplementedException();
        }

        public List<Singer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Singer GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<Singer> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public Singer Remove(Singer singer)
        {
            throw new NotImplementedException();
        }

        public Singer Update(Guid Id, Singer singer)
        {
            throw new NotImplementedException();
        }
    }
}
