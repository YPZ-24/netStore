using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Supplier{
        public Supplier(){}

        public int SupplierID {get;set;}
        
        [Required (ErrorMessage = "El RFC del proveedor es requerido")]
        [RegularExpression(@"^[A-Z&Ñ]{3,4}[0-9]{2}(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])[A-Z0-9]{2}[0-9A]$", ErrorMessage = "El RFC del proveedor es invalido")]
        public string RFCSupplier {get; set;}

        [Required (ErrorMessage = "La dirección fiscal del proveedor es requerida")]
        public string TaxAddressSupplier {get; set;}

        [Required (ErrorMessage = "El giro del proveedor es requerido")]
        public string DedicatedToSupplier {get; set;}

        [Required (ErrorMessage = "La razón social del proveedor es requerida")]
        public string SocialReasonSupplier {get; set;}
    }
}