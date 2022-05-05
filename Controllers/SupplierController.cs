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

    [HttpGet]
    public IEnumerable<Supplier> Get()
    {
        return _context.Suppliers.ToList<Supplier>();
    }

    [HttpPost]
    public ActionResult<Supplier> Create(Supplier supplier)
    {
        _context.Add(supplier);
        _context.SaveChanges();
        return new CreatedAtRouteResult("Proveedor Creado", supplier);
    }

}
