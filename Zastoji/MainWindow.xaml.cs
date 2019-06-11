using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zastoji
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DateTime PocetnoVrijeme { get; set; }
        public DateTime ZavrsnoVrijeme { get; set; }
        public TimeSpan Razlika { get; set; }
        public MainWindow()
        {
            InitializeComponent();           
                      
        }

        private void IzracunajVrijeme_Click(object sender, RoutedEventArgs e)
        {
            if (DTPocetnoVrijeme.Value == null || DTZavrnoVrijeme.Value == null)return;

              PocetnoVrijeme = (DateTime)DTPocetnoVrijeme.Value;             
              ZavrsnoVrijeme= (DateTime)DTZavrnoVrijeme.Value;
              var razlika = new RazlikaDatuma(PocetnoVrijeme, ZavrsnoVrijeme).VratiIzracun();
            IspisiULabele(razlika);
            if (razlika.Dani > 0)
            {
               var sati = (razlika.Dani * 24) + razlika.Sati;

                Rezultat.Content  = sati +" sati, " + razlika.Minute + " minute";
            }
            else
            {
                Rezultat.Content  =  razlika.Sati+" sati, " + razlika.Minute + " minute";
            }          
            
        }

        private void IspisiULabele(Datum razlika)
        {
            LblDani.Content = razlika.Dani;
            LblMinute.Content = razlika.Minute;
            LblSati.Content = razlika.Sati;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DTPocetnoVrijeme.Value = DateTime.Now;
            DTZavrnoVrijeme.Value = DateTime.Now;
        }
    }
}
