using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace aspProjekt8.Models
{
    public class Car
    {
      
            public int ID { get; set; }
            public string Model { get; set; }
            public int Rocznik { get; set; }
            public string Silnik { get; set; }
            public string Skrzynia { get; set; }
            [Display(Name = "Moc [KM]")]
            public int Moc { get; set; }
            public double Pojemność { get; set; }
            public int Przebieg { get; set; }
            [Display(Name = "Dodatkowe Informacje")]
            public string DodatkoweInformacje { get; set; }
            [Display(Name = "Data przewidywanego odbioru")]
            public DateTime DoOddania { get; set; }
             [Display(Name = "Mechanik")]
            public int WorkerID { get; set; }
            [Display(Name = "Klient")]
            public int KlientID { get; set; }
            public virtual Worker worker { get; set; }
            public virtual Klient klient { get; set; }
        
    }
}