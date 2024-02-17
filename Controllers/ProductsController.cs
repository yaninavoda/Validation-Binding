using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProductsValidation.Models;
using ProductsValidation.Services;

namespace ProductsValidation.Controllers
{

    public class ProductsController : Controller
    {
        private List<Product> myProducts;
        public ProductsController(Data data)
        {
            myProducts = data.Products;
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
            var categories = Product.GetCategories();
            ViewBag.Categories = categories;

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
            var categories = Product.GetCategories();
            ViewBag.Categories = categories;

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            myProducts[myProducts.FindIndex(prod => prod.Id == product.Id)] = product;

            return View(nameof(Details), product);
        }

        
        [HttpPost]
        public IActionResult Create(Product product)
        {
            var categories = Product.GetCategories();
            ViewBag.Categories = categories;

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            myProducts.Add(product);

            TempData["notice"] = "Product successfully created";
            
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

        public IActionResult FilterByCategory()
        {   
            var categories = Product.GetCategories();
            ViewBag.Categories = categories;

            return View(); 
        }

        [HttpPost]
        public IActionResult FilterByCategory(Product product)
        {
            var productsOfCategory = myProducts.Where(pr => pr.Type == product.Type);

            return View("GroupEdit", productsOfCategory.ToArray());
        }

        public IActionResult GroupEdit() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult GroupEdit(Product[] products)
        {
            foreach (var product in products)
            {
                if (!ModelState.IsValid)
                {
                    return View(products);
                }
                myProducts[myProducts.FindIndex(prod => prod.Id == product.Id)] = product;             
            }

            return View("Index", myProducts);
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
