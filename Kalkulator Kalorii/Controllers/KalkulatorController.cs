using Kalkulator_Kalorii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kalkulator_Kalorii.Controllers
{
    public class KalkulatorController : Controller
    {
        
        public double BMR;
        public double TEF;
        public double TEA;

        [HttpGet]
        public ViewResult PobierzDane()
        {
            
            return View();
        }

        [HttpPost]
        public ViewResult PobierzDane(KalkulatorModel model, KalkulatorModelOut modelOut)
        {
            if (ModelState.IsValid)
            {
                if (model.Plec == false)
                {
                    if (model.Opcja == 1)
                    {
                        modelOut.SumaKalorii = LiczKcal(model, 66.47, 13.75, 5, 6.75, 400);
                    }
                    else if (model.Opcja == 2)
                    {
                        modelOut.SumaKalorii = LiczKcal(model, 66.47, 13.75, 5, 6.75, -400);
                    }
                    else if (model.Opcja == 3)
                    {
                        modelOut.SumaKalorii = LiczKcal(model, 66.47, 13.75, 5, 6.75, 0);
                    }

                    LiczMakro(model, modelOut, 2.5);
                }
                else
                {
                    if (model.Opcja == 1)
                    {
                        modelOut.SumaKalorii = LiczKcal(model, 665.09, 9.56, 1.85, 4.67, 400);
                    }
                    else if (model.Opcja == 2)
                    {
                        modelOut.SumaKalorii = LiczKcal(model, 665.09, 9.56, 1.85, 4.67, -400);
                    }
                    else if (model.Opcja == 3)
                    {
                        modelOut.SumaKalorii = LiczKcal(model, 665.09, 9.56, 1.85, 4.67, 0);
                    }

                    LiczMakro(model, modelOut, 2.3);
                }
                return View("Dzieki", modelOut);
            }
            return View(model);
        }

        public double LiczKcal(KalkulatorModel kalkulatorModel, double liczba1, double liczba2, double liczba3, double liczba4, int kcal)
        {
            BMR = liczba1 + (liczba2 * kalkulatorModel.Waga) + (liczba3 * kalkulatorModel.Wzrost) - (liczba4 * kalkulatorModel.Wiek);
            TEF = BMR * 01;
            TEA = kalkulatorModel.IloscDniTreningowych;
            return Math.Round((BMR + TEF + TEA + kcal), 0); ;
        }

        public void LiczMakro(KalkulatorModel kalkulatorModel, KalkulatorModelOut modelOut, double liczba1)
        {
            modelOut.Białko = Math.Round((kalkulatorModel.Waga * liczba1), 0);
            modelOut.Tluszcze = Math.Round((modelOut.SumaKalorii * 0.3) / 9, 0);
            modelOut.Weglowodany = 
                Math.Round((modelOut.SumaKalorii - ((modelOut.Białko) * 4 + (modelOut.Tluszcze) * 9)) / 4, 0);
        }

        public ViewResult Index()
        {            
            return View();
        }       
    }
}