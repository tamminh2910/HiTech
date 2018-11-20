using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiTech.Model.Entites
{
    public class State
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StateID { get; set; }

        [StringLength(100)]
        [Display(Name = "Mô tả")]
        public string Description { set; get; }

        public virtual IEnumerable<Order> Orders { get; set; }
    }
}