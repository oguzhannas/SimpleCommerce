using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCommerce.Models
{
    public class Product
    {
        public Product()
        {
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name="Ürün Adı")]
        public string Name { get; set; }
        [Display(Name="Açıklama")]
        public string Description { get; set; }
        [StringLength(200)]
        [Display(Name="Resim")]
        public string Photo { get; set; }
        [Display(Name ="Fiyat")]
        [DisplayFormat(DataFormatString = "0,000.00")]
        public decimal Price { get; set; }
        [Display(Name="Stok")]
        public int Stock { get; set; }
        [Display(Name="Oluşturulma Tarihi")]
        public DateTime? CreateDate { get; set; }
        [Display(Name="Öne Çıkan")]
        public bool IsFeatured { get; set; }
        [Display(Name="Yayında Olanlar")]
        public bool IsPublished { get; set; }

        [Display(Name="Kategori")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [Display(Name="Kategori")]
        public Category Category { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
