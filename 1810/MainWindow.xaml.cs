using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
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

namespace _1810
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //zdroj ↓
        int i = 0;
        int y = 0;
        Random r = new Random(); // r.Next(10)
        ObservableCollection<Person> persons = new ObservableCollection<Person>();
        public MainWindow()
        { 
            InitializeComponent();
            PersonsListView.ItemsSource = persons;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*  persons.Add(new Person("Hodně zajímavá osoba číslo " + i));
              i++;

      */
            progbar.Value = progbar.Value + 10;
        }
        private void opt3_Click(object sender, RoutedEventArgs e)
        {
            progbar.Value = progbar.Value - 10;
        }

        /*private void opt2_Click(object sender, RoutedEventArgs e)
        {
             y = y + 2;
              persons.Add(new Person("" + y));
              
            progbar.Value = progbar.Value -10;
        }*/

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            //GENEROVÁNÍ Příkladu a buttonů
            int a = r.Next(1, 10);
            int b = r.Next(1, 10);

            string[] op = new string[5];
            #region
            op[0] = "+";
            op[1] = "-";
            op[2] = "*";

            #endregion
            int m = r.Next(1, 3);
            int o = 3 - m;
            int l = 3 - o;
            string c = ".Content";

            string priklad = a + op[m] + b;
            string druhypriklad = a + op[m+1] + b;
            // int prikladVysledek = a + op[m] + b;
            string spatnyVysledek = new DataTable().Compute(druhypriklad, null).ToString();
            string prikladVysledek = new DataTable().Compute(priklad, null).ToString();


            question.Content = priklad;


            opt1.Content = prikladVysledek;
            opt3.Content = spatnyVysledek;

            
           
            /*
                        opt + m + c = prikladVysledek;
                        opt + o + c= prikladVysledek - r.Next(0, 50);
                        opt + l + c = prikladVysledek + r.Next(0, 50);
            */

            
        }


    }
}
