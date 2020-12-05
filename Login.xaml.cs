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
using System.Windows.Shapes;

namespace Telefonszamok_LA01
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btBelepes_Click(object sender, RoutedEventArgs e)
        {
            var ablak = new MainWindow();
            if (true) //felhasználó jelszó páros része e a Felhasználók táblának 
            {
                ablak.Show();
                this.Close();
            }
        }
    }
}
