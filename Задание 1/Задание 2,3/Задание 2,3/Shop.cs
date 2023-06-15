using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_2_3
{
    internal class Shop
    {
        private Dictionary<Product, int> products;
        public int Profit { get; set; }
        public Shop()
        {
            products = new Dictionary<Product, int>();
        }
        public void AddProduct(Product product, int count)
        {
            products.Add(product, count);
        }

        public void CreateProduct(string name, decimal price, int count)
        {
            products.Add(new Product(name, price), count);
        }

        public void WriteAllProducts(List<string> ts)
        {
            foreach (var product in products)
            {
                if (product.Value != 0)
                    ts.Add((product.Key.GetInfo() + ";\r Количество: " + product.Value));
            }
        }
        public void WriteOnlyProductsName(List<string> ts)
        {
            foreach (var product in products)
            {
                if (product.Value != 0)
                    ts.Add(product.Key.Name);
            }
        }
        public string Sell(Product product)
        {
            if (products.ContainsKey(product))
            {
                if (products[product] == 0)
                {
                    return "Нет в наличии!";

                }
                else
                {
                    products[product]--;
                    Profit += (int)product.Price;
                    return "Товар успешно продан";
                }
            }
            else
            {
                return "Товар не найден!";
            }
        }
        public string Sell(string ProductName)
        {
            Product ToSell = FindByName(ProductName);
            if (ToSell != null)
            {
                return this.Sell(ToSell);
            }
            else
            {
                return "Товар не найден!";
            }
        }
        public Product FindByName(string name)
        {
            foreach (var product in products.Keys)
            {
                if (product.Name == name)
                {
                    return product;
                }
            }
            return null;
        }
    }
}
