using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GGShopMVC.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        [Required(ErrorMessage = "")]
        [StringLength(140)]
        public string FirstName { get; set;}

        [Required(ErrorMessage = "")]
        [StringLength(140)]
        public string LastName { get; set;}

        [Required(ErrorMessage = "")]
        [StringLength(70)]
        public string CodeCity { get; set;}
        public string Address { get; set;}

        [Required(ErrorMessage = "")]
        public string Phone { get; set;}

        [Required(ErrorMessage = "")]
        public string Email { get; set;}
        public string Description { get; set;}
        public DateTime DateCreated { get; set; }
        public OrderState OrderState { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }

    public enum OrderState
    {
        New,

        Shipped
    }
}