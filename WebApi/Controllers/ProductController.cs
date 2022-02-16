using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.DAL;
using WebApi.Data.Entity;
using WebApi.Dto.ProductDto;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Context _context;

        public ProductController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(int page=1)
        {

            var query = _context.Products.AsQueryable();
            ProductReturnDto productRetrunDto = new ProductReturnDto
            {
                TotalCount = query.Count(),
                Items=query.Skip((page-1)*5).Take(5).Select(p=>new ProductItemDto
                {
                    Name=p.Name,
                    IsDelete=p.IsDelete,
                    Price=p.Price,
                    CreatedAt=p.CreatedAt,
                    UpdatedAt=p.UpdatedAt
                }).ToList()
            };
            
           
            return Ok(productRetrunDto);
        }
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetOne(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return StatusCode(404);

            return StatusCode(200,product);
        }

        [HttpPost]
        public IActionResult Create(ProductCreateDto productCreateDto)
        {
            Product newProduct = new Product
            {
                Name = productCreateDto.Name,
                Price = productCreateDto.Price,
                IsDelete = productCreateDto.IsDelete
            };

            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,ProductUpdateDto  productUpdateDto)
        {
            Product dbProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (dbProduct == null) return NotFound();
            dbProduct.Name = productUpdateDto.Name;
            dbProduct.Price = productUpdateDto.Price;
            dbProduct.IsDelete = productUpdateDto.IsDelete;
            _context.SaveChanges();
            return StatusCode(200);
        }

        [HttpDelete("{id}")]

        public IActionResult Remove(int? id)
        {
            if (id == null) return NotFound();

            Product dbProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (dbProduct == null) return NotFound();

            _context.Remove(dbProduct);
            _context.SaveChanges();

            return NoContent();

        }

       
    }
   
}
