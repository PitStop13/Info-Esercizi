using System;

namespace Palestra
{
    // Interfaccia: definisce un contratto per i servizi che richiedono prenotazione
    // Polimorfismo: permette di trattare oggetti diversi allo stesso modo se implementano l'interfaccia
    public interface IPrenotabile
    {
        int PostiDisponibili { get; }
        bool Prenota(string nomeCliente);
        bool AnnullaPrenotazione(string nomeCliente);
        string GetInfoPrenotazioni();
    }
}
