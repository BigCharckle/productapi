using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logic.interfaces;
using Models.culture;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : Controller
    {
        private IGenericRepositoryrReadable <Country> _countryRepository;

        public CountryController(IGenericRepositoryrReadable<Country> countryRepository)
        {
            this._countryRepository = countryRepository;

        }

        [Route("{id:int}")]
        [HttpGet]
        public Country Details(int id)
        {
            return GetAll().Where(c=>c.id==id).FirstOrDefault();
        }

        [HttpGet]
        public List<Country> GetAll()
        {

            return _countryRepository.GetAll().ToList();
        }

    }
}
