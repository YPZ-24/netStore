using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Product{
        public Product(){}
        [Key]
        public int ProductID {get;set;}
        public int SupplierID {get;set;}
        public string? NameProduct {get;set;}
        public string? CountryProduct {get;set;}
        public string? CategoryProduct {get;set;}
        public string? CveProduct {get;set;}
        public double? WeightProduct {get;set;}
        [Range(1, 10, ErrorMessage = "La puntuación debe ser un valor entre 1 y 10")]
        public int? ScoreProduct {get;set;}
        //Proveedor
        public double? RealPrice {get;set;}
        public double? SuggestedPrice {get;set;}
        public double? PublicPrice {get;set;}



    }
}