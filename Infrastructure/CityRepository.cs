using Core.Domain;
using Core.Domain.Services;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CityRepository : ICityRepository
    {
        
        public string SelectedCity { get; set; }
        public CityRepository()
        {
           
        }

        public List<City> GetAll()
        {
            return new List<City>
            {
                City.Breda,
                City.Den_Bosch,
                City.Tilburg
            };
        }
    }
}
