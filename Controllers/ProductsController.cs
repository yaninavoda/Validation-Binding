using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsValidation.Models;
using ProductsValidation.Services;
using ProductsValidation.Validators;

namespace ProductsValidation.Controllers
{
    
    public class ProductsController : Controller
    {
        private List<Product> myProducts;
        private IValidator<Product> _validator;

        public ProductsController(Data data, IValidator<Product> validator)
        {
            myProducts = data.Products;
            _validator = validator;
        }

        public IActionResult Index(int filterId, string filtername)
        {
            return View(myProducts);
        }
        
        public IActionResult Details(int id)
        {
            Product prod = myProducts.Find(prod => prod.Id == id);
            if (prod != null)
            {
                return View(prod);
            }

            return View("NotExists");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product prod = myProducts.Find(prod => prod.Id == id);
            if (prod != null)
            {
                return View(prod);
            }

            return View("NotExists");
        } 
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            myProducts[myProducts.FindIndex(prod => prod.Id == product.Id)] = product;

            return View(nameof(Details), product);
        }

        
        [HttpPost]
        public IActionResult Create(Product product)
        {
            var categories = Product.GetCategories();
            ViewBag.Categories = categories;

            ValidationResult result = _validator.Validate(product);

            if (!result.IsValid)
            {
                // Copy the validation results into ModelState.
                // ASP.NET uses the ModelState collection to populate 
                // error messages in the View.
                result.AddToModelState(ModelState);

                // re-render the view when validation failed.
                return View(product);
            }

            myProducts.Add(product);

            TempData["notice"] = "Person successfully created";
            
            return View("Details", product);
        }

        public IActionResult Create()
        {
            var categories = Product.GetCategories();
            ViewBag.Categories = categories;

            var newProduct = myProducts.Count > 0 ?
                new Product { Id = myProducts.Last().Id + 1 } :
                new Product { Id = 1 };

            return View(newProduct);
        }

        public IActionResult Delete(int id)
        {
            myProducts.Remove( myProducts.Find(product => product.Id == id));
            return View("Index", myProducts);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
