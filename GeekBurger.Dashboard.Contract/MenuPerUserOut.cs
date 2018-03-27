using System;
using System.Collections.Generic;

namespace GeekBurger.Dashboard.Contract
{
    /// <summary>
    /// Defines the OUT contract of API of restrictions per user.
    ///     It will return all products the user has regardless it's ingredients restriction
    /// </summary>
    public class MenuPerUserOut
    {
        public MenuPerUserOut()
        {
        }

        public string UserId { get; set; }
        public int ProductCount { get; set; }
        public ICollection<string> Restrictions { get; set; }
    }
}
