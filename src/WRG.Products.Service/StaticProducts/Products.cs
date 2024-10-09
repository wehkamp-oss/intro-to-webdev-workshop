using WRG.Products.Service.Models;

namespace WRG.Products.Service.StaticProducts
{
    public static class Products
    {
        public static IList<Product> List => new List<Product>()
        {
            // Toys Category
            new()
            {
                Name = "LEGO Technic Liebherr Rupsbandkraan LR 13000 31142",
                Brand = "LEGO Technic",
                ProductNumber = "17151519",
                SizeCode = "000",
                SalesSegment = 3, // 1 + 2 = 3
                EAN = "5702017156026",
                ArticleGroup = "Lego Technic",
                SupplierId = "f1a58e97-4b5e-4fff-bf41-46c803f35bdd",
                ShippingMethod = ShippingMethodType.Parcel,
                PurchasePrice = 200.00,
                SalesPrices = new List<ProductPrice>()
                {
                    new() { SalesPrice = 529.99, SalesSegment = 1 },
                    new() { SalesPrice = 679.99, SalesSegment = 2 },
                },
                CreationDateTime = DateTime.Now.AddDays(-10).AddMinutes(-5),
                MutationDateTime = DateTime.Now.AddDays(-6).AddMinutes(-4),
            },
            new()
            {
                Name = "Playmobil City Action Brandweerwagen 9464",
                Brand = "Playmobil",
                ProductNumber = "17151520",
                SizeCode = "001",
                SalesSegment = 1, // only in segment 1
                EAN = "5702017156033",
                ArticleGroup = "Playmobil",
                SupplierId = "b7a58e97-4b5e-4fff-bf41-46c803f35abc",
                ShippingMethod = ShippingMethodType.Parcel,
                PurchasePrice = 30.00,
                SalesPrices = new List<ProductPrice>()
                {
                    new() { SalesPrice = 59.99, SalesSegment = 1 },
                },
                CreationDateTime = DateTime.Now.AddDays(-12).AddMinutes(-20),
                MutationDateTime = DateTime.Now.AddDays(-7).AddMinutes(-2),
            },
            new()
            {
                Name = "Barbie Dreamhouse",
                Brand = "Barbie",
                ProductNumber = "17151521",
                SizeCode = "002",
                SalesSegment = 7, // 1 + 2 + 4 = 7
                EAN = "5702017156040",
                ArticleGroup = "Barbie",
                SupplierId = "c7a58e97-4b5e-4fff-bf41-46c803f35ade",
                ShippingMethod = ShippingMethodType.Parcel,
                PurchasePrice = 250.00,
                SalesPrices = new List<ProductPrice>()
                {
                    new() { SalesPrice = 319.99, SalesSegment = 1 },
                    new() { SalesPrice = 349.99, SalesSegment = 2 },
                    new() { SalesPrice = 399.99, SalesSegment = 4 },
                },
                CreationDateTime = DateTime.Now.AddDays(-14).AddMinutes(-30),
                MutationDateTime = DateTime.Now.AddDays(-8).AddMinutes(-3),
            },
            
            // Fashion Category
            new()
            {
                Name = "Nike Air Max 90",
                Brand = "Nike",
                ProductNumber = "17151522",
                SizeCode = "003",
                SalesSegment = 4, // only in segment 4
                EAN = "5702017156057",
                ArticleGroup = "Shoes",
                SupplierId = "d7a58e97-4b5e-4fff-bf41-46c803f35ade",
                ShippingMethod = ShippingMethodType.Parcel,
                PurchasePrice = 80.00,
                SalesPrices = new List<ProductPrice>()
                {
                    new() { SalesPrice = 120.00, SalesSegment = 4 },
                },
                CreationDateTime = DateTime.Now.AddDays(-15).AddMinutes(-35),
                MutationDateTime = DateTime.Now.AddDays(-9).AddMinutes(-4),
            },
            new()
            {
                Name = "Adidas Ultraboost",
                Brand = "Adidas",
                ProductNumber = "17151523",
                SizeCode = "004",
                SalesSegment = 3, // 1 + 2 = 3
                EAN = "5702017156064",
                ArticleGroup = "Shoes",
                SupplierId = "e7a58e97-4b5e-4fff-bf41-46c803f35ade",
                ShippingMethod = ShippingMethodType.Parcel,
                PurchasePrice = 90.00,
                SalesPrices = new List<ProductPrice>()
                {
                    new() { SalesPrice = 130.00, SalesSegment = 1 },
                    new() { SalesPrice = 150.00, SalesSegment = 2 },
                },
                CreationDateTime = DateTime.Now.AddDays(-16).AddMinutes(-45),
                MutationDateTime = DateTime.Now.AddDays(-10).AddMinutes(-5),
            },
            
            // Living Category
            new()
            {
                Name = "NOUS Living Shelf Unit",
                Brand = "NOUS Living",
                ProductNumber = "17151524",
                SizeCode = "005",
                SalesSegment = 7, // 1 + 2 + 4 = 7
                EAN = "5702017156071",
                ArticleGroup = "Furniture",
                SupplierId = "f7a58e97-4b5e-4fff-bf41-46c803f35ade",
                ShippingMethod = ShippingMethodType.Truck,
                PurchasePrice = 60.00,
                SalesPrices = new List<ProductPrice>()
                {
                    new() { SalesPrice = 89.99, SalesSegment = 1 },
                    new() { SalesPrice = 99.99, SalesSegment = 2 },
                    new() { SalesPrice = 109.99, SalesSegment = 4 },
                },
                CreationDateTime = DateTime.Now.AddDays(-17).AddMinutes(-50),
                MutationDateTime = DateTime.Now.AddDays(-11).AddMinutes(-6),
            },
            new()
            {
                Name = "Philips Hue White & Color Ambiance Starter Kit",
                Brand = "Philips",
                ProductNumber = "17151525",
                SizeCode = "006",
                SalesSegment = 2, // only in segment 2
                EAN = "5702017156088",
                ArticleGroup = "Lighting",
                SupplierId = "g7a58e97-4b5e-4fff-bf41-46c803f35ade",
                ShippingMethod = ShippingMethodType.Parcel,
                PurchasePrice = 70.00,
                SalesPrices = new List<ProductPrice>()
                {
                    new() { SalesPrice = 139.99, SalesSegment = 2 },
                },
                CreationDateTime = DateTime.Now.AddDays(-18).AddMinutes(-55),
                MutationDateTime = DateTime.Now.AddDays(-12).AddMinutes(-7),
            },

            // Living Category - Chairs
            new()
            {
                Name = "NOUS Living POÄNG Armchair",
                Brand = "NOUS Living",
                ProductNumber = "17151527",
                SizeCode = "010",
                SalesSegment = 3, // 1 + 2 = 3
                EAN = "5702017156101",
                ArticleGroup = "Furniture",
                SupplierId = "f8a58e97-4b5e-4fff-bf41-46c803f35bdf",
                ShippingMethod = ShippingMethodType.Parcel,
                PurchasePrice = 60.00,
                SalesPrices = new List<ProductPrice>()
                {
                    new() { SalesPrice = 89.99, SalesSegment = 1 },
                    new() { SalesPrice = 99.99, SalesSegment = 2 },
                },
                CreationDateTime = DateTime.Now.AddDays(-10),
                MutationDateTime = DateTime.Now.AddDays(-7),
            },
            new()
            {
                Name = "NOUS Living Dining Chair Set",
                Brand = "NOUS Living",
                ProductNumber = "17151528",
                SizeCode = "011",
                SalesSegment = 4, // only in segment 4
                EAN = "5702017156102",
                ArticleGroup = "Furniture",
                SupplierId = "g8a58e97-4b5e-4fff-bf41-46c803f35bdf",
                ShippingMethod = ShippingMethodType.Parcel,
                PurchasePrice = 120.00,
                SalesPrices = new List<ProductPrice>()
                {
                    new() { SalesPrice = 149.99, SalesSegment = 4 },
                },
                CreationDateTime = DateTime.Now.AddDays(-11),
                MutationDateTime = DateTime.Now.AddDays(-8),
            },

            // Living Category - Couches
            new()
            {
                Name = "NOUS Living Corner Sofa",
                Brand = "NOUS Living",
                ProductNumber = "17151529",
                SizeCode = "012",
                SalesSegment = 7, // 1 + 2 + 4 = 7
                EAN = "5702017156103",
                ArticleGroup = "Furniture",
                SupplierId = "h8a58e97-4b5e-4fff-bf41-46c803f35bdf",
                ShippingMethod = ShippingMethodType.Truck,
                PurchasePrice = 600.00,
                SalesPrices = new List<ProductPrice>()
                {
                    new() { SalesPrice = 899.99, SalesSegment = 1 },
                    new() { SalesPrice = 949.99, SalesSegment = 2 },
                    new() { SalesPrice = 999.99, SalesSegment = 4 },
                },
                CreationDateTime = DateTime.Now.AddDays(-12),
                MutationDateTime = DateTime.Now.AddDays(-9),
            },
            new()
            {
                Name = "NOUS Living 2-Seater Sofa",
                Brand = "NOUS Living",
                ProductNumber = "17151530",
                SizeCode = "013",
                SalesSegment = 2, // only in segment 2
                EAN = "5702017156104",
                ArticleGroup = "Furniture",
                SupplierId = "i8a58e97-4b5e-4fff-bf41-46c803f35bdf",
                ShippingMethod = ShippingMethodType.Truck,
                PurchasePrice = 300.00,
                SalesPrices = new List<ProductPrice>()
                {
                    new() { SalesPrice = 499.99, SalesSegment = 2 },
                },
                CreationDateTime = DateTime.Now.AddDays(-13),
                MutationDateTime = DateTime.Now.AddDays(-10),
            },

            // Living Category - Tables
            new()
            {
                Name = "NOUS Living Coffee Table",
                Brand = "NOUS Living",
                ProductNumber = "17151531",
                SizeCode = "014",
                SalesSegment = 1, // only in segment 1
                EAN = "5702017156105",
                ArticleGroup = "Furniture",
                SupplierId = "j8a58e97-4b5e-4fff-bf41-46c803f35bdf",
                ShippingMethod = ShippingMethodType.Parcel,
                PurchasePrice = 80.00,
                SalesPrices = new List<ProductPrice>()
                {
                    new() { SalesPrice = 129.99, SalesSegment = 1 },
                },
                CreationDateTime = DateTime.Now.AddDays(-14),
                MutationDateTime = DateTime.Now.AddDays(-11),
            },
            new()
            {
                Name = "NOUS Living Dining Table",
                Brand = "NOUS Living",
                ProductNumber = "17151532",
                SizeCode = "015",
                SalesSegment = 3, // 1 + 2 = 3
                EAN = "5702017156106",
                ArticleGroup = "Furniture",
                SupplierId = "k8a58e97-4b5e-4fff-bf41-46c803f35bdf",
                ShippingMethod = ShippingMethodType.Truck,
                PurchasePrice = 200.00,
                SalesPrices = new List<ProductPrice>()
                {
                    new() { SalesPrice = 349.99, SalesSegment = 1 },
                    new() { SalesPrice = 399.99, SalesSegment = 2 },
                },
                CreationDateTime = DateTime.Now.AddDays(-15),
                MutationDateTime = DateTime.Now.AddDays(-12),
            },
            new()
            {
                Name = "NOUS Living Console Table",
                Brand = "NOUS Living",
                ProductNumber = "17151533",
                SizeCode = "016",
                SalesSegment = 7, // 1 + 2 + 4 = 7
                EAN = "5702017156107",
                ArticleGroup = "Furniture",
                SupplierId = "l8a58e97-4b5e-4fff-bf41-46c803f35bdf",
                ShippingMethod = ShippingMethodType.Parcel,
                PurchasePrice = 100.00,
                SalesPrices = new List<ProductPrice>()
                {
                    new() { SalesPrice = 169.99, SalesSegment = 1 },
                    new() { SalesPrice = 199.99, SalesSegment = 2 },
                    new() { SalesPrice = 229.99, SalesSegment = 4 },
                },
                CreationDateTime = DateTime.Now.AddDays(-16),
                MutationDateTime = DateTime.Now.AddDays(-13),
            },
            new()
            {
                Name = "NOUS Living Side Table Set",
                Brand = "NOUS Living",
                ProductNumber = "17151534",
                SizeCode = "017",
                SalesSegment = 1, // only in segment 1
                EAN = "5702017156108",
                ArticleGroup = "Furniture",
                SupplierId = "m8a58e97-4b5e-4fff-bf41-46c803f35bdf",
                ShippingMethod = ShippingMethodType.Parcel,
                PurchasePrice = 60.00,
                SalesPrices = new List<ProductPrice>()
                {
                    new() { SalesPrice = 99.99, SalesSegment = 1 },
                },
                CreationDateTime = DateTime.Now.AddDays(-17),
                MutationDateTime = DateTime.Now.AddDays(-14),
            },
            new()
            {
                Name = "NOUS Living Rectangular Dining Table",
                Brand = "NOUS Living",
                ProductNumber = "17151535",
                SizeCode = "018",
                SalesSegment = 2, // only in segment 2
                EAN = "5702017156109",
                ArticleGroup = "Furniture",
                SupplierId = "n8a58e97-4b5e-4fff-bf41-46c803f35bdf",
                ShippingMethod = ShippingMethodType.Truck,
                PurchasePrice = 220.00,
                SalesPrices = new List<ProductPrice>()
                {
                    new() { SalesPrice = 399.99, SalesSegment = 2 },
                },
                CreationDateTime = DateTime.Now.AddDays(-18),
                MutationDateTime = DateTime.Now.AddDays(-15),
            },
            new()
            {
                Name = "NOUS Living Round Coffee Table",
                Brand = "NOUS Living",
                ProductNumber = "17151536",
                SizeCode = "019",
                SalesSegment = 4, // only in segment 4
                EAN = "5702017156110",
                ArticleGroup = "Furniture",
                SupplierId = "o8a58e97-4b5e-4fff-bf41-46c803f35bdf",
                ShippingMethod = ShippingMethodType.Parcel,
                PurchasePrice = 75.00,
                SalesPrices = new List<ProductPrice>()
                {
                    new() { SalesPrice = 139.99, SalesSegment = 4 },
                },
                CreationDateTime = DateTime.Now.AddDays(-19),
                MutationDateTime = DateTime.Now.AddDays(-16),
            },

            // Big Goods Category
            new()
            {
                Name = "Samsung 75 Inch QLED TV",
                Brand = "Samsung",
                ProductNumber = "17151526",
                SizeCode = "007",
                SalesSegment = 7, // 1 + 2 + 4 = 7
                EAN = "5702017156095",
                ArticleGroup = "Electronics",
                SupplierId = "h7a58e97-4b5e-4fff-bf41-46c803f35ade",
                ShippingMethod = ShippingMethodType.Truck,
                PurchasePrice = 1500.00,
                SalesPrices = new List<ProductPrice>()
                {
                    new() { SalesPrice = 1999.99, SalesSegment = 1 },
                    new() { SalesPrice = 2199.99, SalesSegment = 2 },
                    new() { SalesPrice = 2299.99, SalesSegment = 4 },
                },
                CreationDateTime = DateTime.Now.AddDays(-19).AddMinutes(-10),
                MutationDateTime = DateTime.Now.AddDays(-13).AddMinutes(-8),
            },
        };
    }
}
