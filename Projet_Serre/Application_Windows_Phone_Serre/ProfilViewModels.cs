using System;
using System.Collections.Generic;
using System.Linq;

public class ListProfilViewModel
{
    public string NomProfilActuel { get; set; }
    public int IdProfilActuel { get; set; }
    public List<ProfilViewModel> Profils { get; set; }

    public ListProfilViewModel() { }
}

public class ProfilViewModel
{
    public int Id { get; set; }

    public string Nom { get; set; }

    public ProfilViewModel() { }
}