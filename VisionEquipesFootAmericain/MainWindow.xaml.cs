using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ModelLayer.Business;
using ModelLayer.Data;

namespace VisionEquipesFootAmericain
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(DaoEquipe thedaoEquipe, DaoJoueur theDaoJoueur, DaoPays theDaoPays, DaoPoste theDaoPoste)
        {
            InitializeComponent();
            Globale.DataContext = new viewModel.ViewModelJoueur(thedaoEquipe, theDaoJoueur, theDaoPays, theDaoPoste);
        }


    }
}
