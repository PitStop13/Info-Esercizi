using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfacce_3
{
    internal interface INotifica
    {
        void InviaNotifica(string messaggio, string destinatario);
        bool VerificaDisponibilita();

    }
}
