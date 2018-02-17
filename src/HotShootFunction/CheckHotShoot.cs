using System.Linq;
using HtmlAgilityPack;

namespace HotShootFunction
{
    public class CheckHotShoot
    {
        public static bool isProductHotShoot(string productName)
        {
            var doc = getHtmlDocument();

            HtmlNode h1NameNode = doc.DocumentNode.Descendants("h1").Where(x => x.Attributes["itemprop"].Value == "name").FirstOrDefault();

            if (h1NameNode != null)
            {
                var htmlProductName = h1NameNode.InnerText;

                if (htmlProductName.Contains(productName))
                {
                    return true;
                }
            }
            return false;
        }

        private static HtmlDocument getHtmlDocument()
        {
            var url = "https://www.al.to/goracy_strzal";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            return doc;
        }
    }
}
