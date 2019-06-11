using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zastoji
{
    public class Datum
    {
        public int Godine { get; }
        public int Mjeseci { get; }
        public int Dani { get; }
        public int Sati { get;}
        public int Minute { get;}

        public Datum()
        {
            
        }

        public Datum(int godine, int mjeseci, int dani, int sati, int minute)
        {
            Godine = godine;
            Mjeseci = mjeseci;
            Dani = dani;
            Sati = sati;
            Minute = minute;
        }
    }
}
