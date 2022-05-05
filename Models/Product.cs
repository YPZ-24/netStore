using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Product{
        public Product(){}
        [Key]
        public int ProductID {get;set;}
        [Required(ErrorMessage = "El proveedor del producto es requerido")]
        public int SupplierID {get;set;}
        [Required(ErrorMessage = "El nombre del producto es requerido")]
        public string? NameProduct {get;set;}
        [Required(ErrorMessage = "El país del producto es requerido")]
        public string? CountryProduct {get;set;}
        [Required(ErrorMessage = "La categoría del producto es requerida")]
        public string? CategoryProduct {get;set;}
        [Required(ErrorMessage = "La clave del producto es requerida")]
        public string? CveProduct {get;set;}
        [Required(ErrorMessage = "El peso del producto es requerido")]
        public double? WeightProduct {get;set;}
        [Required(ErrorMessage = "La puntuación del producto es requerida")]
        [Range(1, 10, ErrorMessage = "La puntuación del producto debe ser un valor entre 1 y 10")]
        public int? ScoreProduct {get;set;}
        [Required(ErrorMessage = "El precio real del producto es requerido")]
        public double? RealPriceProduct {get;set;}
        [Required (ErrorMessage = "El precio sugerido del producto es requerido")]
        public double? SuggestedPriceProduct {get;set;}
        [Required (ErrorMessage = "El precio público del producto es requerido")]
        public double? PublicPriceProduct {get;set;}

        //Agregado por que el problema solicitaba existencias
        public int StockProduct {get;set;}



    }
}