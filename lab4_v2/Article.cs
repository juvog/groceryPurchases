using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_v2
{
    class Article
    {
        private string designation;
        private double prix;
        private int quantite;
        private double montantHT;
        private double montantTVA;
        private double montantTTC;
        private double tauxTVA;

        // Constructeur

        public Article(string designation, double prix, int quantite, double tauxTVA) 
        {
            this.designation = designation;
            this.prix = prix;
            this.quantite = quantite;
            this.tauxTVA = tauxTVA;      
        }

        public string Designation { get => designation; set => designation = value; }
        public double Prix { get => prix; set => prix = value; }
        public int Quantite { get => quantite; set => quantite = value; }
        public double TauxTVA { get => tauxTVA; set => tauxTVA = value; }




    }
}
