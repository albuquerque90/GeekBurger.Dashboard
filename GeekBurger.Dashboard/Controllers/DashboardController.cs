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
        /// Gets the restriction per user sending IRestrictionsPerUserIn
        /// </summary>
        /// <param name="prIRestrictionsPerUserIn"></param>
        /// <returns></returns>
        [HttpGet("getRestrictionsPerUser")]
        public IRestrictionsPerUserOut getRestrictionsPerUser(IRestrictionsPerUserIn prIRestrictionsPerUserIn)
        {
            return null;
        }

        /// <summary>
        /// Gets the sales per hour sending IRestrictionsPerUserIn
        /// </summary>
        /// <param name="prISalesPerHourIn"></param>
        /// <returns></returns>
        [HttpGet("getSalesPerHour")]
        public ISalesPerHourOut getSalesPerHour(ISalesPerHourIn prISalesPerHourIn)
        {
            return null;
        }
    }
}