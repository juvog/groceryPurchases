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

namespace lab4_v2
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Gestion gestion = new Gestion();
        public MainWindow()
        {
            InitializeComponent();
            // A l'initialisation, on lie le datagrid au contenu du panier
            
            dtgArticles.ItemsSource = gestion.Panier;

        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
           
            double tva = 0;
            if (rdb20.IsChecked == false && rdb7.IsChecked == false)
            {
                MessageBox.Show("Veuillez choisir un taux TVA.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if(rdb20.IsChecked == true)
            {
                tva = 0.2;
            }
            else
            {
                tva = 0.07;
            }
            if(txtDesignation.Text != string.Empty && txtPrix.Text != string.Empty && txtQuantite.Text != string.Empty)
            {
                string designation = txtDesignation.Text;
                double prixHT = double.Parse(txtPrix.Text);
                int quantite = int.Parse(txtQuantite.Text);

                gestion.ajouterArticle(designation, prixHT, quantite, tva);

                txtTotalHT.Text = gestion.getCumulHT().ToString();
                txtTotalTVA.Text = gestion.getCumulTVA().ToString();
                txtTotalTTC.Text = gestion.getCumulTTC().ToString();

            }
            else
            {
                MessageBox.Show("Données manquantes", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            // On vide toutes les cases 
            txtDesignation.Text = "";
            txtPrix.Text = "";
            txtQuantite.Text = "";
            txtTotalHT.Text = "";
            txtTotalTVA.Text = "";
            txtTotalTTC.Text = "";

            // on vide le panier.
            gestion.Panier.Clear();

        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            // Validation : un article doit être sélectionné. 
            if (dtgArticles.SelectedIndex != -1)
            {
                gestion.Panier.Remove(dtgArticles.SelectedItem as Article);

            }
            else
            {
                MessageBox.Show("Sélectionnez un article SVP", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Quitter_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        

    }
}
