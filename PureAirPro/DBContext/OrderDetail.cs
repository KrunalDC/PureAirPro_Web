using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PureAirPro.DBContext
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; } = null!;
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public string AddressLine1 { get; set; } = null!;
        public string AddressLine2 { get; set; } = null!;
        [Required]
        public string Province { get; set; } = null!;
        [Required]
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public DateTime? OrderDate { get; set; }
        public DateTime? InsertedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
