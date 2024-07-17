using System.ComponentModel.DataAnnotations;
using FinalProject.Entity;

namespace FinalProject.Models
{
    public class ProductCreateViewModel{

        public int ProductId {get;set;}

        [Required]
        [Display(Name ="Ürün Adı")]
        public string? ProductName {get;set;}

        [Required]
        [Display(Name ="Ürün Kategorisi")]
        public string? ProductCategory {get;set;}

        [Required]
        [Display(Name ="Ürünün Açıklaması")]
        public string? ProductDescription {get;set;}

        [Required]
        [Display(Name ="Fiyat")]
        public int ProductPrice {get;set;}

        public string? Image {get;set;} = string.Empty;
        
        [Required]
        [Display(Name ="Url")]
        public string? ProductUrl {get;set;}

        public int StockQuantity { get; set; }

        public List<Category>Categories{get;set;}= new();


    }
}