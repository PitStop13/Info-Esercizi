using System;
using System.Collections.Generic;

// Classe base: Arnia
public class Arnia
{
    // Campi/proprietà
    private int id;
    protected string posizione;
    public double quantitaMiele { get; private set; }

    // Costruttore overload 1: imposta solo l'ID
    public Arnia(int id)
    {
        this.id = id;
        this.posizione = "Sconosciuta";
        this.quantitaMiele = 0.0;
        Console.WriteLine($"Creata Arnia id={this.id} posizione={this.posizione} mieli={this.quantitaMiele}");
    }

    // Costruttore overload 2: imposta ID e posizione
    public Arnia(int id, string posizione)
    {
        this.id = id;
        this.posizione = posizione;
        this.quantitaMiele = 0.0;
        Console.WriteLine($"Creata Arnia id={this.id} posizione={this.posizione} mieli={this.quantitaMiele}");
    }

    // Metodo virtuale per aggiungere miele
    public virtual void AggiungiMiele(double kg)
    {
        if (kg < 0)
        {
            throw new ArgumentException("La quantità di miele da aggiungere non può essere negativa.");
        }
        this.quantitaMiele += kg;
        Console.WriteLine($"Aggiunto {kg} kg a Arnia id={this.id} -> totale {this.quantitaMiele}");
    }

    // Metodi di accesso
    public string GetPosizione()
    {
        return posizione;
    }

    public int GetId()
    {
        return id;
    }
}

// Sottoclasse: ArniaIntelligente
public class ArniaIntelligente : Arnia
{
    // Campo privato per la batteria
    private double batteria;

    // Costruttore overload 1: chiama il costruttore base
    public ArniaIntelligente(int id) : base(id)
    {
        this.batteria = 100.0;
        Console.WriteLine($"Creata ArniaIntelligente id={this.GetId()} posizione={this.GetPosizione()} batteria={this.batteria}");
    }

    // Costruttore overload 2: chiama il costruttore base e imposta la batteria
    public ArniaIntelligente(int id, string posizione, double batteria) : base(id, posizione)
    {
        this.batteria = batteria;
        Console.WriteLine($"Creata ArniaIntelligente id={this.GetId()} posizione={this.GetPosizione()} batteria={this.batteria}");
    }

    // Override del metodo AggiungiMiele
    public override void AggiungiMiele(double kg)
    {
        base.AggiungiMiele(kg); // Chiama il metodo della classe base
        Console.WriteLine($"(override + log)");
    }

    // Overload del metodo AggiungiMiele (firma diversa)
    public void AggiungiMiele(int kg, bool urgente)
    {
        Console.WriteLine($"Aggiunto {kg} kg (int, urgente) a ArniaIntelligente id={this.GetId()}");
        this.AggiungiMiele((double)kg); // Converte l'int in double e chiama l'altro metodo
    }

    // Metodo protetto per dimostrare l'accesso dalla sottoclasse
    protected void RiportaStatoBatteria()
    {
        Console.WriteLine($"Stato batteria: {this.batteria}%");
    }

    // Metodo con parametro ref
    public void DecrementaBatteria(ref double consumo)
    {
        this.batteria -= consumo;
        consumo = consumo / 2; // Aggiorna il valore della variabile originale
        Console.WriteLine($"Batteria dopo il decremento: {this.batteria}%");
        this.RiportaStatoBatteria();
    }

    // Metodo con parametro out
    public void ResetBatteria(out double nuovaBatteria)
    {
        this.batteria = 100.0;
        nuovaBatteria = this.batteria; // Assegna un valore alla variabile out
        Console.WriteLine("Reset batteria effettuato.");
    }
}