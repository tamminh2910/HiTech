using HiTech.Model.Entites;
using System.Collections.Generic;

namespace HiTech.Web.Areas.Admin.Models
{
    public class OrderDetailViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}