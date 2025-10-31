using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PreparazioneVerifica_Mia
{
    internal class Libro : Oggetto
    {
        private int anno;
        private string autore;

        public int Anno => anno;
        public string Autore => autore;

        public Libro(string nome,string autore,int anno,int prezzo,int quantità) : base(nome,prezzo,quantità)
        {
            this.anno = anno;
            this.autore = autore;
        }
        
        public Libro(string nome, string autore, int prezzo, int quantità) : base(nome, prezzo, quantità)
        {
            this.anno = 0;
            this.autore = autore;
        }

        public override double CalcolaPrezzoUnitario()
        {
            return Math.Round(Prezzo * 1.04, 2);
        }

        public override string ToString()
        {
            return "Libro" + base.ToString() + $", anno: {Anno}, autore: {Autore}";
        }

    }
}
