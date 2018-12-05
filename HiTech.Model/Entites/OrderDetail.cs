using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiTech.Model.Entites
{
    public class OrderDetail
    {
        [Key, Column(Order = 0)]
        [Display(Name = "Mã hóa đơn")]
        public int OrderID { get; set; }

        [Key, Column(Order = 1)]
        [Display(Name = "Mã sản phẩm")]
        public int ProductID { get; set; }

        [Display(Name = "Đơn giá")]
        public decimal? UnitPrice { get; set; }

        [Display(Name = "Số lượng")]
        public int? Quantity { get; set; }

        [Display(Name = "Giảm giá")]
        public int? Discount { get; set; }

        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}