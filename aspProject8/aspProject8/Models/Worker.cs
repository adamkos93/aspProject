using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace aspProjekt8.Models
{
    public class Worker
    {
        
        public int ID { get; set; }
         [Display(Name = "Imie Nazwisko Mechanika")]
        public string ImieNazwiskoPracownika { get; set; }
        public virtual ICollection<Car> cars { get; set; }
    
    }
}