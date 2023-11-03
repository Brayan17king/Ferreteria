using Ferreteria.Classes;
using Ferreteria.Dtos;

namespace Ferreteria.Extensions;
public class Core
{
    List<Products> _Products = new List<Products>()
        {
            new Products() { Id = 001, NameProduct = "Gloves", UnitPrice = 5000, Quantity = 10, StockMin = 15 , StockMax = 30},
            new Products() { Id = 002, NameProduct = "Hammer", UnitPrice = 10000, Quantity = 200, StockMin = 15 , StockMax = 30},
            new Products() { Id = 003, NameProduct = "Drill", UnitPrice = 50000, Quantity = 200, StockMin = 15 , StockMax = 30},
            new Products() { Id = 004, NameProduct = "Shovel", UnitPrice = 32000, Quantity = 200, StockMin = 15 , StockMax = 30},
            new Products() { Id = 005, NameProduct = "Slates", UnitPrice = 20000, Quantity = 200, StockMin = 15 , StockMax = 30}
        };
    List<Customer> _Customer = new List<Customer>()
        {
            new Customer() { Id = 001, NameCustomer = "Brayan Sneyder", Email = "xbrayan@gmail.com"},
            new Customer() { Id = 002, NameCustomer = "Iker Fernando", Email = "iker@gmail.com"},
            new Customer() { Id = 003, NameCustomer = "Lenin Santiago", Email = "Lenin@gmail.com"},
            new Customer() { Id = 004, NameCustomer = "Juan Jose", Email = "Juan@gmail.com"},
            new Customer() { Id = 005, NameCustomer = "Cristian Leonardo", Email = "Cristian@gmail.com"}
        };

    List<Invoice> _Invoice = new List<Invoice>()
        {
            new Invoice() { NumberInvoice = 01, Date = new DateTime(2023, 1, 15), IdCustomer = 001, TotalInvoice = 5000},
            new Invoice() { NumberInvoice = 02, Date = new DateTime(2023, 1, 25), IdCustomer = 002, TotalInvoice = 10000},
            new Invoice() { NumberInvoice = 03, Date = new DateTime(2023, 2, 08), IdCustomer = 003, TotalInvoice = 50000},
            new Invoice() { NumberInvoice = 04, Date = new DateTime(2023, 3, 20), IdCustomer = 004, TotalInvoice = 32000},
            new Invoice() { NumberInvoice = 05, Date = new DateTime(2023, 3, 30), IdCustomer = 005, TotalInvoice = 20000}
        };

    List<InvoiceDetail> _InvoiceDetail = new List<InvoiceDetail>()
        {
            new InvoiceDetail() { Id = 001, NumberInvoice = 01, IdProduct = 1, Quantity = 2, Value = 5000},
            new InvoiceDetail() { Id = 002, NumberInvoice = 02, IdProduct = 2, Quantity = 1, Value = 10000},
            new InvoiceDetail() { Id = 003, NumberInvoice = 03, IdProduct = 3, Quantity = 1, Value = 50000},
            new InvoiceDetail() { Id = 004, NumberInvoice = 04, IdProduct = 4, Quantity = 1, Value = 32000},
            new InvoiceDetail() { Id = 005, NumberInvoice = 05, IdProduct = 5, Quantity = 1, Value = 20000}
        };

    public void ReturnMenu()
    {
        Console.WriteLine("Press Enter to continue...");
        Console.ReadKey();
    }

    public void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("🌟==========Main Menu=========🌟\n");
        Console.Write("1. 🪓 Product List\n2. 🔨 Product Run Out\n3. 🛒 Products To Buy\n4. 🗓️  January Invoice\n5. 🔎 Products Sold On a Certain Invoice\n6. 💵 Total Inventory Value\n\n0. 🏃 Salir\n");
    }

    public void ProductList()
    {
        Console.Clear();
        var Product = from s in _Products
                      select new { s.Id, s.NameProduct, s.UnitPrice, s.Quantity, s.StockMax, s.StockMin };
        Console.WriteLine("=🔨🪓⛏️🪚🔧🪛=Hardware Products=🔨🪓⛏️🪚🔧🪛=\n");
        foreach (var item in Product)
        {
            Console.WriteLine($"🔖Cod: {item.Id}\n📦Product: {item.NameProduct}\n💸Precio: {item.UnitPrice}\n🔢Cantidad: {item.Quantity}\n📈StockMax: {item.StockMax}\n📉StockMin: {item.StockMin}\n");
        }
        ReturnMenu();
    }

    public void ProductRunOut()
    {
        Console.Clear();
        var Product = _Products.Where(p => p.Quantity < p.StockMin).ToList();
        Console.WriteLine("🪚=Products about to sell out=🔧\n");
        Product.ForEach(tp => Console.WriteLine($"🔖Cod: {tp.Id}\n📦Product: {tp.NameProduct}\n"));
        ReturnMenu();
    }

    public void ProductBuy()
    {
        Console.Clear();
        Console.WriteLine("🛒======Products To Buy======🛒\n");
        var productsToBuy = _Products.Where(p => p.Quantity < p.StockMin).Select(p => new ProductBuyDto
        {
            Id = p.Id,
            NameProduct = p.NameProduct,
            Total = p.StockMin - p.Quantity,
            Price = (p.StockMin - p.Quantity) * p.UnitPrice
        }).ToList();

        productsToBuy.ForEach(p => Console.WriteLine($"🔖Cod: {p.Id}\n📦Product: {p.NameProduct}\n💲Total: {p.Total}\n💵Price: {p.Price}\n"));
        ReturnMenu();
    }

    public void JanuaryInvoices()
    {
        Console.Clear();
        Console.WriteLine("🗓️======January Invoices======🗓️\n");
        var result = _Invoice
            .Join(_InvoiceDetail,
                invoice => invoice.NumberInvoice,
                detail => detail.NumberInvoice,
                (i, d) => new
                {
                    NumberInvoice = i.NumberInvoice,
                    Date = i.Date,
                    IdCustomer = i.IdCustomer,
                    Value = d.Value,
                    Total = d.Value * d.Quantity
                })
            .Where(item => item.Date.Month == 1);

        foreach (var s in result)
        {
            Console.WriteLine($"📜NumberInvoice: {s.NumberInvoice}\n📆Date: {s.Date}\n💁‍♂️IdCustomer: {s.IdCustomer}\n💶TotalInvoice: {s.Total}\n");
        }
        ReturnMenu();
    }

    public void ProductListInvoice()
    {
        bool opc5 = false;
        while (!opc5)
        {
            Console.Clear();
            var invoices = _InvoiceDetail.ToList();
            Console.WriteLine("📜======Invoices======📜\n");
            invoices.ForEach(x => Console.WriteLine($"🧾Invoice - {x.NumberInvoice}"));
            Console.WriteLine("\nEnter the invoice code to search 🔍\n");

            if (int.TryParse(Console.ReadLine(), out int search))
            {
                var Product = _InvoiceDetail.Where(p => p.NumberInvoice == search).ToList();

                var result = _Products
                    .Join(Product,
                        product => product.Id,
                        detail => detail.IdProduct,
                        (p, d) => new
                        {
                            NumberInvoice = d.NumberInvoice,
                            NameProduct = p.NameProduct,
                            Quantity = d.Quantity,
                            UnitPrice = p.UnitPrice,
                            Precio = d.Quantity * p.UnitPrice,
                        });

                foreach (var item in result)
                {
                    Console.Clear();
                    Console.WriteLine("=🪓📅🪚=List of products by invoice=🪓📅🪚=\n");
                    Console.WriteLine($"📜NumberInvoice: {item.NumberInvoice}\n📦Product: {item.NameProduct}\n🔢Quantity: {item.Quantity}\n💰Unit Price: {item.UnitPrice}\n💸Total Price: {item.Precio}\n");
                    opc5 = true;
                }
            }
            else
            {
                Console.WriteLine("🚫Invalid entry. Please enter a valid invoice number.\n");
            }
            ReturnMenu();
        }
    }

    public void TotalInventory()
    {
        Console.Clear();
        var products = _Products.Select(p => new Products
                {
                    Id = p.Id,
                    NameProduct = p.NameProduct,
                    UnitPrice = p.UnitPrice,
                    Quantity = p.Quantity,
                    Total = p.UnitPrice * p.Quantity
                }).ToList();

                foreach (var product in products)
                {
                    Console.WriteLine($"🔖Id:{product.Id}\n📦Product: {product.NameProduct}\n💵Total Product: {product.Total}\n");
                }

                double InventoryValue = products.Sum(p => p.Total);
                Console.WriteLine($"💸Total Inventory: {InventoryValue}\n");
                ReturnMenu();
    }
}
