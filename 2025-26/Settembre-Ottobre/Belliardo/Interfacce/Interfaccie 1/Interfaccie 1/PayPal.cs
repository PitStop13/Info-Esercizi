using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaccie_1
{
    internal class PayPal : Ipagamenti
    {
        public void EffettuaPagamento(decimal importo)
        {
          Console.WriteLine("Pagamento effetuato tramite paypal");
        }
    }
}
