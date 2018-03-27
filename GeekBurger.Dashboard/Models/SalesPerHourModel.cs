using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Dashboard.Models
{
    public class SalesPerHourModel : TableEntity
    {
        public SalesPerHourModel()
        {
        }

        public SalesPerHourModel(string partitionKey, string rowKey) : base(partitionKey, rowKey)
        {
        }

        public string Date { get; set; }
        public int Hour { get; set; }
        public string OrderId { get; set; }
    }
}
