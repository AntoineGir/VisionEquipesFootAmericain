using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using ModelLayer.Business;
using ModelLayer.Data;

namespace VisionEquipesFootAmericain.viewModel
{
    class ViewModelJoueur : ViewModelBase
    {
        private DaoEquipe vmDaoEquipe;
        private DaoJoueur vmdDaoJoueur;
        private DaoPays vmDaoPays;
        private DaoPoste vmDaoPoste;

        private Icommand updateCommand;
        private Icommand newCommand;
        private Icommand deleteCommand;
        private ObservableCollection<Pays> listPays;
        private ObservableCollection<Poste> listPoste;
        private ObservableCollection<Equipe> listEquipe;
        private ObservableCollection<Joueur> listJoueursEquipe;

        private Equipe selectedEquipe = new Equipe();
        private Joueur selectedJoueursEquipes = new Joueur();
        private Pays selectedPays = new Pays();
        private Poste selectedPoste = new Poste();

        public ObservableCollection<Pays> ListPays { get => listPays; set => listPays = value; }
        public ObservableCollection<Poste> ListPoste { get => listPoste; set => listPoste = value; }
        public ObservableCollection<Equipe> ListEquipe { get => listEquipe; set => listEquipe = value; }
        public ObservableCollection<Joueur> ListJoueursEquipe { get => listJoueursEquipe; set => listJoueursEquipe = value; }



        public ViewModelJoueur(DaoEquipe thedaoEquipe, DaoJoueur thedaoJoueur, DaoPays thedaoPays, DaoPoste thedaoPoste)
        {
            vmDaoEquipe = thedaoEquipe;
            vmdDaoJoueur = thedaoJoueur;
            vmDaoPays = thedaoPays;
            vmDaoPoste = thedaoPoste;

            listPays = new ObservableCollection<Pays>(thedaoPays.SelectAll());
            listPoste = new ObservableCollection<Poste>(thedaoPoste.SelectAll());
            listEquipe = new ObservableCollection<Equipe>(thedaoEquipe.SelectAll());
            listJoueursEquipe = new ObservableCollection<Joueur>(thedaoJoueur.SelectAll());

            foreach(Joueur itemFr in listJoueursEquipe)
            {
                int i = 0;
                while (itemFr.IdPoste.Id !=listPoste[i].Id)
                {
                    i++;
                }
                itemFr.IdPoste = listPoste[i];
            }
        }


        public Icommand newCommnand
        {
            get
            {
                if (this.newCommand == null)
                {
                    this.newCommand = new RelayCommand(() => NewJoueur(), () => true);
                }
                return this.newCommand;
            }
        }

        public void NewJoueur()
        {
            int total = listJoueursEquipe.Count;
            total = selectedJoueursEquipes.Id;
            this.vmdDaoJoueur.Insert(this.selectedJoueursEquipes, this.selectedEquipe);

            listJoueursEquipe.Insert(total, selectedJoueursEquipes);
        }


        public Equipe SelectedEquipe
        {
            get => selectedEquipe;

            set
            {
                if (selectedEquipe != value)
                {
                    selectedEquipe = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("SelectedEquipe");
                }
            }
        }

        public Joueur SelectedJoueursEquipe
        {
            get => selectedJoueursEquipes;

            set
            {
                if (selectedJoueursEquipes!=value)
                {
                    selectedJoueursEquipes=value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("SelectedJoueursEquipe");
                    OnPropertyChanged("NomJoueur");
                    OnPropertyChanged("Position");
                }
            }
        }

        public string NomJoueur
        {
            get => selectedJoueursEquipes.Nom;

            set
            {
                if (selectedJoueursEquipes.Nom != value)
                {
                    selectedJoueursEquipes.Nom = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("NomJoueur");
                }
            }
        }

        public Poste Position
        {
            get => selectedPoste;
            set
            {
                if (selectedPoste != value)
                {
                    selectedPoste = value;
                    OnPropertyChanged("Position");
                }
            }
        }

        public Pays SelectedPays
        {
            get => selectedPays;
            set
            {
                if (selectedPays != value)
                {
                    selectedPays = value;
                    OnPropertyChanged("SelectedPays");
                }
            }
        }


        //DateEntree pour Joueurs
        public DateTime DateEntree
        {
            get => selectedJoueursEquipes.DateEntree;

            set
            {
                if (selectedJoueursEquipes.DateEntree != value)
                {
                    selectedJoueursEquipes.DateEntree = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("DateEntree");
                }
            }
        }

        //DateNaissance pour Joueurs
        public DateTime DateNaissance
        {
            get => selectedJoueursEquipes.DateNaissance;
            set
            {
                if (selectedJoueursEquipes.DateNaissance != value)
                {
                    selectedJoueursEquipes.DateNaissance = value;
                    OnPropertyChanged("DateNaissance");
                }
            }
        }

        public Pays Origine
        {
            get => selectedJoueursEquipes.IdPays;
            set
            {
                if (selectedJoueursEquipes.IdPays != value)
                {
                    selectedJoueursEquipes.IdPays = value;
                    OnPropertyChanged("Origine");
                }
            }
        }

        

        /*  public Pays Origine
          {
              get => Select;
              set
              {
                  if (selectedJoueursEquipes.Nom != value)
                  {
                      selectedJoueursEquipes.Nom = value;
                      OnPropertyChanged("Nom");
                  }
              }
          }
        */


    }
}


