namespace GeekBurger.Dashboard.Contract
{
    /// <summary>
    /// Defines the OUT contract of API of restrictions per user.
    ///     It will return all products the user has regardless it's ingredients restriction
    /// </summary>
    public interface IRestrictionsPerUserOut
    {
        #region Properties

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        IUser User { get; set; }

        /// <summary>
        /// Gets or sets the count of restrictions the user have.
        /// </summary>
        int Count { get; set; }

        #endregion
    }
}
