﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Doctor1.Models
{
    public class ListModel<T>
    {
        public List<T> Items { get; set; }

        public ListModel(List<T> list)
        {
            Items = list;
        }
    }
}