﻿using MySpotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySpotify.Data.Interfaces;
using MySpotify.Services.Interfaces;

namespace MySpotify.Services.Impl
{
    public class SingerService : ISingerService
    {
        public Singer Add(Singer singer)
        {
            throw new NotImplementedException();
        }

        public List<Singer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Singer GetById(int Id)
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

        public Singer Update(int Id, Singer singer)
        {
            throw new NotImplementedException();
        }
    }
}