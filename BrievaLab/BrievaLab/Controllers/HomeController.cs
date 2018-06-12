using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Azure.KeyVault;
using System.Threading.Tasks;

namespace BrievaLab.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            AzureServiceTokenProvider astp = new AzureServiceTokenProvider();
            string accessToken = await astp.GetAccessTokenAsync("https://management.azure.com/").ConfigureAwait(false);

            //// or

            var kvc = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(astp.KeyVaultTokenCallback));
            

            System.Diagnostics.Trace.TraceInformation("Information logged!");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}