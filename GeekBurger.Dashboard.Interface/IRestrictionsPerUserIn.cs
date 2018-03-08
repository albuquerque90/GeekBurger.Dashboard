namespace GeekBurger.Dashboard.Contract
{
    using System;

    /// <summary>
    /// Defines the IN contract of API of restrictions per user.
    /// </summary>
    interface IRestrictionsPerUserIn
    {
        #region Properties

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        Guid UserId { get; set; }

        #endregion
    }
}
