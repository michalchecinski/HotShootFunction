using System.Threading.Tasks;

namespace HotShootFunction
{
    public class DealChecker
    {
        public static async Task<bool> SendEmailIfProductDiscounted(string productName)
        {
            var discounted = CheckHotShoot.isProductHotShoot(productName);

            if (discounted)
            {
                await EmailSender.SendEmailOnOfferFound(productName);
                return true;
            }
            return false;
        }
    }
}
