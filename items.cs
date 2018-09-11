﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
namespace Decorator_And_Cache
{
    class items
    {
    }
}

    class Program
    {
        static void Main(string[] args)
        {
            StockItems PS = new StockItems();
            List<string> Pizzas = (List<string>)PS.GetAvailableStocks();
            Pizzas = (List<string>)PS.GetAvailableStocks();
        }
    }

    public class StockItems
    {
        private const string CacheKey = "availableStocks";

        public IEnumerable GetAvailableStocks()
        {
            ObjectCache cache = MemoryCache.Default;

            if (cache.Contains(CacheKey))
                return (IEnumerable)cache.Get(CacheKey);
            else
            {
                IEnumerable availableStocks = this.GetDefaultStocks();

                // Store data in the cache    
                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
                cache.Add(CacheKey, availableStocks, cacheItemPolicy);

                return availableStocks;
            }
        }
        public IEnumerable GetDefaultStocks()
        {
            return new List<string>() { "Pen", "Pencil", "Eraser" };
        }
    }

