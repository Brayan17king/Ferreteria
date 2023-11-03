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

