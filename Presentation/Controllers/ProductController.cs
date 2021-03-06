using BLL;
using DAL;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Presentation.Hubs;
using Presentation.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductController: ControllerBase
    {
        private readonly IHubContext<SignalHub> _hubContext;
        private readonly ProductService productService;

        public ProductController(FigorificoContext figorificoContext, IHubContext<SignalHub> hubContext)
        {
            this.productService = new ProductService(figorificoContext);
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> Post(ProductInputModel productInput)
        {
           Product product  = Map(productInput);
           var response = productService.Save(product);

           if(response.Error)
           {
                ModelState.AddModelError("Guardar Producto", response.Message);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
           }
           var productViewModel = new ProductViewModel(response.Product);
           await _hubContext.Clients.All.SendAsync("ProductoRegistrado", productViewModel);
           return  Ok(productViewModel);
        }

        private Product Map(ProductInputModel productInput)
        {
            Product product  = new Product();

            product.IdProduct = productInput.IdProduct;
            product.Type = productInput.Type;
            product.SalePrice = productInput.SalePrice;
            product.PurchasePrice = productInput.PurchasePrice;
            product.Quantity = productInput.Quantity;
            product.Iva = productInput.Iva;
            product.Image = productInput.Image;
            product.Description = productInput.Description;
            product.Category = productInput.Category;

            return product;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductViewModel>> GetProducts()
        {
            var response =  productService.GetConsult();

            if(response.Products == null)
            {
                return BadRequest(response.Message);
            }

            var products = response.Products.Select(p => new ProductViewModel(p));
           
            return  Ok(products);
        }

        [HttpDelete("{idProduct}")]
        public ActionResult<ProductViewModel> Delete(string idProduct)
        {
            var response = productService.Delete(idProduct);
            if(response.Product == null) return BadRequest(response.Message);
            return Ok(response.Product);
        }

        [HttpPut]
        public ActionResult<ProductViewModel> Modify(ProductInputModel productInput)
        {
            Product product = Map(productInput);
            var response = productService.Modidy(product);
            if(response.Error) return BadRequest(response.Message);
            return Ok(response.Product);
        }


     
    }
}