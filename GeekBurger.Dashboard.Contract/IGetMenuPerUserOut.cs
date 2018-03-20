using System;
using System.Collections.Generic;

namespace GeekBurger.Dashboard.Contract
{
    /// <summary>
    /// Defines the OUT contract of API of restrictions per user.
    ///     It will return all products the user has regardless it's ingredients restriction
    /// </summary>
    public interface IMenuPerUserOut
    {
        #region Properties

        /// <summary>
        /// Gets or sets the user Guid.
        /// </summary>
        Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the count of available products per user.
        /// </summary>
        int ProductCount { get; set; }

        /// <summary>
        /// Gets or sets the list of restrictions the user have.
        /// </summary>
        ICollection<string> Restrictions { get; set; }

        #endregion
    }
}
