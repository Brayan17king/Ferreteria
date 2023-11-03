using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria.Classes;
public class InvoiceDetail
{
    public int Id { get; set; }
    public int NumberInvoice { get; set; }
    public int IdProduct { get; set; }
    public int Quantity { get; set; }
    public double Value { get; set; }
}
