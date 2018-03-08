namespace GeekBurger.Dashboard.Interface
{
    using System;

    interface IRestrictionsPerUserOut
    {
        Guid IdUser { get; set; }

        int Count { get; set; }
    }
}
