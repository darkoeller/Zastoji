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
           Datum razlika = null;
            if (DtPocetnoVrijeme.Value == null || DtZavrnoVrijeme.Value == null || DtPocetnoVrijeme.Value > DtZavrnoVrijeme.Value)return;

              PocetnoVrijeme = (DateTime)DtPocetnoVrijeme.Value;             
              ZavrsnoVrijeme= (DateTime)DtZavrnoVrijeme.Value;
               razlika = new RazlikaDatuma(PocetnoVrijeme, ZavrsnoVrijeme).VratiIzracun();
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
             LblMinute.Content = razlika.Minute;
            var sati = razlika.Sati;
            var dani = razlika.Dani;
            if (sati < 0)
            {
                dani = dani -1;
                LblDani.Content = dani;
                sati = (-24 - razlika.Sati) * (-1);
                LblSati.Content = sati;
            }
            else
            {
            LblDani.Content = razlika.Dani;
            LblSati.Content = razlika.Sati;
            }
      }

      private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DtPocetnoVrijeme.Value = DateTime.Now;
            DtZavrnoVrijeme.Value = DateTime.Now;
        }
    }
}
