namespace Zastoji
{
   public class Datum
   {
      public Datum(int godine, int mjeseci, int dani, int sati, int minute)
      {
         Godine = godine;
         Mjeseci = mjeseci;
         Dani = dani;
         Sati = sati;
         Minute = minute;
      }

      private int Godine { get; }
      private int Mjeseci { get; }
      public int Dani { get; }
      public int Sati { get; }
      public int Minute { get; }
   }
}