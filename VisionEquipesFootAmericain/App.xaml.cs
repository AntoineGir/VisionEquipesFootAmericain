using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using ModelLayer.Data;
using ModelLayer.Business;

namespace VisionEquipesFootAmericain
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Dbal thedbal;
        private DaoPays theDaoPays;
        private DaoPoste theDaoPoste;
        private DaoJoueur theDaoJoueur;
        private DaoEquipe theDaoEquipe;



        /*private void Application_Startup(object sender, StartupEventArgs e)
        {
            thedbal = new Dbal("dsfootamericain");
            theDaoPays = new DaoPays(thedbal);
            theDaoPoste = new DaoPoste(thedbal);
            theDaoJoueur = new DaoJoueur(thedbal, theDaoPays, theDaoPoste);
            theDaoEquipe = new DaoEquipe(thedbal, theDaoJoueur);
            MainWindow wnd = new MainWindow(theDaoEquipe, theDaoJoueur, theDaoPays, theDaoPoste);
            //et on utilise la méthode Show() de notre objet fenêtre pour afficher la fenêtre
            //exemple: MainWindow lafenetre = new MainWindow(); (et on y passe en paramètre Dbal et Dao au besoin)
            wnd.Show();
        }*/

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occurred: " + e.Exception.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }
    }
}
