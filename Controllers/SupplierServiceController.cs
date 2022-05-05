using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Data;
using Proyecto.Models;

namespace Proyecto.Controllers;

[ApiController]
[Route("[controller]")]
public class SupplierServiceController : ControllerBase{
    
    private readonly DataContext _context;

    public SupplierServiceController(DataContext context){
        _context = context;
    }
    /*
    [HttpGet]
    public IEnumerable<SupplierService> Get()
    {
        return _context.SupplierServices.ToList<SupplierService>();
    }*/

    [HttpPost]
    public ActionResult<Supplier> Create(SupplierService supplierService)
    {
        //Validando si existe el proveedor
        Supplier supplierFinded = _context.Suppliers.Where(s => s.SupplierID == supplierService.SupplierID).FirstOrDefault<Supplier>();
        if(supplierFinded==null) return BadRequest("El Proveedor ingresado no existe");
        
        _context.Add(supplierService);
        _context.SaveChanges();
        return new CreatedAtRouteResult("Calificación a Proveedor Agregada", supplierService);
    }
}
