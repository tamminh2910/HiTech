using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiTech.Model.Entites
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên danh mục")]
        [Required]
        public string CategoryName { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}