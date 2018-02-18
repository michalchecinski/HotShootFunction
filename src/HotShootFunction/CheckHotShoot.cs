using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace HotShootFunction
{
    public class CheckHotShoot
    {
        public static string ProductInHotShoot(IEnumerable<string> productsName)
        {
            var doc = GetHtmlDocument();

            HtmlNode h1NameNode = doc.DocumentNode.Descendants("h1").Where(x => x.Attributes["itemprop"].Value == "name").FirstOrDefault();

            if (h1NameNode != null)
            {
                var htmlProductName = h1NameNode.InnerText;

                foreach (var productName in productsName)
                {
                    if (htmlProductName.Contains(productName))
                    {
                        return productName;
                    }
                }

                
            }
            return null;
        }

        private static HtmlDocument GetHtmlDocument()
        {
            var url = "https://www.al.to/goracy_strzal";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            return doc;
        }
    }
}
