using System;

namespace GeekBurger.Dashboard.Interface
{
    interface IOrder
    {
        int Id { get; set; }

        DateTime CreationDate { get; set; }

        decimal Value { get; set; }
    }
}
