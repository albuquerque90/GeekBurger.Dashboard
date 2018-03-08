namespace GeekBurger.Dashboard.Contract
{
    /// <summary>
    /// Defines the OUT contract of API of sales per hour in the actual day.
    ///     It will return all sales occurs in the specified hour
    /// </summary>
    interface ISalesPerHourOut
    {
        #region Properties

        /// <summary>
        /// Gets or sets the hour of request.
        /// </summary>
        int Hour { get; set; }

        /// <summary>
        /// Gets or sets the count of sales the hour have.
        /// </summary>
        int Count { get; set; }

        #endregion
    }
}
