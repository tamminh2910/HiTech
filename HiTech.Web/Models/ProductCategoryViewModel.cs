using HiTech.Model.Entites;
using System.Collections.Generic;

namespace HiTech.Web.Models
{
    public class ProductCategoryViewModel
    {
        public List<Product> Product { get; set; }
        public List<Category> Category { get; set; }
    }
}