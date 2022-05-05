using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class SupplierService{
        public SupplierService(){}

        [Key]
        public int SupplierServicesID {get;set;}
        public int SupplierID {get;set;}

        [Range(1, 10, ErrorMessage = "La puntuación de tiempo de entrega debe ser un valor entre 1 y 10")]
        public int? DeliveryTimeSS {get;set;}

        [Range(1, 10, ErrorMessage = "La puntuación de calidad de entrega debe ser un valor entre 1 y 10")]
        public int? DeliveryQualitySS {get;set;}

        [Range(1, 10, ErrorMessage = "La puntuación de calidad de embalaje debe ser un valor entre 1 y 10")]
        public int? PackingQualitySS {get;set;}
        
    }
}