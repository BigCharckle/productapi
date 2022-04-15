using System.Collections.Generic;
using Logic.interfaces;
using Models.culture;
using Models.enums;
using System.Linq;

namespace Logic.repositories
{
    public class CountryRepository:IGenericRepositoryrReadable<Country>
    {
        public IEnumerable<Country> GetAll()
        {
            Country[] arr = { 
                new Country { id = 1, name = "Australia", currency = Currencies.AUD, rate = (decimal)1.000 },
                new Country { id = 2, name = "United States", currency = Currencies.USD, rate = (decimal)0.742 },
                new Country { id = 2, name = "Japan", currency = Currencies.JPY, rate = (decimal)93.220 },
            };
            return arr;
        }

        public Country GetById(int id)
        {
            var countries = this.GetAll();
            
            return countries.SingleOrDefault(c=>c.id==id);
        }

        public Country GetByName(string name)
        {
            var countries = this.GetAll();

            return countries.SingleOrDefault(c => c.name == name);
        }
    }
}
