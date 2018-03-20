using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekBurger.Dashboard.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekBurger.Dashboard.Controllers
{
    [Route("api/Dashboard")]
    public class DashboardController : Controller
    {
        /// <summary>
        /// Gets the restriction per user sending IMenuPerUserIn
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetMenuPerUser")]
        public async Task<IActionResult> GetMenuPerUser()
        {
            return null;
        }

        /// <summary>
        /// Gets the sales per hour sending IMenuPerUserIn
        /// </summary>
        /// <param name="prISalesPerHourIn"></param>
        /// <returns></returns>
        [HttpGet("GetSalesPerHour")]
        public async Task<IActionResult> GetSalesPerHour(int hour)
        {
            return null;
        }
    }
}