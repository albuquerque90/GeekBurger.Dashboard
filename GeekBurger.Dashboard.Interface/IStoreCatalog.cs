namespace GeekBurger.Dashboard.Interface
{
    using System.Collections.Generic;

    interface IUserProducts
    {
        IUser User { get; set; }

        IEnumerable<IProduct> Products { get; set; }
    }
}
