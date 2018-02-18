using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.KeyVault;

namespace HotShootFunction
{
    public static class HotShootAlertFunction
    {
        [FunctionName("hotShootAlertFunction")]
        public static async Task Run([TimerTrigger("0 1 9,21 * * *")]TimerInfo myTimer, TraceWriter log)
        {
            log.Info($"C# Timer trigger function executed at: {DateTime.Now}");

            IEnumerable<string> productsList;
            try
            {
                productsList = Settings.GetProductsList();
            }
            catch (NullReferenceException e)
            {
                log.Error("Products list is null", e);
                return;
            }

            bool sent = await DealChecker.SendEmailIfProductDiscounted(productsList);

            if (sent)
            {
                log.Info("Email sent.");
            }
        }
    }
}
