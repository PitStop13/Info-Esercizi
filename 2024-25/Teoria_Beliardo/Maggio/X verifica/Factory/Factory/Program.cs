using System;

public class Veicolo
{
    public string Tipo { get; private set; }

    // Costruttore privato, non accessibile dall’esterno
    private Veicolo(string tipo)
    {
        Tipo = tipo;
    }

    // Metodo factory che crea un veicolo in base al tipo richiesto
    public static Veicolo CreaVeicolo(string tipo)
    {
        if (tipo == "auto" || tipo == "Auto")
        {
            return new Veicolo("Auto");
        }
        else if (tipo == "moto" || tipo == "Moto")
        {
            return new Veicolo("Moto");
        }
        else
        {
            throw new ArgumentException("Tipo di veicolo non valido.");
        }
    }

    // Metodo di istanza che stampa info sul veicolo
    public void Descrivi()
    {
        Console.WriteLine($"Questo è un veicolo di tipo: {Tipo}");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Creo un veicolo di tipo auto usando il metodo factory
            Veicolo v1 = Veicolo.CreaVeicolo("auto");
            v1.Descrivi();

            // Creo un veicolo di tipo moto usando il metodo factory
            Veicolo v2 = Veicolo.CreaVeicolo("moto");
            v2.Descrivi();

            // Provo a creare un veicolo di tipo non valido
            Veicolo v3 = Veicolo.CreaVeicolo("bicicletta");
            v3.Descrivi();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore: {ex.Message}");
        }
    }
}
