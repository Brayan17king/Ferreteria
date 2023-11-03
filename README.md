# Creation Proyect Console

- [Project Creation](#Project-creation)

- [Creation of Entities](#Creation-of-Entities)
  
  1. [Entities](#Invoice-Entitie)

- [Creation of Dto](#Dto-Creation)
  
  2. [Dto](#Product-Buy-Dto)

- [Creation of Core](#Creacion-de-Core)
  
  3. [List](#Example-of-lists)
  
  4. [Menu](#Menu)
  
  5. [Functions](#Search-Function)

- [Main Program](#Main-Program)
  
  6. [Program.cs](#Program.cs)
     
         

# Project creation

```bash
dotnet new console -o "NameProyect"
```

# Creation of Entities

First we create the folder <mark>Classes</mark> which will contain all our Entities.

#### Customer Entitie

```dotnet
namespace Ferreteria.Classes;
public class Customer
{
    public int Id { get; set;}
    public string NameCustomer { get; set; }
    public string Email { get; set; }
}
```

#### Invoice Entitie

```dotnet
namespace Ferreteria.Classes;
public class Invoice
{
    public int NumberInvoice { get; set; }
    public DateTime Date { get; set; }
    public int IdCustomer { get; set; }
    public double TotalInvoice { get; set; }
}
```

#### Invoice Detail Entitie

```dotnet
namespace Ferreteria.Classes;
public class InvoiceDetail
{
    public int Id { get; set; }
    public int NumberInvoice { get; set; }
    public int IdProduct { get; set; }
    public int Quantity { get; set; }
    public double Value { get; set; }
}
```

#### Products Entitie

```dotnet
namespace Ferreteria.Classes;
public class Products
{
    public int Id { get; set; }
    public string NameProduct { get; set; }
    public double UnitPrice { get; set; }
    public int Quantity { get; set; }
    public int StockMin { get; set; }
    public int StockMax { get; set; }
    public double Total { get; internal set; }
}
```

# Dto Creation

Creamos una carpeta que llamaremos Dto, Creamos nuestra clase Dto que servira para mostrar la inforamcion que queremos ver y omitir la que queramos

## Product Buy Dto

```dotnet
namespace Ferreteria.Dtos;
public class ProductBuyDto
{
    public int Id { get; set; }
    public string NameProduct { get; set; }
    public int Total { get; set; }
    public double Price { get; set; }
}
```

# Creacion de Core

First we create the folder <mark>Extension </mark>which will have all the functions and ready for functionality.

## Example of lists

```dotnet
List<Products> _Products = new List<Products>()
        {
            new Products() { Id = 001, NameProduct = "Gloves", UnitPrice = 5000, Quantity = 10, StockMin = 15 , StockMax = 30},
            new Products() { Id = 002, NameProduct = "Hammer", UnitPrice = 10000, Quantity = 200, StockMin = 15 , StockMax = 30},
            new Products() { Id = 003, NameProduct = "Drill", UnitPrice = 50000, Quantity = 200, StockMin = 15 , StockMax = 30},
            new Products() { Id = 004, NameProduct = "Shovel", UnitPrice = 32000, Quantity = 200, StockMin = 15 , StockMax = 30},
            new Products() { Id = 005, NameProduct = "Slates", UnitPrice = 20000, Quantity = 200, StockMin = 15 , StockMax = 30}
```

## Menu

```dotnet
    public void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("🌟==========Main Menu=========🌟\n");
        Console.Write("1. 🪓 Product List\n2. 🔨 Product Run Out\n3. 🛒 Products To Buy\n4. 🗓️  January Invoice\n5. 🔎 Products Sold On a Certain Invoice\n6. 💵 Total Inventory Value\n\n0. 🏃 Salir\n");
    }
```

## Search Function

```dotnet
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
```

# Main Program

En este apartado se ejecutaran las funciones y se mostrara el menu con sus diferentes opciones.

## Program.cs

```dotnet
using Ferreteria.Extensions;
internal class Program
{
    private static void Main(string[] args)
    {
        Core core = new Core();
        Console.Clear();
        bool opcMenu = false;
        while (!opcMenu)
        {
            core.MainMenu();
            Console.Write("\nEnter an option 💬: ");
            string cod = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(cod))
            {
                Console.WriteLine("❌Error, the code cannot be empty.  Press Enter to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            else if (!int.TryParse(cod, out int opc))
            {
                Console.WriteLine("❌Error, please enter a valid code (integer). Press Enter to continue... ");
                Console.ReadKey();
                Console.Clear();
            }
            else if (cod != "0" && cod != "1" &&  cod != "2" && cod != "3" && cod != "4" && cod != "5"&& cod != "6" )
            {
                Console.WriteLine("❌Error, the code entered is not found in the menu. Press Enter to continue...");
                Console.ReadKey();
                Console.Clear();
            }

            switch (cod)
            {
                case "0":
                    Console.Clear();
                    Console.WriteLine("Hasta Pronto 👋");
                    opcMenu = true;
                break;

                case "1":
                    Console.Clear();
                    core.ProductList();
                break;

                case "2":
                    Console.Clear();
                    core.ProductRunOut();
                break;

                case "3":
                    Console.Clear();
                    core.ProductBuy();
                break;

                case "4":
                    Console.WriteLine();
                    core.JanuaryInvoices();
                break;

                case "5":
                    Console.WriteLine();
                    core.ProductListInvoice();
                break; 

                case "6":
                    Console.WriteLine();
                    core.TotalInventory();
                break;     
            }
        }
    }
}
```
