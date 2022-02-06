using ErgasiaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Doctor1.Models
{
    public class ListModel<T>
    {
        public Doctor doctor { get; set; }
        public Patient patient { get; set; }
        public List<T> Items { get; set; }

        public string data { get; set; }

        public ListModel(List<T> list, Doctor user)
        {
            Items = list;
            this.doctor = user;
        }
        public ListModel(List<T> list, Patient user)
        {
            Items = list;
            this.patient = user;
        }
    }
}