using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kalkulator_Kalorii.Models
{
    public class KalkulatorModelOut
    {
        public double SumaKalorii { get; set; }
        public double Białko { get; set; }
        public double Tluszcze { get; set; }
        public double Weglowodany { get; set; }
    }
}