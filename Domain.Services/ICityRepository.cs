﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Services
{
    public interface ICityRepository
    {
        public List<City> GetAll();
    }
}
