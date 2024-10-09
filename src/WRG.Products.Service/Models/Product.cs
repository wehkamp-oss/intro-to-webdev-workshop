namespace WRG.Products.Service.Models;

public record Product
{
    /// <summary>
    /// The name of the product
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// The brand of the product
    /// </summary>
    public required string Brand { get; init; }

    /// <summary>
    /// Internal product number
    /// </summary>
    public required string ProductNumber { get; init; }

    /// <summary>
    /// Size code of the product
    /// </summary>
    public required string SizeCode { get; init; }

    /// <summary>
    /// For what facia's the product is available
    /// </summary>
    public required int SalesSegment { get; init; }

    /// <summary>
    /// EAN code of the product
    /// </summary>
    public required string EAN { get; init; }

    /// <summary>
    /// The group of the article
    /// </summary>
    public required string ArticleGroup { get; init; }

    /// <summary>
    /// The supplier of the product
    /// </summary>
    public required string SupplierId { get; init; }

    /// <summary>
    /// How the product needs to be shipped
    /// </summary>
    public required ShippingMethodType ShippingMethod { get; init; }

    /// <summary>
    /// The purchase price of the product
    /// </summary>
    public required double PurchasePrice { get; init; }

    /// <summary>
    /// The sales prices pro sales segment of the products
    /// </summary>
    public required IEnumerable<ProductPrice> SalesPrices { get; init; }

    /// <summary>
    /// When the product was seeded to this service
    /// </summary>
    public required DateTime CreationDateTime { get; init; }

    /// <summary>
    /// When the product was last updated
    /// </summary>
    public required DateTime MutationDateTime { get; init; }
}
