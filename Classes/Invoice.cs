using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria.Classes;
public class Invoice
{
    public int NumberInvoice { get; set; }
    public DateTime Date { get; set; }
    public int IdCustomer { get; set; }
    public double TotalInvoice { get; set; }
}
