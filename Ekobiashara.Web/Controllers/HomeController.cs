using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ekobiashara.Web.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using RestSharp;
using Newtonsoft.Json;
using Ekobiashara.Web.Downloaders;
using Ekobiashara.Web.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace Ekobiashara.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;
        public HomeController(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var baseUrl = _configuration["ApiBaseUrl"];
            var localbaseUrl = _configuration["LocalApiUrl"];
            var urlString = baseUrl + "business/CountBusinesses?id=111111";
            Uri url = new Uri(urlString, UriKind.Absolute);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddParameter("Content-Type", "application/json");
            var response = await client.ExecuteAsync(request);
            CountBusinessesDownloadSerializer objectResponse = JsonConvert.DeserializeObject<CountBusinessesDownloadSerializer>(response.Content);
            ViewBag.Count = objectResponse.Count;
            if (ViewBag.Count > 0)
            {
                var businessUrlString = baseUrl + "business/GetBusinesses?id=111111";
                Uri businessesUrl = new Uri(businessUrlString, UriKind.Absolute);
                var businessesClient = new RestClient(businessesUrl);
                var businessRequest = new RestRequest(Method.GET);
                businessRequest.AddHeader("cache-control", "no-cache");
                businessRequest.AddParameter("Content-Type", "application/json");
                var businessresponse = await businessesClient.ExecuteAsync(businessRequest);
                IEnumerable<BusinessDownloadSerializer> businessObject = JsonConvert.DeserializeObject<IEnumerable<BusinessDownloadSerializer>>(businessresponse.Content);
                ViewBag.Businesses = businessObject;
            }
            return View();
        }
        #region Business Information

        public async Task<IActionResult> BusinessInformation()
        {
            ViewBag.Count = 0;
            long id = 4;
            ViewBag.Business = await GetBusiness(id);
            ViewBag.Branches = await GetBranches(id);
            ViewBag.Taxes = await GetTaxes(id);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBranch([FromForm] AddBranchViewModel model)
        {
            model.BusinessId = 4;
            var baseUrl = _configuration["ApiBaseUrl"];
            var url = baseUrl + "business/AddBranch";
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            string json = JsonConvert.SerializeObject((AddBranchViewModel)model);
            request.AddJsonBody(json);
            request.AddHeader("cache-control", "no-cache");
            request.AddParameter("Accept", "application/json");
            request.AddParameter("Content-Type", "application/json");
            var response = await client.ExecuteAsync(request);
            return RedirectToAction("BusinessInformation", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTax([FromForm] AddtaxesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            model.BusinessId = 4;
            var baseUrl = _configuration["ApiBaseUrl"];
            var url = baseUrl + "admin/AddTaxes";
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            string json = JsonConvert.SerializeObject((AddtaxesViewModel)model);
            request.AddJsonBody(json);
            request.AddHeader("cache-control", "no-cache");
            request.AddParameter("Accept", "application/json");
            request.AddParameter("Content-Type", "application/json");
            var response = await client.ExecuteAsync(request);
            return RedirectToAction("BusinessInformation", "Home");
        }
        #endregion
        public async Task<IActionResult> DashBoard(long id)
        {
            if (id == 0)
            {
                ViewBag.Count = 0;
                return PartialView("error500");
            }
            ViewBag.Count = 1;
            ViewBag.Branches = await GetBranches(id);
            return View();
        }
        #region Business Region
        public async Task<IActionResult> AddBusiness()
        {
            ViewBag.Count = 0;
            var baseUrl = _configuration["ApiBaseUrl"];
            ViewBag.Plans = await GetPlans(baseUrl);
            ViewBag.Agents = await GetAgents(baseUrl);
            ViewBag.Currencies = await GetCurrencies(baseUrl);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBusiness([FromForm] AddBusinessViewModel model)
        {
            var baseUrl = _configuration["ApiBaseUrl"];
            var url = baseUrl + "business/AddBusiness";
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            string json = JsonConvert.SerializeObject((AddBusinessViewModel)model);
            request.AddJsonBody(json);
            request.AddHeader("cache-control", "no-cache");
            request.AddParameter("Accept", "application/json");
            request.AddParameter("Content-Type", "application/json");
            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                ViewBag.Plans = await GetPlans(baseUrl);
                ViewBag.Agents = await GetAgents(baseUrl);
                ViewBag.Currencies = await GetCurrencies(baseUrl);
                Alert("Business Added Succesfully", NotificationType.success, 10000);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Plans = await GetPlans(baseUrl);
                ViewBag.Agents = await GetAgents(baseUrl);
                ViewBag.Currencies = await GetCurrencies(baseUrl);
                Alert("Operation Unsuccesfull", NotificationType.error, 10000);
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion

        public IActionResult Accounting()
        {
            ViewBag.Count = 0;
            return View();
        }
        #region Cusomers
        public async Task<IActionResult> Customers()
        {
            ViewBag.Count = 0;
            long id = 4;
            ViewBag.Customers = await GetCustomers(id);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCustomer([FromForm] AddCustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            model.BusinessId = 4;
            var baseUrl = _configuration["ApiBaseUrl"];
            var url = baseUrl + "business/AddCustomer";
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            string json = JsonConvert.SerializeObject((AddCustomerViewModel)model);
            request.AddJsonBody(json);
            request.AddHeader("cache-control", "no-cache");
            request.AddParameter("Accept", "application/json");
            request.AddParameter("Content-Type", "application/json");
            var response = await client.ExecuteAsync(request);
            return RedirectToAction("Customers", "Home");
        }
        #endregion
        public IActionResult Expenses()
        {
            ViewBag.Count = 0;
            return View();
        }
        public IActionResult InternalTransactions()
        {
            ViewBag.Count = 0;
            return View();
        }
        public IActionResult ProductAndServices()
        {
            ViewBag.Count = 0;
            return View();
        }

        public IActionResult Suppliers()
        {
            ViewBag.Count = 0;
            return View();
        }

        public IActionResult FeedBack()
        {
            ViewBag.Count = 0;
            return View();
        }

        public IActionResult Taxes()
        {
            ViewBag.Count = 0;
            return View();
        }

        public IActionResult Reports()
        {
            ViewBag.Count = 0;
            return View();
        }

        public IActionResult Surveliance()
        {
            ViewBag.Count = 0;
            return View();
        }

        public IActionResult Sales()
        {
            ViewBag.Count = 0;
            return View();
        }

        public IActionResult Purchases()
        {
            ViewBag.Count = 0;
            return View();
        }
        public IActionResult Inventories()
        {
            ViewBag.Count = 0;
            return View();
        }

        public IActionResult Checkout()
        {
            ViewBag.Count = 0;
            return View();
        }

        public IActionResult user_profile()
        {
            ViewBag.Count = 0;
            return View();
        }
<<<<<<< HEAD

        public IActionResult QuotationNote()
        {
            return View();
        }

=======
        #region Methods
        private async Task<IEnumerable<PlansDownloadSerializer>> GetPlans(string baseUrl)
        {
            var plansUrlString = baseUrl + "business/GetPlans";
            Uri plansUrl = new Uri(plansUrlString, UriKind.Absolute);
            var plansClient = new RestClient(plansUrl);
            var plansRequest = new RestRequest(Method.GET);
            plansRequest.AddHeader("cache-control", "no-cache");
            plansRequest.AddParameter("Content-Type", "application/json");
            var plansResponse = await plansClient.ExecuteAsync(plansRequest);
            IEnumerable<PlansDownloadSerializer> plansObject = JsonConvert.DeserializeObject<IEnumerable<PlansDownloadSerializer>>(plansResponse.Content);
            return plansObject;
        }
        private async Task<IEnumerable<CurrencyDownloadSerializer>> GetCurrencies(string baseUrl)
        {
            baseUrl = _configuration["ApiBaseUrl"];
            var urlString = baseUrl + "business/GetCurrencies";
            Uri url = new Uri(urlString, UriKind.Absolute);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddParameter("Content-Type", "application/json");
            var response = await client.ExecuteAsync(request);
            IEnumerable<CurrencyDownloadSerializer> objectResponse = JsonConvert.DeserializeObject<IEnumerable<CurrencyDownloadSerializer>>(response.Content);
            return objectResponse;
        }
        private async Task<IEnumerable<AgentDownLoadSerializer>> GetAgents(string baseUrl)
        {
            var urlString2 = baseUrl + "business/GetAgents";
            Uri url2 = new Uri(urlString2, UriKind.Absolute);
            var client2 = new RestClient(url2);
            var request2 = new RestRequest(Method.GET);
            request2.AddHeader("cache-control", "no-cache");
            request2.AddParameter("Content-Type", "application/json");
            var response2 = await client2.ExecuteAsync(request2);
            IEnumerable<AgentDownLoadSerializer> objectResponse2 = JsonConvert.DeserializeObject<IEnumerable<AgentDownLoadSerializer>>(response2.Content);
            return objectResponse2;
        }
        private async Task<IEnumerable<BusinessDownloadSerializer>> GetBusinesses(string baseUrl)
        {
            var businessUrlString = baseUrl + "business/GetBusinesses?id=111111";
            Uri businessesUrl = new Uri(businessUrlString, UriKind.Absolute);
            var businessesClient = new RestClient(businessesUrl);
            var businessRequest = new RestRequest(Method.GET);
            businessRequest.AddHeader("cache-control", "no-cache");
            businessRequest.AddParameter("Content-Type", "application/json");
            var businessresponse = await businessesClient.ExecuteAsync(businessRequest);
            IEnumerable<BusinessDownloadSerializer> businessObject = JsonConvert.DeserializeObject<IEnumerable<BusinessDownloadSerializer>>(businessresponse.Content);
            return businessObject;
        }
        private async Task<IEnumerable<BranchesDownLoadSerializer>> GetBranches(long id)
        {
            var baseUrl = _configuration["ApiBaseUrl"];
            var businessUrlString = baseUrl + "business/GetBranches/" + id;
            Uri businessesUrl = new Uri(businessUrlString, UriKind.Absolute);
            var businessesClient = new RestClient(businessesUrl);
            var businessRequest = new RestRequest(Method.GET);
            businessRequest.AddHeader("cache-control", "no-cache");
            businessRequest.AddParameter("Content-Type", "application/json");
            var businessresponse = await businessesClient.ExecuteAsync(businessRequest);
            IEnumerable<BranchesDownLoadSerializer> businessObject = JsonConvert.DeserializeObject<IEnumerable<BranchesDownLoadSerializer>>(businessresponse.Content);
            return businessObject;
        }
        private async Task<IEnumerable<BusinessDownloadSerializer>> GetBusiness(long id)
        {
            var baseUrl = _configuration["ApiBaseUrl"];
            var businessUrlString = baseUrl + "business/GetBusiness/" + id;
            Uri businessesUrl = new Uri(businessUrlString, UriKind.Absolute);
            var businessesClient = new RestClient(businessesUrl);
            var businessRequest = new RestRequest(Method.GET);
            businessRequest.AddHeader("cache-control", "no-cache");
            businessRequest.AddParameter("Content-Type", "application/json");
            var businessresponse = await businessesClient.ExecuteAsync(businessRequest);
            IEnumerable<BusinessDownloadSerializer> businessObject = JsonConvert.DeserializeObject<IEnumerable<BusinessDownloadSerializer>>(businessresponse.Content);
            return businessObject;
        }
        private async Task<IEnumerable<TaxesDownloadSerializer>> GetTaxes(long id)
        {
            var baseUrl = _configuration["ApiBaseUrl"];
            var businessUrlString = baseUrl + "business/GetTaxes/" + id;
            Uri businessesUrl = new Uri(businessUrlString, UriKind.Absolute);
            var businessesClient = new RestClient(businessesUrl);
            var businessRequest = new RestRequest(Method.GET);
            businessRequest.AddHeader("cache-control", "no-cache");
            businessRequest.AddParameter("Content-Type", "application/json");
            var businessresponse = await businessesClient.ExecuteAsync(businessRequest);
            IEnumerable<TaxesDownloadSerializer> businessObject = JsonConvert.DeserializeObject<IEnumerable<TaxesDownloadSerializer>>(businessresponse.Content);
            return businessObject;
        }
        private async Task<IEnumerable<CustomerDownloadSerializer>> GetCustomers(long id)
        {
            var baseUrl = _configuration["ApiBaseUrl"];
            var businessUrlString = baseUrl + "business/GetCustomers/" + id;
            Uri businessesUrl = new Uri(businessUrlString, UriKind.Absolute);
            var businessesClient = new RestClient(businessesUrl);
            var businessRequest = new RestRequest(Method.GET);
            businessRequest.AddHeader("cache-control", "no-cache");
            businessRequest.AddParameter("Content-Type", "application/json");
            var businessresponse = await businessesClient.ExecuteAsync(businessRequest);
            IEnumerable<CustomerDownloadSerializer> businessObject = JsonConvert.DeserializeObject<IEnumerable<CustomerDownloadSerializer>>(businessresponse.Content);
            return businessObject;
        }
        #endregion
>>>>>>> 8d4436eda532d4ecd69a3c9dcee16a7bea0dd548

    }
}
