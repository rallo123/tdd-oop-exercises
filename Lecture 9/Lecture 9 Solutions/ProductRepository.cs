using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lecture_9_Solutions
{
    public class ProductRepository : IEnumerable<Product>
    {
        List<Product> _products = new List<Product>();

        public void Add(Product product)
        {
            _products.Add((Product)product.Clone());
        }

        public void Update(Product product)
        {
            _products.Remove(product);
            _products.Add((Product)product.Clone());
        }

        public void Delete(Product product)
        {
            _products.Remove(product);
        }

        public Product GetProductByID(int id)
        {
            return _products.First(p => p.ID == id);
        }

        public Product GetLeastExpensiveProduct()
        {
            return _products.OrderBy(p => p.Price).First();
        }

        public Product GetMostExpensiveProduct()
        {
            return _products.OrderByDescending(p => p.Price).First();
        }

        public decimal GetAverageProductPrice()
        {
            return _products.Select(p => p.Price).Average();
        } 

        public IEnumerable<Product> GetProductsInCategory(string category)
        {
            return _products.Where(p => p.Category == category);
        }

        public IEnumerable<string> GetProductCategories()
        {
            return _products.Select(p => p.Category).Distinct();
        }

        public IEnumerator<Product> GetEnumerator()
        {
            return _products.Select(s => (Product)s.Clone()).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
