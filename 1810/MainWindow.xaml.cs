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
using FileHelpers;

namespace _1810
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        //zdroj ↓
        int i = 0;
        int y = 0;
        int skore = 0;
        Random r = new Random(); // r.Next(10)
        ObservableCollection<Person> persons = new ObservableCollection<Person>();
        private int gb;
        //ObservableCollection<MyFile> osoba = new ObservableCollection<MyFile>();

        //var engine = new FileHelperEngine<vysledek>();
        //var result = engine.ReadFile("vysledky.csv");




        public MainWindow()
        { 
            InitializeComponent();
            PersonsListView.ItemsSource = persons;
        }
        public void generateme()
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
            string druhypriklad = a + op[m + 1] + b;
            // int prikladVysledek = a + op[m] + b;
            string spatnyVysledek = new DataTable().Compute(druhypriklad, null).ToString();
            string prikladVysledek = new DataTable().Compute(priklad, null).ToString();


            question.Content = priklad;


            opt1.Content = prikladVysledek;

            opt3.Content = spatnyVysledek;

            //KONEC GENEROVÁNÍ PŘÍKLADU A BUTTONŮ

        }

        //prvni odpoved
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*  persons.Add(new Person("Hodně zajímavá osoba číslo " + i));
              i++;

      */
           
            progbar.Value = progbar.Value + 10;
            skore = skore + 10;
            skoore.Content = skore;
            generateme();
        }
        //druha odpoved
        private void opt3_Click(object sender, RoutedEventArgs e)
        {

            progbar.Value = progbar.Value - 10;
            skore = skore - 10;
            skoore.Content = skore;
            generateme();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            generateme();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FileHelperEngine engine = new FileHelperEngine(typeof(MyFile));
            var result = engine.ReadFile("D:\\fiserkl15\\1810\\1810\\vysledky.csv");


          //  ObservableCollection<MyFile> osoba = new ObservableCollection<MyFile>();


            List<MyFile> cisla = new List<MyFile>();
           
            foreach (MyFile row in result)
            {
                
                
                cisla.Add(row);

                // datazcsv.Content = (row.Name + " " + row.skore);
                //  osoba.Name = row.Name;
                // osoba.skore = row.skore;
                // ... to bude chtít asi oop ☺ 
            }
            var SortedList = cisla.OrderByDescending(x => x.skore).ToList();
            //List<MyFile> SortedList = cisla.OrderBy(o => o.skore).ToList();
            for (i = 0; i < cisla.Count; i++)
            {
                //List<MyFile> SortedList = cisla.OrderBy(o => o.skore).ToList();

                datazcsv.Items.Add(SortedList[i].Name + " " + SortedList[i].skore);

            }
            
        }

        [DelimitedRecord(",")]
        public class MyFile
        {
            public string Name;
            public int skore;
        }

    }
}
    //jeden button

    //=> generateme();
    /*
                         opt + m + c = prikladVysledek;
                         opt + o + c= prikladVysledek - r.Next(0, 50);
                         opt + l + c = prikladVysledek + r.Next(0, 50);
             */




