using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotShootFunction
{
    public class DealChecker
    {
        public static async Task<bool> SendEmailIfProductDiscounted(IEnumerable<string> productsList)
        {
            var discountedProductName = CheckHotShoot.ProductInHotShoot(productsList);

            if (discountedProductName != null)
            {
                await EmailSender.SendEmailOnOfferFound(discountedProductName);
                return true;
            }
            return false;
        }
    }
}
