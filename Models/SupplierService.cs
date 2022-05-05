using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class SupplierService{
        public SupplierService(){}

        [Key]
        public int SupplierServicesID {get;set;}
        [Required(ErrorMessage = "El proveedor del producto es requerido")]
        public int SupplierID {get;set;}
        [Required(ErrorMessage = "La calificación del tiempo de entrega es requerida")]
        [Range(1, 10, ErrorMessage = "La puntuación de tiempo de entrega debe ser un valor entre 1 y 10")]
        public int? DeliveryTimeSS {get;set;}
        [Required(ErrorMessage = "La calificación de la calidad de entrega es requerida")]
        [Range(1, 10, ErrorMessage = "La puntuación de calidad de entrega debe ser un valor entre 1 y 10")]
        public int? DeliveryQualitySS {get;set;}
        [Required(ErrorMessage = "La calificación del la calidad de embalaje es requerida")]
        [Range(1, 10, ErrorMessage = "La puntuación de calidad de embalaje debe ser un valor entre 1 y 10")]
        public int? PackingQualitySS {get;set;}
        
    }
}