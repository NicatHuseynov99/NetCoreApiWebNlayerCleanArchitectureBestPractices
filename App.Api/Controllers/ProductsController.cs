using App.Services;
using App.Services.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : CustomController
    {

        [HttpGet]
        public async Task<IActionResult> GetAll() => CreateActionResult(await productService.GetAllListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => CreateActionResult(await productService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request) => CreateActionResult(await productService.CreateAsync(request));
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductRequest request) => CreateActionResult(await productService.UpdateAsync(id, request));
        [HttpDelete]
        public async Task<IActionResult> Delete(int id) => CreateActionResult(await productService.DeleteAsync(id));
    }
}
