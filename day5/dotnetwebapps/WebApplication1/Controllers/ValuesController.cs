using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }

    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Product> Get()
        {
            return new Product[] {
                new Product{Name = "Coke", Price= 100},
                new Product{Name="Limca", Price=200},
                new Product{Name="Miranda", Price=300}
            };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
