using System;
using System.Windows;

namespace Zastoji
{
   /// <summary>
   ///    Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      private double _rad;
      private double _zastoj;

      public MainWindow()
      {
         InitializeComponent();
      }

      public DateTime PocetnoVrijeme { get; set; }
      public DateTime ZavrsnoVrijeme { get; set; }
      public TimeSpan Razlika { get; set; }

      private void IzracunajVrijeme_Click(object sender, RoutedEventArgs e)
      {
         Datum razlika = null;
         if (DtPocetnoVrijeme.Value == null || DtZavrnoVrijeme.Value == null ||
             DtPocetnoVrijeme.Value > DtZavrnoVrijeme.Value) return;

         PocetnoVrijeme = (DateTime) DtPocetnoVrijeme.Value;
         ZavrsnoVrijeme = (DateTime) DtZavrnoVrijeme.Value;
         razlika = new RazlikaDatuma(PocetnoVrijeme, ZavrsnoVrijeme).VratiIzracun();
         IspisiULabele(razlika);
         if (razlika.Dani > 0)
         {
            var sati = razlika.Dani * 24 + razlika.Sati;

            Rezultat.Content = sati + " sati, " + razlika.Minute + " minute";
            DodajUListu(sati, razlika.Minute);
         }
         else
         {
            Rezultat.Content = razlika.Sati + " sati, " + razlika.Minute + " minute";
            DodajUListu(razlika.Sati, razlika.Minute);
         }
      }

      private void DodajUListu(int sati, int razlikaMinute)
      {
         double.TryParse(sati + "," + razlikaMinute, out var satmin);
         if (RadBtnZastoj.IsChecked == true)
         {
            ListaZastoja.Items.Add(satmin);
            _zastoj += satmin;
            UkupnoZastoja.Content = "Ukupno: " + _zastoj;
         }
         else
         {
            ListaRada.Items.Add(satmin);
            _rad += satmin;
            UkupnoRada.Content = "Ukupno: " + _rad;
         }

         //double total += satmin;
      }

      private void IspisiULabele(Datum razlika)
      {
         LblMinute.Content = razlika.Minute;
         var sati = razlika.Sati;
         var dani = razlika.Dani;
         if (sati < 0)
         {
            dani = dani - 1;
            LblDani.Content = dani;
            sati = (-24 - razlika.Sati) * -1;
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

      private void BtnOcistiListuZastoja_Click(object sender, RoutedEventArgs e)
      {
         ListaZastoja.Items.Clear();
         _zastoj = 0.0;
         UkupnoZastoja.Content = "";
      }

      private void BtnOcistiListuRada_Click(object sender, RoutedEventArgs e)
      {
         ListaRada.Items.Clear();
         _rad = 0.0;
         UkupnoRada.Content = "";
      }
   }
}