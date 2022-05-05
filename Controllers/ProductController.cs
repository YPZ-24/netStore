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

    [HttpGet("/[controller]/Stock")]
    public dynamic GetStock(){
        var dataset = _context.Products
            .Select(x => new{
                NameProduct = x.NameProduct,
                StockProduct = x.StockProduct
            }).ToList();
        return dataset;
    }

    [HttpGet("/[controller]/Stock/Category")]
    public dynamic GetStockByCategory(){
        var dataset = _context.Products
            .GroupBy(x => x.CategoryProduct)
            .Select(x => new { 
                CategoryProduct = x.Key,
                Stock = x.Sum(y => y.StockProduct)
            }).ToList();
        return dataset;
    }
    

    [HttpGet]
    public ActionResult<List<Product>> GetByPage(int? page)
    {
        List<Product> products;
        if(page.HasValue && page.Value <= 0) return BadRequest("La página solicitada no es válida");
        if(page.HasValue){
            int nPerPage = 2;
            int nSkit = nPerPage * (page.Value-1);
            products = _context.Products.Skip(nSkit).Take(nPerPage).ToList<Product>();
        }else{
            products = _context.Products.ToList<Product>();
        }

        return products;
    }

    [HttpPost]
    public ActionResult<Product> Create(Product product)
    {
        //Validando si existe el proveedor
        Supplier supplierFinded = _context.Suppliers.Where(s => s.SupplierID == product.SupplierID).FirstOrDefault<Supplier>();
        if(supplierFinded==null) return BadRequest("El Proveedor ingresado no existe");

        //Validamos que la cve de producto no se repita
        Product productFinded = _context.Products.Where(p => p.CveProduct == product.CveProduct).FirstOrDefault<Product>();
        if(productFinded!=null) return BadRequest("La clave del producto ya esta en uso");

        _context.Add(product);
        _context.SaveChanges();
        return new CreatedAtRouteResult("Producto Creado", product);
    }

    [HttpPatch("{id}")]
    public ActionResult<Product> Update(Product product, int id)
    {
        Product productFinded = _context.Products.Where(p => p.ProductID == id).FirstOrDefault<Product>();
        if(productFinded==null) return NotFound("No se encontró el producto");

        //Validamos que la cve de producto no se repita
        Product productCveUsed = _context.Products.Where(p => p.CveProduct == product.CveProduct).FirstOrDefault<Product>();
        if(productCveUsed!=null && productCveUsed.ProductID != id) return BadRequest("La clave del producto ya esta en uso");

        productFinded.SupplierID = product.SupplierID;
        productFinded.NameProduct = product.NameProduct;
        productFinded.CountryProduct = product.CountryProduct;
        productFinded.CategoryProduct = product.CategoryProduct;
        productFinded.CveProduct = product.CveProduct;
        productFinded.WeightProduct = product.WeightProduct;
        productFinded.ScoreProduct = product.ScoreProduct;
        productFinded.RealPriceProduct = product.RealPriceProduct;
        productFinded.SuggestedPriceProduct = product.SuggestedPriceProduct;
        productFinded.PublicPriceProduct = product.PublicPriceProduct;

        _context.SaveChanges();

        return Ok(product);
    }
}
