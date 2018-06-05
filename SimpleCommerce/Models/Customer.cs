using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCommerce.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string BillingFirstName { get; set; }
        public string BillingLastName { get; set; }
        public string BillingIdentityNumber { get; set; }
        public string BillingCompanyName { get; set; }
        public string BillingCountry { get; set; }
        public string BillingCity { get;set; }
        public string BillingCounty { get; set; }
        public string BillingDistrict { get; set; }
        public string BillingStreet { get; set; }
        public string BillingAdress { get; set; }
        public string BillingZipCode { get; set; }
        public string BillingEmail { get; set; }
        public string BillingPhone { get; set; }


        
        public string ShippingFirstName { get; set; }
        public string ShippingLastName { get; set; }
        public string ShippingIdentityNumber { get; set; }
        public string ShippingCompanyName { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingCounty { get; set; }
        public string ShippingDistrict { get; set; }
        public string ShippingStreet { get; set; }
        public string ShippingAdress { get; set; }
        public string ShippingZipCode { get; set; }
        public string ShippingEmail { get; set; }
        public string ShippingPhone { get; set; }

        public string UserName { get; set; }
        public virtual ICollection<Order> Orders { get; set; }


    }
}
