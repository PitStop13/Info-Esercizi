using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaccie_1
{
    internal class CartaDiCredito : Ipagamenti
    {
        public void EffettuaPagamento(decimal importo)
        {
            Console.WriteLine("Pagamento effetuato tramite carta di credito");   
        }
    }
}
