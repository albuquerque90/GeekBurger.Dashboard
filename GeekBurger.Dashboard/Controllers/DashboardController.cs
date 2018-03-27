using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekBurger.Dashboard.Contract;
using GeekBurger.Dashboard.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace GeekBurger.Dashboard.Controllers
{
    [Route("api/Dashboard")]
    public class DashboardController : Controller
    {
        /// <summary>
        /// Gets the restriction per user sending IMenuPerUserIn
        /// </summary>
        /// <returns></returns>
        [HttpGet("MenuPerUser")]
        public async Task<IActionResult> GetMenuPerUser()
        {   
            CloudStorageAccount account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=menuperuserdashboard;AccountKey=qi8LIkld3cZT7z3a1qm8NaveU12GVLI0m77T3VmvcYhPKJ3ArzFrNTVEFexWvbD7B5+Py6MdGQdRW2FbmxFdLg==;EndpointSuffix=core.windows.net");

            CloudTableClient tableClient = account.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("menuperuserdashboard");
            bool created = await table.CreateIfNotExistsAsync();

            TableQuery<MenuPerUserModel> query = new TableQuery<MenuPerUserModel>();

            TableQuerySegment<MenuPerUserModel> result = await table.ExecuteQuerySegmentedAsync(query, new TableContinuationToken());
            List<MenuPerUserOut> lst = new List<MenuPerUserOut>();
            result.ToList().ForEach(m => lst.Add(new MenuPerUserOut() { UserId = m.UserId, ProductCount = m.ProductCount, Restrictions = m.Restrictions }));

            return StatusCode(200, lst);
        }

        /// <summary>
        /// Gets the sales per hour sending IMenuPerUserIn
        /// </summary>
        /// <param name="prISalesPerHourIn"></param>
        /// <returns></returns>
        [HttpGet("SalesPerHour")]
        public async Task<IActionResult> GetSalesPerHour(int hour)
        {
            
            CloudStorageAccount account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=menuperuserdashboard;AccountKey=qi8LIkld3cZT7z3a1qm8NaveU12GVLI0m77T3VmvcYhPKJ3ArzFrNTVEFexWvbD7B5+Py6MdGQdRW2FbmxFdLg==;EndpointSuffix=core.windows.net");

            CloudTableClient tableClient = account.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("salesperhourdashboard");
            bool created = await table.CreateIfNotExistsAsync();
            
            TableQuery<SalesPerHourModel> query = new TableQuery<SalesPerHourModel>().Where($"Date eq '{DateTime.Now.ToShortDateString()}' and Hour eq {hour}");
         
            TableQuerySegment <SalesPerHourModel> result = await table.ExecuteQuerySegmentedAsync(query, new TableContinuationToken());

            int count = result.Count();
            return StatusCode(200, count);
        }
    }
}