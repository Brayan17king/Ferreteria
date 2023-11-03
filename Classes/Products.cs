using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
