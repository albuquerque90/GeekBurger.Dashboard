namespace GeekBurger.Dashboard.Contract
{
    using System;

    /// <summary>
    /// Defines the mock contract of user.
    /// </summary>
    interface IUser
    {
        #region Properties

        /// <summary>
        /// Gets or sets the id of user.
        /// </summary>
        Guid Id { get; set; }

        #endregion
    }
}
