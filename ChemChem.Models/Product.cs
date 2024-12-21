using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ChemChem.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Phải có tiêu đề")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Tiêu đề phải từ 3 - 100 từ")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Phải có mô tả")]
        [StringLength(2000, MinimumLength = 3, ErrorMessage = "Mô tả phải từ 3 - 100 từ")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Phải có ISBN")]
        [MaxLength(20, ErrorMessage = "ISBN không được vượt quá 20 ký tự")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Phải có tên tác giả")]
        public string Author { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Giá tiền phải lớn hơn 0")]
        [Required(ErrorMessage = "Phải có giá tiền")]
        [Display(Name = "List Price")]
        public double ListPrice { get; set; }

        [Required(ErrorMessage = "Phải có giá tiền cho khoảng 1 - 50")]
        [Display(Name = "Price for 1-50")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Phải có giá tiền cho khoảng 50 - 100")]
        [Display(Name = "Price for 50-100")]
        public double Price50 { get; set; }

        [Required(ErrorMessage = "Phải có giá tiền cho khoảng 100+")]
        [Display(Name = "Price for 100+")]
        public double Price100 { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [Required(ErrorMessage = "Phải có ảnh sản phẩm")]
        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}