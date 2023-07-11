using Market_System.Entites.Entity;
using Market_System.Entites.Enums;
using Market_System.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using ConsoleTables;

namespace Market_System.Services
{
    public class MarketService : IMarketable
    {
        public List<Product> Products;

        public List<Sale> Sales;

        public List<SaleItem> SalesItems;
        public MarketService()
        {
            Products = new();
            Sales = new();
            SalesItems = new();
        }

        #region Product

        public List<Product> ShowAllProducts()
        {
            return Products;
        }
        public int AddProduct(string Name, int Price, int Number, string Category)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new FormatException("product's name is empty!");
            }
            if (Price < 0)
            {
                throw new FormatException("Price is less than zero");
            }
            if (Number <= 0)
            {
                throw new FormatException("Number is equal or lower than 0");
            }
            if (string.IsNullOrWhiteSpace(Category))
            {
                throw new FormatException("Category is empty!");
            }

            bool isSuccessful = Enum.TryParse(typeof(Category), Category, true, out object parsedCategory);

            if (!isSuccessful)
            {
                throw new FormatException("Category not found");
            }

            var newProduct = new Product
            {
                ProductName = Name,
                Price = Price,
                Number = Number,
                category = (Category)parsedCategory,
            };

            Products.Add(newProduct);

            return newProduct.Id;
        }
        public void UpdateProduct(string name, int number, int price, int productId)
        {
            var res = Products.FirstOrDefault(x => x.Id == productId);

            if (res == null)
            {
                Console.WriteLine($"Product with ID: {productId} not found");
            }

            res.ProductName = name;

            res.Number = number;

            res.Price = price;
        }
        public void RemoveProduct(int productId)
        {
            var existingProduct = Products.FirstOrDefault(x => x.Id == productId);

            if (existingProduct is null)
            {
                throw new Exception($"Product with ID: {productId} not found");
            }
            Products = Products.Where(x => x.Id != productId).ToList();
        }
        public void ShowProductByCategory(string category)
        {
            foreach (var item in Enum.GetValues(typeof(Category)))
            {
                var search = Products.Find(item => item.category.ToString() == category);

                if (search == null)
                {
                    throw new Exception("We couldn't find products");
                }
            }
        }
        public void ShowProductByPriceRange(decimal firstprice, decimal endprice)
        {
            var result = Products.Where(x => x.Price >= firstprice && x.Price <= endprice).ToList();

            if (result.Count > 0)
            {
                Console.WriteLine("-------------------------------------");

                foreach (var item in result)
                {
                    Console.WriteLine($"Id: {item.Id} Name: {item.ProductName} Price: {item.Price}");
                }

                Console.WriteLine("-------------------------------------");
            }
            else
            {
                throw new Exception("Product is not found");
            }
        }
        public void SearchProductsByName(string productname)
        {
            var search = Products.Find(x => x.ProductName == productname);

            if (search == null)
            {
                throw new Exception("Product is not found");
            }
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine($"Product's id: {search.Id} | product's name: {search.ProductName}" +
                $" | product's category {search.category} | product's number {search.Number}");

            Console.WriteLine("---------------------------------------------------------------------------------------");
        }

        #endregion

        #region Sale

        public List<Sale> ShowAllSales()
        {
            return Sales;
        }
        public int AddSale(int id)
        {
            if (id < 0)
            {
                throw new Exception("There is no product yet");
            }

            var search = Products.Where(x => x.Id == id);

            foreach (var item in search)
            {
                Console.WriteLine($"Product's name: {item.ProductName} | product's price {item.Price} ");
            }
            var newSale = new SaleItem
            {
                Id = id,
            };
            return newSale.Id;
        }

        #endregion
    }
}
