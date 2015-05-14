using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace aspProjekt8.Models
{
    public class Klient
    {
        public int ID { get; set; }

         [Display(Name = "Imie Nazwisko Klienta")]
        public string ImieNazwiskoKlienta { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Car> cars { get; set; }
    }
}