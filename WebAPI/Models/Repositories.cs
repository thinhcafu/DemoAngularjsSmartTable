using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public static class Repositories
    {
        public static List<Product> Products;
        public static int CurrentProductID;
        

        public static void InitDataForProducts()
        {
            string[] fArrName = new string[] {"Mobile","Laptop","Tablet","Car","Watch","Moto","Plan","Train","Cake","Book" };
            Repositories.Products = new List<Product>();
            for(int i=0; i< fArrName.Length; i++)
            {
                Repositories.Products.Add(new Product()
                {
                   Id = i+1,
                   Name = fArrName[i]
                   
                });
            }
            Repositories.CurrentProductID = fArrName.Length;
        }
    }

}