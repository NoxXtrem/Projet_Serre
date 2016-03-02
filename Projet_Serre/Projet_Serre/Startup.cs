using Microsoft.Owin;
using Owin;


[assembly: OwinStartupAttribute(typeof(Projet_Serre.Startup))]
namespace Projet_Serre
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            Profil p = new Profil();
            p.Nom = "radis";
            GestionProfil gp = new GestionProfil();
            gp.Ajouter(p);
            gp.Supprimer(p.Id);
        }
    }
}
