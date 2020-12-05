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
using Telefonszamok_DAL;

namespace Telefonszamok_LA01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private cnTelefonszamok cnTelefonszamok;

        public MainWindow()
        {
            InitializeComponent();
            cnTelefonszamok = new cnTelefonszamok();
        }

        private void miMentes_Click(object sender, RoutedEventArgs e)
        {
            cnTelefonszamok.SaveChanges();
        }

        private void miKilepes_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void miHelysegek_Click(object sender, RoutedEventArgs e)
        {
            grHelyseg.Visibility = Visibility.Hidden;
            dgAdatracs.Visibility = Visibility.Visible;

            var er = (from x in cnTelefonszamok.enHelysegek select new { x.IRSZ, x.Nev }).ToList();
            dgAdatracs.ItemsSource = er;
        }

        private void miMindenAdat_Click(object sender, RoutedEventArgs e)
        {
            grHelyseg.Visibility = Visibility.Hidden;
            dgAdatracs.Visibility = Visibility.Visible;

            var er = new List<SzemelyesAdatok>();

            foreach (var x in cnTelefonszamok.Enszemelyek)
            {
                er.Add(new SzemelyesAdatok { 
                    Vezeteknev = x.Vezeteknev,
                    Utonev = x.Utonev,
                    HelysegNev = x.enHelyseg.Nev,
                    Irsz = x.enHelyseg.IRSZ,
                    Lakcim = x.Lakcim,
                    Telefonszamok = x.Telefonszamok()
                });
            }

            dgAdatracs.ItemsSource = er;
        }

        private void miHelysegeAM_Click(object sender, RoutedEventArgs e)
        {
            grHelyseg.Visibility = Visibility.Visible;
            dgAdatracs.Visibility = Visibility.Hidden;

            grHelyseg.DataContext = cnTelefonszamok.enHelysegek.ToList();
            //cbIrsz.SelectedItem = 0;
        }

        private void cbIrsz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var aktualis = ((ComboBox)sender).SelectedItem as enHelyseg;
            cbHelysegnev.SelectedItem = aktualis;

            tbIrsz.Text = aktualis.IRSZ.ToString();
            tbHelysegnev.Text = aktualis.Nev;
        }

        private void btVissza_Click(object sender, RoutedEventArgs e)
        {
            grHelyseg.Visibility = Visibility.Hidden;
        }

        private void Beallit(bool b)
        {
            btUjHelyseg.IsEnabled = b;
            cbIrsz.IsEnabled = b;
            cbHelysegnev.IsEnabled = b;
        }

        private void btUjHelyseg_Click(object sender, RoutedEventArgs e)
        {
            Beallit(false);
            tbIrsz.Text = "";
            tbHelysegnev.Text = "";
        }

        private void btRogzit_Click(object sender, RoutedEventArgs e)
        {
            var adat = new enHelyseg { IRSZ = Int16.Parse(tbIrsz.Text), Nev = tbHelysegnev.Text.ToString() };

            if (!btUjHelyseg.IsEnabled){
                cnTelefonszamok.enHelysegek.Add(adat);
            }
            cnTelefonszamok.SaveChanges();
            grHelyseg.Visibility = Visibility.Hidden;
            Beallit(true);
        }
    }
}
