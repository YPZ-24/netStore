using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Data;
using Proyecto.Models;

namespace Proyecto.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase{
    
    private readonly DataContext _context;

    public ProductController(DataContext context){
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Product> Get()
    {
        return _context.Products.ToList<Product>();
    }

    /*
    [HttpGet("/Product/Category")]
    public IQueryable GetByCategory()
    {
        var a = _context.Products.GroupBy(p => p.CategoryProduct);
        return a;
    }*/

    [HttpGet("/[controller]/Stock")]
    public dynamic GetStock(){
        var dataset = _context.Products
            .Select(x => new{
                NameProduct = x.NameProduct,
                StockProduct = x.StockProduct
            }).ToList();
        return dataset;
    }

    [HttpGet("/[controller]/Category")]
    public dynamic GetCategory(){
        var dataset = _context.Products
            .GroupBy(x => x.CategoryProduct)
            .Select(x => new { 
                CategoryProduct = x.Key,
                Stock = x.Sum(y => y.StockProduct)
            }).ToList();
        return dataset;
    }
    

    [HttpGet("{n}")]
    public IEnumerable<Product> GetByPage(int n)
    {
        int nPerPage = 5;
        int nSkit = nPerPage * n;

        return _context.Products.Skip(nSkit).Take(nPerPage).ToList<Product>();
    }

    [HttpPost]
    public ActionResult<Product> Create(Product product)
    {
        _context.Add(product);
        _context.SaveChanges();
        return new CreatedAtRouteResult("Producto Creado", product);
    }

    [HttpPatch("{id}")]
    public ActionResult<Product> Update(Product product, int id)
    {
        Product productFinded = _context.Products.Where(p => p.ProductID == id).FirstOrDefault<Product>();
        if(productFinded==null) return NotFound();
        productFinded.NameProduct = product.NameProduct;
        _context.SaveChanges();
        return Ok(product);
    }
}
