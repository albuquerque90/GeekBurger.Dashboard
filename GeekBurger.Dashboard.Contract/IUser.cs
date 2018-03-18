namespace GeekBurger.Dashboard.Contract
{
    using System;

    /// <summary>
    /// Defines the mock contract of user.
    /// </summary>
    public interface IUser
    {
        #region Properties

        /// <summary>
        /// Gets or sets the id of user.
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the user's name
        /// </summary>
        string Name { get; set; }

        #endregion
    }
}
