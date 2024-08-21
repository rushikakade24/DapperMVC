using DapperCRUDProduct.Models;
using DapperCRUDProduct.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Emit;

namespace DapperCRUDProduct.Controllers
{
    public class ProductController1 : Controller
    {
        private readonly IProductRepository product;

        public ProductController1(IProductRepository _product)
        {
            product = _product;
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product _product)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(_product);
                bool AddProductResult = await product.AddAsync(_product);
                if (AddProductResult)
                {
                    TempData["added"] = "Successfully added";
                }
                
            }
            catch (Exception ex) {
                
            }
            return RedirectToAction(nameof(DisplayAll));
        }

        public async Task<IActionResult> DisplayAll()
        {
            var displayResult = await product.GetallAsync();
            return View(displayResult);
        }

        public async Task<IActionResult> Details(int id)
        {
            var DetailsResult = await product.GetByIdAsync(id);
            if (DetailsResult == null)
                return NotFound();
            return View(DetailsResult);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var EditResult = await product.GetByIdAsync(id);
            if (EditResult == null)
                return NotFound();
            return View(EditResult);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product _product)
        {
            try
            {
                if(!ModelState.IsValid)
                    return View(product);

                var EditResult = await product.UpdateAsync(_product);
                if(EditResult)
                {
                    TempData["updated"] = "Successfully updated";
                }
                

            }
            catch(Exception ex)
            {
                
            }
            return RedirectToAction(nameof(DisplayAll));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var DeleteResult = await product.GetByIdAsync(id);
            if (DeleteResult == null)
                return NotFound();
            return View(DeleteResult);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var deleteResult = await product.DeleteAsync(id);
                if (deleteResult)
                {
                    TempData["Deleted"] = "Successfully Deleted";
                }
               
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(DisplayAll));
        }
    }
}
