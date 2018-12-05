using HiTech.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HiTech.Web.Models
{
    public class ItemCart
    {
        public Product Product { set; get; }
        public int Quantity { get; set; }
    }
}