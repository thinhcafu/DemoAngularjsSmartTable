using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        int rowForPage = 5;
        // GET api/products
       // url?page = currentPage
        //[Authorize(Roles = "")]
        public TotalProducts Get()
        {
            var urlString = Request.GetQueryNameValuePairs().ToDictionary(p => p.Key, p => p.Value);//lay url 
            int page = 1;
            try
            {
                page = int.Parse(urlString["page"].ToString()); // lay so trang
            }
            catch
            {

            }
            page--;
            if(Repositories.Products == null)
            {
                Repositories.InitDataForProducts();
            }
            TotalProducts totalProduct = new TotalProducts();
            totalProduct.NumberProducts = Repositories.Products.Count;
            totalProduct.Products = Repositories.Products.ToList(); // skip là bỏ ra bao nhiêu dòng, 
            return totalProduct;
        }

        // GET api/products/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/products
        public void Post([FromBody]Product product)
        {
            Repositories.CurrentProductID++;
            Repositories.Products.Add(new Product()
            {
                Id = Repositories.CurrentProductID,
                Name = product.Name
            });
        }

        // PUT api/products/5
        public void Put(int id, [FromBody]Product product)
        {
            for(int i = 0; i< Repositories.Products.Count; i++)
            {
                if(Repositories.Products[i].Id == product.Id)
                {
                    Repositories.Products[i].Name = product.Name;
                    return;
                }
            }
        }

        ////number product
        //public int NumberProduct()
        //{
        //    if(Repositories.Products == null) //neu rong thi thuc hien khoi tao
        //    {
        //        Repositories.InitDataForProducts();
        //    }
        //    return Repositories.Products.Count;
        //}

        // DELETE api/products/5
        public void Delete(int id)
        {
        }
    }
}
