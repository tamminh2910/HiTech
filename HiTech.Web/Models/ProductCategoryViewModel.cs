using HiTech.Model.Entites;
using System.Collections.Generic;

namespace HiTech.Web.Models
{
    public class ProductCategoryViewModel
    {
        public IEnumerable<Product> Product { get; set; }
        public IEnumerable<Category> Category { get; set; }
    }
}