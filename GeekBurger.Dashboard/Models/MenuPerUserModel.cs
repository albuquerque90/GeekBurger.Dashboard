using GeekBurger.Dashboard.Contract;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeekBurger.Dashboard.Models
{
    public class MenuPerUserModel : TableEntity
    {
        public MenuPerUserModel()
        {
        }

        public MenuPerUserModel(string partitionKey, string rowKey) : base(partitionKey, rowKey)
        {
        }

        public string UserId { get; set; }
        public int ProductCount { get; set; }
        public ICollection<string> Restrictions { get; set; }
    }
}