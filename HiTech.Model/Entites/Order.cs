using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiTech.Model.Entites
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        [Display(Name = "Khách hàng")]
        public int? CustomerID { get; set; }
        [Display(Name = "Nhân viên")]
        public int? EmployeeID { get; set; }
        [Display(Name = "Người giao hàng")]
        public int? ShipperID { get; set; }
        [Display(Name = "Tình trạng giao hàng")]
        public int? StateID { get; set; }

        [Display(Name = "Ngày đặt hàng")]
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Ngày đã giao")]
        [DataType(DataType.Date)]
        public DateTime? ShippedDate { get; set; }

        [Display(Name = "Địa chỉ giao hàng")]
        public string ShipAddress { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("OrderID")]
        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }

        [ForeignKey("StateID")]
        public virtual State State { set; get; }

        [ForeignKey("ShipperID")]
        public virtual Shipper Shipper { get; set; }
    }
}