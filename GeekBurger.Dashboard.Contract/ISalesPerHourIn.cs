namespace GeekBurger.Dashboard.Contract
{
    /// <summary>
    /// Defines the IN contract of API of sales per hour in the actual day.
    /// </summary>
    public interface ISalesPerHourIn
    {
        #region Properties

        /// <summary>
        /// Gets or sets the hour of request.
        /// </summary>
        int Hour { get; set; }

        #endregion
    }
}
