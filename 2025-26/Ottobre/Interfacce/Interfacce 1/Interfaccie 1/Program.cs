using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaccie_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BonificoBancario b= new BonificoBancario();
            PayPal p = new PayPal();
            CartaDiCredito c = new CartaDiCredito();
            Console.OutputEncoding = Encoding.UTF8;

            b.EffettuaPagamento(127.4m);
            p.EffettuaPagamento(127.4m);
            c.EffettuaPagamento(127.4m);

            Console.ReadKey();
        }
    }
}
