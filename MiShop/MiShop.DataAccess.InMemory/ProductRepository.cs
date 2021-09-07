﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MiShop.Core;
using MiShop.Core.Models;

namespace MiShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products = new List<Product>();

        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if (products == null)
            {
                products = new List<Product>();
            }
        }
        public void Commit()
        {
            cache["products"] = products;
        }
        public void Insert(Product p)
        {
            products.Add(p);
        }
        public void Update(Product product)
        {
            Product productToUpdate = products.Find(p => p.Id == product.Id);
            if(productToUpdate!=null)
            {
                productToUpdate = product;
            }
            else
            {
                throw new Exception("Prodct not found");
            }
        }
        public Product Find(string Id)
        {
            Product product = products.Find(p => p.Id == Id);
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Prodct not found");
            }
        }
        public IQueryable<Product> collection()
        {
            return products.AsQueryable();
        }
        public void Delete(string Id)
        {
            Product productToDelete = products.Find(p => p.Id == Id);
            if (productToDelete != null)
            {
                products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Prodct not found");
            }
        }
    }
}
