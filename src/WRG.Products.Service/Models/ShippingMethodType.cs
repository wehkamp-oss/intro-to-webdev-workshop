namespace WRG.Products.Service.Models;

public enum ShippingMethodType
{
    /// <summary>
    /// Not known how to ship this
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Ship this with our parcel carrier
    /// </summary>
    Parcel = 1,

    /// <summary>
    /// Ship this with our truck carrier
    /// </summary>
    Truck = 2,
}
