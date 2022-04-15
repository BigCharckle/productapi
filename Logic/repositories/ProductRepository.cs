using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Logic.interfaces;
using Models.products;
using Datalayer;
using Newtonsoft.Json;
namespace Logic.repositories
{
    /// <summary>
    /// normall it should implement IGenericRepository interface to do CRUD. However for this specific scenario what we need is only a list of products.
    /// </summary>
    public class ProductRepository: IGenericRepositoryrReadable<Models.products.Product>, IRepositoryFromExternal<Models.products.Product>
    {
        public IEnumerable<Product> GetAll()
        {
            return new List<Product>();
            
        }

        public Product GetById(int id)
        {
            return new Product();
        }
        public List<Product> GetAll(string externalURL)
        {
            var lst =new List<Product>();

            return lst;
        }
        public async Task<List<Product>> GetFromExternalAsyn(string ExternalUrl)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ExternalUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                using (HttpResponseMessage response = await client.GetAsync(ExternalUrl))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var contents = await response.Content.ReadAsStringAsync();
                        //dynamic DynamicData = JsonConvert.DeserializeObject(contents);
                        try
                        {
                            var obj = JsonConvert.DeserializeObject<responsecontent>(contents);
                            if(obj?.data !=null )
                            {
                                var lst = new List<dataitem>(obj.data);

                               return lst.Select(x => new Product { id = x.id, name = x.name, image = x.image, description=x.description, price= x.price }).ToList();
                            }
                        }
                        catch(Exception ex)
                        {
                            throw ex;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Internal server Error");
                    }
                }
                return new List<Product>();

            }

        }
    }

}
