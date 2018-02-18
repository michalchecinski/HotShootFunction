using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotShootFunction
{
    public class Settings
    {
        public static IEnumerable<string> GetProductsList()
        {
            string productsString = Environment.GetEnvironmentVariable("ProductName");

            if (productsString == null)
            {
                throw new NullReferenceException("Products list is null");
            }

            string[] productsArray = productsString.Split(';');

            List<string> productsList = productsArray.ToList();
            return productsList;
        }
    }
}
