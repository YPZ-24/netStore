using Microsoft.AspNetCore.Mvc;
using Proyecto.Data;
using Proyecto.Models;

namespace Proyecto.Controllers;

[ApiController]
[Route("[controller]")]
public class SupplierController : ControllerBase{
    
    private readonly DataContext _context;

    public SupplierController(DataContext context){
        _context = context;
    }
/*
    [HttpGet]
    public IEnumerable<Supplier> Get()
    {
        return _context.Suppliers.ToList<Supplier>();
    }
*/
    [HttpPost]
    public ActionResult<Supplier> Create(Supplier supplier)
    {
        Supplier supplierFinded = _context.Suppliers.Where(s => s.RFCSupplier == supplier.RFCSupplier).FirstOrDefault<Supplier>();
        if(supplierFinded!=null) return BadRequest("El RFC del Proveedor ya existe");

        _context.Add(supplier);
        _context.SaveChanges();
        return new CreatedAtRouteResult("Proveedor Creado", supplier);
    }

    [HttpGet("/[controller]/Score")]
    public dynamic GetScore(){
        var dataset = _context.SupplierServices
            .GroupBy(x => x.SupplierID)
            .Select(x => new { 
                SupplierID = x.Key,
                Score = x.Average(y => y.DeliveryQualitySS + y.PackingQualitySS + y.DeliveryTimeSS) / 3
            }).ToList();

        return dataset;
    }

}
