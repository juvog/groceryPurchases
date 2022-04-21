using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_v2
{
    class Gestion
    {
        ObservableCollection<Article> panier;

        public List<Article> items = new List<Article>();

        internal ObservableCollection<Article> Panier { get => panier; set => panier = value; }

        public Gestion()
        {
            Panier = new ObservableCollection<Article>();
        }

        // ajouterArticle()

        public void ajouterArticle(string designation, double prix, int quantite, double tauxTVA){
            Article mon_article = new Article(designation, prix, quantite, tauxTVA);
            Panier.Add(mon_article);
        }


        public double getCumulTVA()
        {
            double montantTVA = 0;
            foreach(Article a in Panier)
            {
                montantTVA += a.TauxTVA;
            }
            return montantTVA;
        }

        public double getCumulTTC()
        {
           double montantTTC = 0;
            foreach(Article a in Panier)
            {
                montantTTC += (a.Prix * a.Quantite) * (1 + a.TauxTVA);
            }
            return montantTTC;
        }

        public double getCumulHT()
        {
            double montantHT = 0;
            foreach(Article a in Panier)
            {
                montantHT += a.Prix * a.Quantite;
            }

            return montantHT;

        }



    }
}
