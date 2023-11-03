using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria.Dtos;
public class ProductBuyDto
{
    public int Id { get; set; }
    public string NameProduct { get; set; }
    public int Total { get; set; }
    public double Price { get; set; }
}
