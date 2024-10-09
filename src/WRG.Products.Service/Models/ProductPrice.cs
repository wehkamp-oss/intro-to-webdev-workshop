namespace WRG.Products.Service.Models;

public class ProductPrice
{
    /// <summary>
    /// The sales segment of the product
    /// </summary>
    public required int SalesSegment { get; init; }

    /// <summary>
    /// The sales price of the product for this sales segment
    /// </summary>
    public required double SalesPrice { get; init; }
}
