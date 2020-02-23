using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Kalkulator_Kalorii.Models
{
    public class KalkulatorModel
    {
        [Required(ErrorMessage = "Proszę podać swoją wagę")]
        public double Waga { get; set; }

        [Required(ErrorMessage = "Proszę podać swój wzrost w centymetrach")]
        public double Wzrost { get; set; }

        [Required(ErrorMessage = "Proszę podać swój wiek")]
        public int Wiek { get; set; }

        [Range(1, 7, ErrorMessage = "Ile razy w tygodniu trenujesz? ")]
        public int IloscDniTreningowych { get; set; }

        [Required(ErrorMessage = "Podaj swoją płeć")]
        public bool Plec { get; set; }

        [Range(1, 3, ErrorMessage = "Wybierz jedną z opcji")]
        public int Opcja { get; set; }
        
    }
}