using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

public class ListReglageViewModel
{
    public int IdProfil { get; set; }
    public string NomProfil { get; set; }
    public List<ReglageViewModel> Reglages { get; set; }

    public ListReglageViewModel() { }

}
public class ReglageViewModel
{
    public int IdReglage { get; set; }
    public int IdProfil { get; set; }
    public int Duree { get; set; }
    public double Lumiere { get; set; }
    public double TemperatureInterieur { get; set; }
    public double Humidite { get; set; }
        
    public ReglageViewModel() { }
}