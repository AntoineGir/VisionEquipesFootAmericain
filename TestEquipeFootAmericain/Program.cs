using System;
using MySql.Data.MySqlClient;

using ModelLayer.Business;
using ModelLayer.Data;

using System.Collections.Generic;

namespace TestEquipeFootAmericain
{
    public class Program
    {
        private static Dbal mydbal;
        private static DaoPays myDaoPays;
        private static DaoPoste myDaoPoste;
        private static DaoJoueur myDaoJoueur;
        private static DaoEquipe myDaoEquipe;

        private static Pays myPays;
        private static Poste myPoste;
        private static Joueur myJoueur;
        private static Equipe myEquipe;

        static void Main(string[] args)
        {
            mydbal = new Dbal("dsfootamericain");
            myPoste = new Poste();
            myDaoPoste = new DaoPoste(mydbal);

            myPays = new Pays();
            myDaoPays = new DaoPays(mydbal);

            myJoueur = new Joueur();
            myDaoJoueur = new DaoJoueur(mydbal, myDaoPays, myDaoPoste );

            myEquipe = new Equipe();
            myDaoEquipe = new DaoEquipe(mydbal, myDaoJoueur);


            List<Poste> listPost = myDaoPoste.SelectAll();
            
            foreach(Poste f in listPost)
            {
                Console.WriteLine(f.Nom);
            }

            Console.WriteLine("--------------------------");

            List<Joueur> listJoueur = myDaoJoueur.SelectAll();

            foreach (Joueur f in listJoueur)
            {
                Console.WriteLine(f.Nom);
            }


            Console.WriteLine("--------------------------");

            List<Equipe> ListEquipe = myDaoEquipe.SelectAll();

            foreach (Equipe f in ListEquipe)
            {
                Console.WriteLine(f.Nom);
            }

            Console.WriteLine("--------------------------");

            Poste unPoste = myDaoPoste.SelectById(1);
            Console.WriteLine(unPoste.Nom);

            Joueur unJoueur = myDaoJoueur.SelectById(1);
            Console.WriteLine(unJoueur.Nom);



        }
    }
}
